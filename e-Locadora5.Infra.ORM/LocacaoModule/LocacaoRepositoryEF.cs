using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocacaoModule
{
    public class LocacaoRepositoryEF : RepositoryBase<Locacao, int>, ILocacaoRepository

    {
        public LocacaoRepositoryEF(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
        }

        public bool ExisteLocacaoComVeiculoRepetido(int id, int idVeiculo)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            throw new NotImplementedException();
        }
    }
}
