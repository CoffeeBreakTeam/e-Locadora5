using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.VeiculosModule
{
    public struct Combustivel
    {
        private CombustivelEnum combustivel;

        public Combustivel(CombustivelEnum combustivel)
        {
            this.combustivel = combustivel;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
