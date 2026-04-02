using Application.Helpers;
using Application.Mapping;
using Domain.DTOs.Auth;
using Domain.DTOs.Cliente;
using Domain.DTOs.Tecnico;
using Domain.entities;
using Domain.entities.baseEntities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.models;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(
            ITecnicoRepository tecnicoRepository,
            IClienteRepository clienteRepository,
            ITokenService tokenService,
            IMapper mapper)
        {
            _tecnicoRepository = tecnicoRepository;
            _clienteRepository = clienteRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<OperationResult<object>> Login(LoginRequest request)
        {
            BaseUser user = await GetUserByEmail(request.Email);
            if (user == null || !Argon2Helper.VerifyPassword(request.Senha, user.SenhaHash)) 
                return OperationResult<object>.Unauthorized(new MensagemErro("Login", "Email ou senha inválidos"));

            return await GenerateLoginResponseByRole(user);
        }

        public async Task<OperationResult<object>> RefreshToken(RefreshTokenRequest request)
        {
            BaseUser user = await GetUserByRefreshToken(request.RefreshToken);
            if (user == null || !user.IsRefreshTokenValid(request.RefreshToken))
                return OperationResult<object>.Unauthorized(new MensagemErro("RefreshToken", "Refresh token inválido ou expirado"));

            return await GenerateLoginResponseByRole(user);

        }

        public async Task<OperationResult> Logout(Guid publicId)
        {
            BaseUser user = await GetUserByPublicId(publicId);
            if (user == null) return OperationResult.NotFound(new MensagemErro("Logout", "Usuário não encontrado"));

            user.ClearRefreshToken();

            OperationResult updateResult = await UpdateUserByRole(user);
            if (!updateResult.Success) return updateResult;

            return OperationResult.Ok();
        }

        private async Task<BaseUser?> GetUserByEmail(string email)
        {
            Task<Tecnico> tecnicoTask = _tecnicoRepository.GetByEmail(email);
            Task<Cliente> clienteTask = _clienteRepository.GetByEmail(email);

            await Task.WhenAll(tecnicoTask, clienteTask);

            BaseUser ? user = tecnicoTask.Result;
            return user ?? clienteTask.Result;
        }

        private async Task<BaseUser?> GetUserByRefreshToken(string refreshToken)
        {
            Task<Tecnico> tecnicoTask = _tecnicoRepository.GetByRefreshToken(refreshToken);
            Task<Cliente> clienteTask = _clienteRepository.GetByRefreshToken(refreshToken);

            await Task.WhenAll(tecnicoTask, clienteTask);

            BaseUser? user = tecnicoTask.Result;
            return user ?? clienteTask.Result;
        }

        private async Task<BaseUser?> GetUserByPublicId(Guid publicId)
        {
            Task<Tecnico> tecnicoTask = _tecnicoRepository.GetByPublicId(publicId);
            Task<Cliente> clienteTask = _clienteRepository.GetByPublicId(publicId);

            await Task.WhenAll(tecnicoTask, clienteTask);

            BaseUser? user = tecnicoTask.Result;
            return user ?? clienteTask.Result;
        }

        private async Task<OperationResult<object>> GenerateLoginResponseByRole(BaseUser user)
        {
            switch (user.Role)
            {
                case Role.Tecnico when user is Tecnico tecnico:
                    OperationResult<LoginResponse<TecnicoResponse>> tecnicoResult = await GenerateLoginResponse<TecnicoResponse>(tecnico);
                    return OperationResult<object>.Ok(tecnicoResult.Data);

                case Role.Cliente when user is Cliente cliente:
                    OperationResult<LoginResponse<ClienteResponse>> clienteResult = await GenerateLoginResponse<ClienteResponse>(cliente);
                    return OperationResult<object>.Ok(clienteResult.Data);

                default:
                    return OperationResult<object>.Unauthorized(new MensagemErro("Auth", "Role de usuário inválida para autenticação"));
            }
        }

        private async Task<OperationResult> UpdateUserByRole(BaseUser user)
        {
            switch (user.Role)
            {
                case Role.Tecnico when user is Tecnico tecnico:
                    await _tecnicoRepository.Update(tecnico);
                    return OperationResult.Ok();

                case Role.Cliente when user is Cliente cliente:
                    await _clienteRepository.Update(cliente);
                    return OperationResult.Ok();

                default:
                    return OperationResult.Unauthorized(new MensagemErro("Auth", "Role de usuário inválida para autenticação"));
            }

        }

        private async Task<OperationResult<LoginResponse<TUserResponse>>> GenerateLoginResponse<TUserResponse>(BaseUser user) where TUserResponse : class
        {
            string accessToken = _tokenService.Generate(user);
            string refreshToken = _tokenService.GenerateRefreshToken();

            user.SetRefreshToken(refreshToken);

            OperationResult updateResult = await UpdateUserByRole(user);
            if (!updateResult.Success)
                return OperationResult<LoginResponse<TUserResponse>>.Unauthorized(updateResult.Errors.FirstOrDefault() ?? new MensagemErro("Auth", "Erro ao atualizar usuário"));

            TUserResponse userResponse = _mapper.Map<TUserResponse>(user);

            LoginResponse<TUserResponse> response = new()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddHours(2),
                User = userResponse
            };

            return OperationResult<LoginResponse<TUserResponse>>.Ok(response);
        }
    }
}
