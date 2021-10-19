using e_Locadora5.Aplicacao.ClienteModule;
using e_Locadora5.Aplicacao.CondutorModule;
using e_Locadora5.Dominio.CondutoresModule;
using e_Locadora5.Infra.GeradorLogs;
using e_Locadora5.Infra.ORM.ClienteModule;
using e_Locadora5.Infra.ORM.CondutorModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using e_Locadora5.WindowsApp.Shared;
using Serilog;
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
        private CondutorAppService condutorAppService = null;
        private ClienteAppService clienteAppService = null;
        private TabelaCondutorControl tabelaCondutor = null;
    
        public OperacoesCondutores(CondutorAppService condutorAppService, ClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
            this.condutorAppService = condutorAppService;
            tabelaCondutor = new TabelaCondutorControl(condutorAppService);
        }
       
        public void InserirNovoRegistro()
        {
            TelaCondutorForm tela = new TelaCondutorForm(clienteAppService);
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = condutorAppService.InserirNovo(tela.Condutor);

                if (resultado == "ESTA_VALIDO")
                {
                    List<Condutor> condutores = condutorAppService.SelecionarTodos();

                    tabelaCondutor.CarregarTabela(condutores);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{tela.Condutor.Nome}] inserido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
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
            int id = tabelaCondutor.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Condutor para poder editar!", "Edição de Condutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Condutor condutorSelecionado = condutorAppService.SelecionarPorId(id);

            TelaCondutorForm tela = new TelaCondutorForm(clienteAppService);

            tela.Condutor = condutorSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultado = condutorAppService.Editar(id, tela.Condutor);

                if (resultado == "ESTA_VALIDO")
                {
                    List<Condutor> condutores = condutorAppService.SelecionarTodos();

                    tabelaCondutor.CarregarTabela(condutores);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{tela.Condutor.Nome}] editado com sucesso");
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
            int id = tabelaCondutor.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Condutor para poder excluir!", "Exlusão de Condutor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Condutor condutorSelecionado = condutorAppService.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Condutor: [{condutorSelecionado.Nome}] ?",
             "Exclusão de Cliente", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (condutorAppService.Excluir(id))
                {
                    List<Condutor> condutores = condutorAppService.SelecionarTodos();

                    tabelaCondutor.CarregarTabela(condutores);

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Condutor: [{condutorSelecionado.Nome}] removido com sucesso");
                    Log.Logger.Contexto().Information("Funcionalidade Usada");
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
                        condutores = condutorAppService.SelecionarTodos();
                        break;

                    case FlitroCondutoresEnum.CondutoresCnhVencida:
                        {
                            condutores = condutorAppService.SelecionarCondutoresComCnhVencida(DateTime.Now);
                            condutorValidadeCnh = "Vencidas";
                            break;
                        }

                    default:
                        break;
                }
                tabelaCondutor.CarregarTabela(condutores);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutores Com CNH {condutorValidadeCnh}");
                Log.Logger.Contexto().Information("Funcionalidade Usada");
            }
        }

        public UserControl ObterTabela()
        {
            List<Condutor> condutores = condutorAppService.SelecionarTodos(); 

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
