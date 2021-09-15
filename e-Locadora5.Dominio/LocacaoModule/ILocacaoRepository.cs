using e_Locadora5.Dominio.TaxasServicosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.LocacaoModule
{
    public interface ILocacaoRepository
    {
        public void InserirNovo(Locacao registro);

        public void Editar(int id, Locacao registro);

        public void Excluir(int id);

        public bool Existe(int id);

        public Locacao SelecionarPorId(int id);

        public List<Locacao> SelecionarTodos();

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao);

        public List<Locacao> SelecionarLocacoesEmailPendente();



        //LocacaoTaxaServico
        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos();

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao);
    }
}
