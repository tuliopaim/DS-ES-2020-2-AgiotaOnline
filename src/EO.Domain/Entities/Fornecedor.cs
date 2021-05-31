namespace EO.Domain.Entities
{
    public class Fornecedor : Entidade
    {
        protected Fornecedor()
        {
        }

        public Fornecedor(decimal capital, int userId)
        {
            Capital = capital;
            UserId = userId;
        }

        public decimal Capital { get; private set; }

        public int UserId { get; private set; }
        public Usuario Usuario { get; set; }

        public void AlterarCapital(decimal novoCapital)
        {
            Capital = novoCapital;
        }
    }
}