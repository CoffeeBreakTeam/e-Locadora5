using e_Locadora5.Controladores.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.CondutorModule
{
    public class OperacoesCondutores : ICadastravel
    {
        private ControladorCondutor controlador = null;
        private TabelaCondutorControl tabelaCondutor = null;

        public OperacoesCondutores(ControladorCondutor controlador)
        {
            this.controlador = controlador;
            tabelaCondutor = new TabelaCondutorControl(controlador);
        }

        public void InserirNovoRegistro()
        {
            TelaCondutorForm tela = new TelaCondutorForm();


            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Condutor);

                List<Condutor> condutores = controlador.SelecionarTodos();

                tabelaCondutor.CarregarTabela(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{tela.Condutor.Nome}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaCondutor.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Condutor para poder editar!", "Edição de Condutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Condutor condutorSelecionado = controlador.SelecionarPorId(id);

            TelaCondutorForm tela = new TelaCondutorForm();

            tela.Condutor = condutorSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Condutor);

                List<Condutor> condutores = controlador.SelecionarTodos();

                tabelaCondutor.CarregarTabela(condutores);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{tela.Condutor.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaCondutor.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Condutor para poder excluir!", "Exlusão de Condutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Condutor condutorSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Condutor: [{condutorSelecionado.Nome}] ?",
             "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controlador.Excluir(id))
                {
                    List<Condutor> condutores = controlador.SelecionarTodos();

                    tabelaCondutor.CarregarTabela(condutores);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{condutorSelecionado.Nome}] removido com sucesso");
                }
                else
                    TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{condutorSelecionado.Nome}] não pode ser removido, pois está vinculado a uma locação");
            }
        }

        public void FiltrarRegistros()
        {
            FiltroCondutoresForm telaFiltro = new FiltroCondutoresForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Condutor> condutores = new List<Condutor>();

                string condutorValidadeCnh = "";

                switch (telaFiltro.TipoFiltro)
                {
                    case FlitroCondutoresEnum.TodosCondutores:
                        condutores = controlador.SelecionarTodos();
                        break;

                    case FlitroCondutoresEnum.CondutoresCnhVencida:
                        {
                            condutores = controlador.SelecionarCondutoresComCnhVencida(DateTime.Now);
                            condutorValidadeCnh = "Vencidas";
                            break;
                        }

                    default:
                        break;
                }
                tabelaCondutor.CarregarTabela(condutores);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutores Com CNH {condutorValidadeCnh}");
            }
        }

        public UserControl ObterTabela()
        {
            List<Condutor> condutores = controlador.SelecionarTodos(); 

            tabelaCondutor.CarregarTabela(condutores);

            return tabelaCondutor;
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
