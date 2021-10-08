using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.Shared;
using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.TaxasServicosModule
{
    public class TaxasServicos : EntidadeBase<int>
    {
        public string Descricao { get; set; }
        public double TaxaFixa { get; set; }
        public double TaxaDiaria { get; set; }

        public ICollection<Locacao> locacoes { get; set; }

        public TaxasServicos() { }

        public TaxasServicos(string descricao, double taxaFixa, double taxaDiaria)
        {
            Descricao = descricao;
            TaxaFixa = taxaFixa;
            TaxaDiaria = taxaDiaria;    
        }

        public override string ToString()
        {
            return Descricao;
        }
        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Descricao))
                resultadoValidacao += "O campo descrição é obrigatório e não pode ser vazio.";

            if (TaxaFixa < 0 )
                resultadoValidacao += "Taxa Fixa não pode ser menor que Zero.";

            if (TaxaDiaria < 0 )
                resultadoValidacao += "Taxa Diaria não pode ser Menor que Zero.";

            if (TaxaFixa == 0 && TaxaDiaria <= 0)
                resultadoValidacao += "Taxa Diaria não pode ser Menor que Zero.";

            if (TaxaDiaria == 0 && TaxaFixa <= 0)
                resultadoValidacao += "Taxa Diaria não pode ser Menor que Zero.";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TaxasServicos);
        }
        public bool Equals(TaxasServicos other)
        {
                   return other != null &&
                   Descricao == other.Descricao &&
                   TaxaFixa == other.TaxaFixa &&
                   TaxaDiaria == other.TaxaDiaria;
        }

        public override int GetHashCode()
        {
            int hashCode = -44572661;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Descricao);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(TaxaFixa);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(TaxaDiaria);
            return hashCode;
        }
    }
}
