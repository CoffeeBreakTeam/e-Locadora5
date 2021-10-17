using e_Locadora5.Dominio;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DataBuilderTest.LocacaoModule
{
    public class LocacaoDataBuilder
    {
        private Locacao locacao;
        public LocacaoDataBuilder() {
            locacao = new Locacao();
        }
        
        public LocacaoDataBuilder ComMarcadorCombustivel(int marcadorCombustivel)
        {
            locacao.MarcadorCombustivel = (MarcadorCombustivelEnum)marcadorCombustivel;
            return this;
        }

        public LocacaoDataBuilder ComEmAberto(bool emAberto)
        {
            locacao.emAberto = emAberto;
            return this;
        }

        public LocacaoDataBuilder ComPlano(string plano)
        {
            locacao.plano = plano;
            return this;
        }

        public LocacaoDataBuilder ComQuilometragemDevolucao(double quilometragemDevolucao)
        {
            locacao.quilometragemDevolucao = quilometragemDevolucao;
            return this;
        }

        public LocacaoDataBuilder ComSeguroCliente(double seguroCliente)
        {
            locacao.seguroCliente = seguroCliente;
            return this;
        }

        public LocacaoDataBuilder ComSeguroTerceiro(double seguroTerceiro)
        {
            locacao.seguroTerceiro = seguroTerceiro;
            return this;
        }

        public LocacaoDataBuilder ComCaucao(double caucao)
        {
            locacao.caucao = caucao;
            return this;
        }

        public LocacaoDataBuilder ComDataLocacao(DateTime dataLocacao)
        {
            locacao.dataLocacao = dataLocacao;
            return this;
        }

        public LocacaoDataBuilder ComDataDevolucao(DateTime dataDevolucao)
        {
            locacao.dataDevolucao = dataDevolucao;
            return this;
        }

        public LocacaoDataBuilder ComFuncionario(Funcionario funcionario)
        {
            locacao.Funcionario = funcionario;
            locacao.ComFuncionario(funcionario);
            return this;
        }

        public LocacaoDataBuilder ComGrupoVeiculo(GrupoVeiculo grupoVeiculo)
        {
            locacao.GrupoVeiculo = grupoVeiculo;
            locacao.comGrupoVeiculo(grupoVeiculo);
            return this;
        }

        public LocacaoDataBuilder ComVeiculo(Veiculo veiculo)
        {
            locacao.Veiculo = veiculo;
            locacao.comVeiculo(veiculo);
            return this;
        }

        public LocacaoDataBuilder ComCliente(Cliente cliente)
        {
            locacao.Cliente = cliente;
            locacao.ParaCliente(cliente);
            return this;
        }

        public LocacaoDataBuilder ComCondutor(Condutor condutor)
        {
            locacao.Condutor = condutor;
            locacao.comCondutor(condutor);
            return this;
        }

        public LocacaoDataBuilder ComTaxaServico(TaxasServicos taxaServico)
        {
            locacao.TaxasServicos.Add(taxaServico);
            return this;
        }

        public LocacaoDataBuilder ComCupom(Cupom cupom)
        {
            locacao.Cupom = cupom;
            locacao.comCupom(cupom);
            return this;
        }

      

        public Locacao Build()
        {
            return locacao;
        }
    }
}
