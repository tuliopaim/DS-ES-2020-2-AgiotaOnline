namespace EO.Domain.Entities
{
    public class Endereco : Entidade
    {
        protected Endereco()
        {
        }

        public Endereco(
            string cep,
            string logradouro,
            string rua,
            string bairro,
            string cidade,
            string estado,
            string pais)
        {
            Cep = cep;
            Logradouro = logradouro;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Pais { get; private set; }

        public void AlterarCep(string novoCep)
        {
            Cep = novoCep;
        }
        public void AlterarLogradouro(string novoLogradouro)
        {
            Logradouro = novoLogradouro;
        }
        public void AlterarRua(string novoRua)
        {
            Rua = novoRua;
        }
        public void AlterarBairro(string novoBairro)
        {
            Bairro = novoBairro;
        }
        public void AlterarCidade(string novoCidade)
        {
            Cidade = novoCidade;
        }
        public void AlterarEstado(string novoEstado)
        {
            Estado = novoEstado;
        }
        public void AlterarPais(string novoPais)
        {
            Pais = novoPais;
        }
    }
}