using System;

namespace EO.Domain.Entities
{
    public class Entidade
    {
        public Entidade()
        {
            DataCriacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public virtual bool EhValido()
        {
            return true;
        }
    }
}