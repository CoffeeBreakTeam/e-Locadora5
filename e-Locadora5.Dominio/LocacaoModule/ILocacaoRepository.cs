using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.LocacaoModule
{
    public interface ILocacaoRepository : IReadOnlyRepository<Locacao, int>, IRepository<Locacao, int>
    {   

        public bool ExisteLocacaoComVeiculoRepetido(int id, int idVeiculo);     

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao);

        public List<Locacao> SelecionarLocacoesEmailPendente();

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int id);

        public Locacao SelecionarLocacoesCompleta(int id);

        //LocacaoTaxaServico
        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos();

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao);
    }
}
