namespace Domain.models
{
    public class HorarioDisponibilidade
    {
        public DayOfWeek Dia { get; private set; }
        public TimeSpan Inicio { get; private set; }
        public TimeSpan Fim { get; private set; }

        protected HorarioDisponibilidade() { }

        private HorarioDisponibilidade(DayOfWeek dia, TimeSpan inicio, TimeSpan fim)
        {
            Dia = dia;
            Inicio = inicio;
            Fim = fim;
        }

        // Factory que evita lançar exceções (segue a preferência por OperationResult-style)
        public static (bool Success, string ? Error, HorarioDisponibilidade ? Value) Create(DayOfWeek dia, TimeSpan inicio, TimeSpan fim)
        {
            if (inicio >= fim) return (false, "Horario inválido: início deve ser anterior ao fim.", null);

            return (true, null, new HorarioDisponibilidade(dia, inicio, fim));
        }

        public bool Overlaps(HorarioDisponibilidade other)
        {
            if (other == null) return false;

            if (other.Dia != Dia) return false;

            return Inicio < other.Fim && other.Inicio < Fim;
        }
    }
}