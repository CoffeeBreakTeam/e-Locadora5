using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.ParceiroModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    public class OperacoesCupons : ICadastravel
    {
        private CupomAppService cupomAppService = null;
        private ParceiroAppService parceiroAppService = null;
        private TabelaCupons tabelaCupons = null;

        public OperacoesCupons(CupomAppService cupomAppService, ParceiroAppService parceiroAppService)
        {
            this.cupomAppService = cupomAppService;
            this.parceiroAppService = parceiroAppService;
            tabelaCupons = new TabelaCupons(cupomAppService);
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaCupons.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cupom para poder editar!", "Edição de Cupom",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupom cupomSelecionado = cupomAppService.SelecionarPorId(id);

            TelaCupomForms tela = new TelaCupomForms(parceiroAppService);

            tela.Cupons = cupomSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = cupomAppService.Editar(id, tela.Cupons);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaCupons.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{tela.Cupons.Nome}] editado com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Warning(resultado);
                }
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaCupons.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um cupom para poder excluir!", "Exclusão de Cupom",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cupom cupons = cupomAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cupom: [{cupons.Nome}] ?",
                "Exclusão de Cupom", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (cupomAppService.Excluir(id))
                {
                    tabelaCupons.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{cupons.Nome}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{cupons.Nome}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaCupomForms tela = new TelaCupomForms(parceiroAppService);
            if (tela.ShowDialog()== DialogResult.OK)
            {
                string resultado = cupomAppService.InserirNovo(tela.Cupons);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaCupons.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cupom: [{tela.Cupons.Nome}] inserido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Warning(resultado);
                }
            }
        }
        public UserControl ObterTabela()
        {
            tabelaCupons.AtualizarRegistros();

            return tabelaCupons;
        }

        public void MostrarClassificacao()
        {
            TelaQuantidadeCupomForms tela = new TelaQuantidadeCupomForms();

            tela.ShowDialog();
        }
    }
}
