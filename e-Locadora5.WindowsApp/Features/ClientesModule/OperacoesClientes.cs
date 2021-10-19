using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.ClientesModule
{
    public class OperacoesClientes : ICadastravel
    {
        private ClienteAppService clienteAppService = null;
        private TabelaClientesControl tabelaClientes = null;

        public OperacoesClientes(ClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
            tabelaClientes = new TabelaClientesControl(clienteAppService);
        }

        public void InserirNovoRegistro()
        {
            TelaClientesForm tela = new TelaClientesForm();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = clienteAppService.InserirNovo(tela.Cliente);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaClientes.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] inserido com sucesso");
                    Log.Logger.Contexto().Information($"Inserir novo Cliente: [{tela.Cliente.Nome}]");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape(resultado);
                    Log.Logger.Contexto().Warning(resultado);
                }
            }
        }
        public void EditarRegistro()
        {
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Cliente para poder editar!", "Edição de Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cliente clienteSelecionado = clienteAppService.SelecionarPorId(id);

            TelaClientesForm tela = new TelaClientesForm();
            tela.Cliente = clienteSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK)
            {
                string resultado = clienteAppService.Editar(id, tela.Cliente);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaClientes.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] editado com sucesso");
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
            int id = tabelaClientes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Cliente para poder excluir!", "Exclusão de Cliente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cliente clienteSelecionado = clienteAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cliente: [{clienteSelecionado.Nome}] ?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clienteAppService.Excluir(id))
                {
                    tabelaClientes.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{clienteSelecionado.Nome}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: Não foi possível excluir [{clienteSelecionado.Nome}], pois ele está vinculado a um condutor");
                }
            }
        }
        public UserControl ObterTabela()
        {
            tabelaClientes.AtualizarRegistros();

            return tabelaClientes;
        }
        public void FiltrarRegistros()
        {

        }
        public void AgruparRegistros()
        {

        }
        public void DesagruparRegistros()
        {

        }

    }
}
