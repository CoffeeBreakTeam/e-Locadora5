using e_Locadora5.Aplicacao.FuncionarioModule;
using e_Locadora5.Dominio.FuncionarioModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.FuncionarioModule
{
    public partial class TelaFuncionarioControl : UserControl
    {
        private readonly FuncionarioAppService funcionarioAppService;
        public TelaFuncionarioControl(FuncionarioAppService funcionarioAppService)
        {
            InitializeComponent();
            gridFuncionario.ConfigurarGridZebrado();
            gridFuncionario.ConfigurarGridSomenteLeitura();
            gridFuncionario.Columns.AddRange(ObterColunas());
            this.funcionarioAppService = funcionarioAppService;
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroCpf", HeaderText = "Numero CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Usuario", HeaderText = "Login"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Senha", HeaderText = "Senha de Aceso"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataAdmissao", HeaderText = "Data de Admissão"},

                 new DataGridViewTextBoxColumn {DataPropertyName = "Salario", HeaderText = "Sálario Mensal"}
           };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridFuncionario.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {

            var funcionarios = funcionarioAppService.SelecionarTodos();

            CarregarTbela(funcionarios);

        }

        private void CarregarTbela(List<Funcionario> funcionarios)
        {
            gridFuncionario.DataSource = funcionarios;
        }
    }
}
