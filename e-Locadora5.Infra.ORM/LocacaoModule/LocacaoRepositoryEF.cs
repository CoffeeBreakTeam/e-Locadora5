using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocacaoModule
{
    public class LocacaoRepositoryEF : ILocacaoRepository

    {
        public void Editar(int id, Locacao registro)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public void InserirLocacao(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public void InserirNovo(Locacao registro)
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

        public Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodasLocacoes()
        {
            throw new NotImplementedException();
        }

        public List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            throw new NotImplementedException();
        }
    }
}
