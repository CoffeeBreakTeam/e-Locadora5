using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.Shared;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.LocacaoModule
{
    public class Locacao : EntidadeBase<int>
    {
        
        public DateTime dataLocacao { get; set; }
        public DateTime dataDevolucao { get; set; }
        public double quilometragemDevolucao { get; set; }
        public string plano { get; set; }
        public double seguroCliente { get; set; }
        public double seguroTerceiro { get; set; }
        public double caucao { get; set; }
        public Funcionario funcionario { get; set; }
        public GrupoVeiculo grupoVeiculo { get; set; }
        public Veiculo veiculo { get; set; }
        public Clientes cliente { get; set; }
        public Condutor condutor { get; set; }
        
        public Cupons cupom { get; set; }

        public List<TaxasServicos> taxasServicos { get; set; }
        public bool emAberto { get; set; }

        public double valorTotal { get; set; }

        public bool emailEnviado { get; set; }

        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        public Locacao(Funcionario funcionario, DateTime dataLocacao, DateTime dataDevolucao, double quilometragemDevolucao, string plano, double seguroCliente, double seguroTerceiro, double caucao, GrupoVeiculo grupoVeiculo, Veiculo veiculo, Clientes cliente, Condutor condutor, bool emAberto)
        {
            this.funcionario = funcionario;
            this.dataLocacao = dataLocacao;
            this.dataDevolucao = dataDevolucao;
            this.quilometragemDevolucao = quilometragemDevolucao;
            this.plano = plano;
            this.seguroCliente = seguroCliente;
            this.seguroTerceiro = seguroTerceiro;
            this.caucao = caucao;
            this.grupoVeiculo = grupoVeiculo;
            this.veiculo = veiculo;
            this.cliente = cliente;
            this.condutor = condutor;
            this.emAberto = emAberto;
            this.taxasServicos = new List<TaxasServicos>();
            emailEnviado = false;
        }

        public Locacao()
        {
            this.taxasServicos = new List<TaxasServicos>();
        }

        public override string ToString()
        {
            return "Cliente: " + cliente + "Veiculo: " + veiculo;
        }

        public void FinalizarLocacao() {
            emAberto = false;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (caucao < 0)
                resultadoValidacao += "Caução não pode ser negativo";
            if (seguroCliente < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Seguro do cliente não pode ser negativo";
            if (seguroTerceiro < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Seguro de terceiros não pode ser negativo";
            if (quilometragemDevolucao < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Quilometragem não pode ser negativo!";
            if (funcionario == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um funcionário";

            if (condutor == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um condutor";

            if (veiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um veículo";

            if (veiculo != null && veiculo.EstaAlugado())
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Este veículo já esta alugado";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public string ValidarDevolucao() {
            string resultadoValidacao = "";
            if (quilometragemDevolucao < veiculo.Quilometragem)
            {
                return "Quilometragem Atual não pode ser menor que a quilometragem inicial!";
            }
            if (dataDevolucao <= dataLocacao)
            {
                return "Data de Retorno Atual não pode ser menor ou igual a data da Locação!";
            }

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Locacao);
        }

        public bool Equals(Locacao other)
        {
            return other != null
                && Id == other.Id
                && funcionario.Equals(other.funcionario)
                && dataLocacao == other.dataLocacao
                && dataDevolucao == other.dataDevolucao
                && quilometragemDevolucao == other.quilometragemDevolucao
                && plano == other.plano
                && grupoVeiculo.Equals(grupoVeiculo)
                && veiculo.Equals(veiculo)
                && cliente.Equals(other.cliente)
                && condutor.Equals(other.condutor)
                && emAberto == other.emAberto;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        private int QuantidadeDeDias
        {
            get
            {
                int qtdDiasLocacao;

                if (dataDevolucao == DateTime.MinValue)
                    qtdDiasLocacao = (dataDevolucao - dataLocacao).Days;
                else
                    qtdDiasLocacao = (dataDevolucao - dataLocacao).Days;

                return qtdDiasLocacao;
            }
        }
        public double CalcularValorPlano()
        {
            GrupoVeiculo grupoVeiculoSelecionado = grupoVeiculo;
            string planoSelecionado = plano;
            double valorPlano = 0;

            if (grupoVeiculoSelecionado != null && planoSelecionado != "")
            {
                if (planoSelecionado == "Diário")
                {
                    double valorDiario = grupoVeiculoSelecionado.planoDiarioValorDiario * QuantidadeDeDias;
                    valorPlano = valorDiario;
                }
                else if (planoSelecionado == "Km Controlado")
                {
                    double valorDiario = grupoVeiculoSelecionado.planoKmControladoValorDiario * QuantidadeDeDias;
                    double valorKm = grupoVeiculoSelecionado.planoKmControladoValorKm * grupoVeiculoSelecionado.planoKmControladoQuantidadeKm;
                    valorPlano = valorDiario + valorKm;
                }
                else if (planoSelecionado == "Km Livre")
                {
                    double valorDiario = grupoVeiculoSelecionado.planoKmLivreValorDiario * QuantidadeDeDias;
                    valorPlano = valorDiario;
                }
            }
            return valorPlano;
        }
        public double CalcularValorTaxas()
        {
            List<TaxasServicos> taxasServicosSelecionadas = taxasServicos;
            double valorTaxasServicos = 0;

            foreach (TaxasServicos taxasServicos in taxasServicosSelecionadas)
            {
                TaxasServicos taxaServico = taxasServicos;
                valorTaxasServicos += (taxaServico.TaxaDiaria * QuantidadeDeDias + taxaServico.TaxaFixa);
            }

            return valorTaxasServicos;
        }

        private bool TemCupons()
        {
            return cupom != null;
        }
        public void estaHáFinalizarLocacao()
        {
            emAberto = false;
        }

        public double CalcularValorLocacao(double precoCombustivel = 0)
        {
            double valorPlano = 0;
            if (plano != null)
                valorPlano = CalcularValorPlano();

            double valorTaxas = 0;
            if (taxasServicos != null)
                valorTaxas = CalcularValorTaxas();

            double valorCombustivel = 0;
            if (veiculo != null)
                valorCombustivel = veiculo.QuantidadeDeListrosParaAbastecer(MarcadorCombustivel) * precoCombustivel;

            double valorTotal = valorPlano + valorCombustivel + valorTaxas;
            if (TemCupons())
                if(cupom.ValorMinimo <= valorTotal) 
                    valorTotal -= cupom.CalcularDesconto(valorTotal);

            return valorTotal;
        }
        public void AlugarVeiculo(Veiculo Veiculo)
        {
            veiculo = Veiculo;

            Veiculo.RegistrarLocacao(this);
        }
    }
}
