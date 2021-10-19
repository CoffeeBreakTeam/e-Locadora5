using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
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
        private FuncionarioAppService funcionarioAppService = null;
        private TelaFuncionarioControl tabelaFuncionario = null;

        public OperacoesFuncionario(FuncionarioAppService funcionarioAppService)
        {
            this.funcionarioAppService = funcionarioAppService;
            tabelaFuncionario = new TelaFuncionarioControl(funcionarioAppService);
        }

        public void InserirNovoRegistro()
        {
            TelaFuncionarioForm tela = new TelaFuncionarioForm();
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                if (funcionarioAppService.InserirNovo(tela.Funcionario) == "ESTA_VALIDO")
                {
                    tabelaFuncionario.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] inserido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
                }
                else
                {
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Não foi possível inserir funcionário");
                    Log.Logger.Contexto().Information("Não foi possível inserir funcionário");
                }           
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
            Funcionario funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = funcionarioAppService.Editar(id, tela.Funcionario);

                if (resultado == "ESTA_VALIDO")
                {
                    tabelaFuncionario.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Nome}] editado com sucesso");
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
            int id = tabelaFuncionario.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder excluir!", "Exclusão de Funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Funcionario funcionarioSelecionado = funcionarioAppService.SelecionarPorId(id);

            TelaFuncionarioForm tela = new TelaFuncionarioForm();

            if (MessageBox.Show($"Tem certeza que deseja excluir o Funcionário: [{funcionarioSelecionado.Nome}] ?",
                "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (funcionarioAppService.Excluir(id))
                { 

                    tabelaFuncionario.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Nome}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
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
