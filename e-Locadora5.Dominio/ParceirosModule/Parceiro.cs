using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ParceirosModule
{
    public class Parceiro : EntidadeBase<int>
    {
        public string Nome { get; set; }

        public Parceiro(string parceiro)
        {
            this.Nome = parceiro;
        }

        public List<Cupom> Cupons { get; set; }

        public Parceiro()
        {
        }

        public override string Validar()
        {
            string resultadoValidacao = "";
            if(string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O Nome do Parceiro é obrigatório .";
            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parceiro);
        }

        public bool Equals(Parceiro other)
        {
            return other!=null &&
                   Id == other.Id &&
                   Nome == other.Nome;
        }
        public override string ToString()
        {
            return Nome;
        }
        public override int GetHashCode()
        {
            int hashCode = 2069752152;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            return hashCode;
        }
    }
}
