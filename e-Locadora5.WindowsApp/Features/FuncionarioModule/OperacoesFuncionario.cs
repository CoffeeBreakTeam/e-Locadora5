using e_Locadora5.Controladores.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.FuncionarioModule
{
    public class OperacoesFuncionario : ICadastravel
    {
        private ControladorFuncionario controladorFuncionario = null;
        private TelaFuncionarioControl tabelaFuncionario = null;

        public OperacoesFuncionario(ControladorFuncionario controladorFuncionario)
        {
            this.controladorFuncionario = controladorFuncionario;
            tabelaFuncionario = new TelaFuncionarioControl(controladorFuncionario);
        }

        public void InserirNovoRegistro()
        {
            TelaFuncionarioForm tela = new TelaFuncionarioForm();
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorFuncionario.ValidarFuncionarios(tela.Funcionario) == "ESTA_VALIDO")
            {
                controladorFuncionario.InserirNovo(tela.Funcionario);

                tabelaFuncionario.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder editar!", "Edição de Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Funcionario funcionarioSelecionado = controladorFuncionario.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;
            tela.ShowDialog();
            if (tela.DialogResult == DialogResult.OK && controladorFuncionario.ValidarFuncionarios(tela.Funcionario, id) == "ESTA_VALIDO")
            {
                controladorFuncionario.Editar(id, tela.Funcionario);

                tabelaFuncionario.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder excluir!", "Exclusão de Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Funcionario funcionarioSelecionado = controladorFuncionario.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            if (MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controladorFuncionario.Excluir(id))
                { 

                    tabelaFuncionario.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public UserControl ObterTabela()
        {
            tabelaFuncionario.AtualizarRegistros();

            return tabelaFuncionario;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
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
