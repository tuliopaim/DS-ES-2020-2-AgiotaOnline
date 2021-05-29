namespace EO.Domain.Entities
{
    public class Tomador : Entidade
    {
        protected Tomador()
        {
        }

        public Tomador(decimal rendaMensal, int userId)
        {
            RendaMensal = rendaMensal;
            UserId = userId;
        }

        public decimal RendaMensal { get; private set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public int UserId { get; private set; }
        public User User { get; set; }

        public void AlterarRendaMensal(decimal novaRenda)
        {
            RendaMensal = novaRenda;
        }
    }
}