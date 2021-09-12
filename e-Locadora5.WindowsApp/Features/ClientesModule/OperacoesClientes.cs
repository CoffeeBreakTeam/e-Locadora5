using e_Locadora5.Controladores.ClientesModule;
using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.WindowsApp.Shared;
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
        private ControladorClientes controlador = null;
        private TabelaClientesControl tabelaClientes = null;

        public OperacoesClientes(ControladorClientes controlador)
        {
            this.controlador = controlador;
            tabelaClientes = new TabelaClientesControl(controlador);
        }

        public void InserirNovoRegistro()
        {
            TelaClientesForm tela = new TelaClientesForm();
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controlador.ValidarClientes(tela.Cliente) == "ESTA_VALIDO")
            {
                controlador.InserirNovo(tela.Cliente);

                tabelaClientes.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] inserido com sucesso");
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

            Clientes clienteSelecionado = controlador.SelecionarPorId(id);

            TelaClientesForm tela = new TelaClientesForm();

            tela.Cliente = clienteSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controlador.ValidarClientes(tela.Cliente, id) == "ESTA_VALIDO")
            {
                controlador.Editar(id, tela.Cliente);

                tabelaClientes.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{tela.Cliente.Nome}] editado com sucesso");
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

            Clientes clienteSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Cliente: [{clienteSelecionado.Nome}] ?",
                "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controlador.Excluir(id))
                {
                    tabelaClientes.AtualizarRegistros();
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Cliente: [{clienteSelecionado.Nome}] removido com sucesso");
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
