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

        public int FuncionarioId { get; set; }
        public int ClienteId { get; set; }
        public int GrupoVeiculoId { get; set; }
        public int VeiculoId { get; set; }
        public int CondutorId { get; set; }
        public Nullable<int> CupomId { get; set; }

        public Funcionario Funcionario { get; set; }
        public GrupoVeiculo GrupoVeiculo { get; set; }
        public Veiculo Veiculo { get; set; }
        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }       
        public Cupom Cupom { get; set; }

        public void ParaCliente(Cliente cliente)
        {
            ClienteId = cliente.Id;
        }
        public void ComFuncionario(Funcionario funcionario)
        {
            FuncionarioId = funcionario.Id;
        }
        public void comVeiculo(Veiculo veiculo)
        {
            VeiculoId = veiculo.Id;
        }
        public void comCupom(Cupom cupom)
        {
            if (cupom != null)
            {
                CupomId = cupom.Id;
            }          
            
        }
        public void comGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            GrupoVeiculoId  = grupoVeiculo.Id;
        }
        public void comCondutor(Condutor condutor)
        {
            CondutorId = condutor.Id;
        }


        public List<TaxasServicos> TaxasServicos
        { get; set; }
        public bool emAberto { get; set; }

        public double valorTotal { get; set; }

        public bool emailEnviado { get; set; }

        public MarcadorCombustivelEnum MarcadorCombustivel { get; set; }

        public Locacao(Funcionario funcionario, DateTime dataLocacao, DateTime dataDevolucao, double quilometragemDevolucao, string plano, double seguroCliente, double seguroTerceiro, double caucao, GrupoVeiculo grupoVeiculo, Veiculo veiculo, Cliente cliente, Condutor condutor, bool emAberto, Cupom cupom)
        {
            this.Funcionario = funcionario;
            this.dataLocacao = dataLocacao;
            this.dataDevolucao = dataDevolucao;
            this.quilometragemDevolucao = quilometragemDevolucao;
            this.plano = plano;
            this.seguroCliente = seguroCliente;
            this.seguroTerceiro = seguroTerceiro;
            this.caucao = caucao;
            this.GrupoVeiculo = grupoVeiculo;
            this.Veiculo = veiculo;
            this.Cliente = cliente;
            this.Condutor = condutor;
            this.emAberto = emAberto;
            this.TaxasServicos = new List<TaxasServicos>();
            emailEnviado = false;
            ClienteId = cliente.Id;
            VeiculoId = Veiculo.Id;
            GrupoVeiculoId = grupoVeiculo.Id;
            FuncionarioId = funcionario.Id;
            CondutorId = condutor.Id;

            if (cupom != null)
            {
                CupomId = cupom.Id;
            }
            
        }

        public Locacao(Funcionario funcionario, DateTime dataLocacao, DateTime dataDevolucao, double quilometragemDevolucao, string plano, double seguroCliente, double seguroTerceiro, double caucao, GrupoVeiculo grupoVeiculo, Veiculo veiculo, Cliente cliente, Condutor condutor, bool emAberto, Cupom cupom, List<TaxasServicos> taxasServicos)
        {
            this.Funcionario = funcionario;
            this.dataLocacao = dataLocacao;
            this.dataDevolucao = dataDevolucao;
            this.quilometragemDevolucao = quilometragemDevolucao;
            this.plano = plano;
            this.seguroCliente = seguroCliente;
            this.seguroTerceiro = seguroTerceiro;
            this.caucao = caucao;
            this.GrupoVeiculo = grupoVeiculo;
            this.Veiculo = veiculo;
            this.Cliente = cliente;
            this.Condutor = condutor;
            this.emAberto = emAberto;
            this.TaxasServicos = taxasServicos;
            emailEnviado = false;
            ClienteId = cliente.Id;
            VeiculoId = Veiculo.Id;
            GrupoVeiculoId = grupoVeiculo.Id;
            FuncionarioId = funcionario.Id;
            CondutorId = condutor.Id;

            if (cupom != null)
            {
                CupomId = cupom.Id;
            }

        }

        public Locacao()
        {
            CupomId = null;
            this.TaxasServicos = new List<TaxasServicos>();
        }

        public override string ToString()
        {
            return "Cliente: " + Cliente + "Veiculo: " + Veiculo;
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
            if (Funcionario == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um funcionário";

            if (Condutor == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um condutor";

            if (Veiculo == null)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Selecione um veículo";

            //if (Veiculo != null && Veiculo.EstaAlugado())
            //    resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "Este veículo já esta alugado";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public string ValidarDevolucao() {
            string resultadoValidacao = "";
            if (quilometragemDevolucao < Veiculo.Quilometragem)
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
                && Funcionario.Equals(other.Funcionario)
                && dataLocacao == other.dataLocacao
                && dataDevolucao == other.dataDevolucao
                && quilometragemDevolucao == other.quilometragemDevolucao
                && plano == other.plano
                && GrupoVeiculo.Equals(GrupoVeiculo)
                && Veiculo.Equals(Veiculo)
                && Cliente.Equals(other.Cliente)
                && Condutor.Equals(other.Condutor)
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
            GrupoVeiculo grupoVeiculoSelecionado = GrupoVeiculo;
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
            List<TaxasServicos> taxasServicosSelecionadas = TaxasServicos;
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
            return Cupom != null;
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
            if (TaxasServicos != null)
                valorTaxas = CalcularValorTaxas();

            double valorCombustivel = 0;
            if (Veiculo != null)
                valorCombustivel = Veiculo.QuantidadeDeListrosParaAbastecer(MarcadorCombustivel) * precoCombustivel;

            double valorTotal = valorPlano + valorCombustivel + valorTaxas;
            if (TemCupons())
                if(Cupom.ValorMinimo <= valorTotal) 
                    valorTotal -= Cupom.CalcularDesconto(valorTotal);

            return valorTotal;
        }
        public void AlugarVeiculo(Veiculo Veiculo)
        {
            this.Veiculo = Veiculo;

            Veiculo.RegistrarLocacao(this);
        }
    }
}
