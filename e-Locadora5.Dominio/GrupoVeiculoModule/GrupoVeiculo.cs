using e_Locadora5.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio
{
    public class GrupoVeiculo : EntidadeBase<int>
    {

        public string categoria { get; set; }
        public double planoDiarioValorKm { get; set; }
        public double planoDiarioValorDiario { get; set; }
        public double planoKmControladoValorKm { get; set; }
        public double planoKmControladoQuantidadeKm { get; set; }
        public double planoKmControladoValorDiario { get; set; }
        public double planoKmLivreValorDiario { get; set; }

        public GrupoVeiculo() { }
        public GrupoVeiculo(string categoria, double planoDiarioValorKm, double planoDiarioValorDiario, double planoKmControladoValorKm, double planoKmControladoQuantidadeKm, double planoKmControladoValorDiario, double planoKmLivreValorDiario)
        {
            this.categoria = categoria;
            this.planoDiarioValorKm = planoDiarioValorKm;
            this.planoDiarioValorDiario = planoDiarioValorDiario;
            this.planoKmControladoValorKm = planoKmControladoValorKm;
            this.planoKmControladoValorDiario = planoKmControladoValorDiario;
            this.planoKmLivreValorDiario = planoKmLivreValorDiario;
            this.planoKmControladoQuantidadeKm = planoKmControladoQuantidadeKm;
        }

        public override string ToString()
        {
            return categoria;
        }

        public override string Validar() {
            string resultadoValidacao = "";
            if (string.IsNullOrEmpty(categoria))
                resultadoValidacao = "O atributo categoria é obrigatório e não pode ser vazio.";
            if (planoDiarioValorKm <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoDiarioValorKm deve ser maior que zero.";
            if (planoDiarioValorDiario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoDiarioValorDiario deve ser maior que zero.";
            if (planoKmControladoValorKm <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoKmControladoValorKm deve ser maior que zero.";
            if (planoKmControladoQuantidadeKm <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoKmControladoQuantidadeKm deve ser maior que zero.";
            if (planoKmControladoValorDiario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoKmControladoValorDiario deve ser maior que zero.";
            if (planoKmLivreValorDiario <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo planoKmLivreValorDiario deve ser maior que zero.";
            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GrupoVeiculo);
        }

        public bool Equals(GrupoVeiculo other)
        {
            return other != null
                && Id == other.Id
                && categoria == other.categoria
                && planoDiarioValorDiario == other.planoDiarioValorDiario
                && planoDiarioValorKm == other.planoDiarioValorKm
                && planoKmControladoValorDiario == other.planoKmControladoValorDiario
                && planoKmControladoValorKm == other.planoKmControladoValorKm
                && planoKmControladoQuantidadeKm == other.planoKmControladoQuantidadeKm
                && planoKmLivreValorDiario == other.planoKmLivreValorDiario;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
