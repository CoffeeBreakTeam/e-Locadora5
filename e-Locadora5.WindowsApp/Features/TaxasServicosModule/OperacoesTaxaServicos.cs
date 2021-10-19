using e_Locadora5.Aplicacao.TaxasServicosModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.TaxasServicosModule
{
    public class OperacoesTaxaServicos : ICadastravel
    {
        private TaxasServicosAppService taxasServicosAppService = null;
        private TabelaTaxaServico tabelaTaxaServicos = null;

        public OperacoesTaxaServicos(TaxasServicosAppService taxasServicosAppService)
        {
            this.taxasServicosAppService = taxasServicosAppService;
            tabelaTaxaServicos = new TabelaTaxaServico(taxasServicosAppService);
        }
        public void EditarRegistro()
        {
            int id = tabelaTaxaServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Taxa ou Serviço para poder editar!", "Edição de Taxa ou Serviço",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxasServicos taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);

            TelaTaxaServicosForm tela = new TelaTaxaServicosForm();

            tela.TaxasServicos = taxasServicosSelecionado;

            if (tela.ShowDialog()  == DialogResult.OK)
            {
                var resultado = taxasServicosAppService.Editar(id, tela.TaxasServicos);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaTaxaServicos.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{tela.TaxasServicos.Descricao}] editado com sucesso");

                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Information(resultado);
                }
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaTaxaServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Taxa ou Serviço para poder excluir!", "Exclusão de Taxa ou Serviço",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TaxasServicos taxasServicosSelecionado = taxasServicosAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Taxa ou Serviço: [{taxasServicosSelecionado.Descricao}] ?",
                "Exclusão de Taxa ou Serviço", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (taxasServicosAppService.Excluir(id))
                {
                    tabelaTaxaServicos.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{taxasServicosSelecionado.Descricao}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{taxasServicosSelecionado.Descricao}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            TelaTaxaServicosForm tela = new TelaTaxaServicosForm();

            if (tela.ShowDialog()  == DialogResult.OK)
            {
                var resultado = taxasServicosAppService.InserirNovo(tela.TaxasServicos);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaTaxaServicos.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{tela.TaxasServicos.Descricao}] inserido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Information(resultado);
                }
            }
        }
        public UserControl ObterTabela()
        {
            tabelaTaxaServicos.AtualizarRegistros();

            return tabelaTaxaServicos;
        }
        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
