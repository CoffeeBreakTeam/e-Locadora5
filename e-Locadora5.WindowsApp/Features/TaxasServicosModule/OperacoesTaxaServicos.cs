using e_Locadora5.Controladores.TaxasServicoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.WindowsApp.Shared;
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
        private ControladorTaxasServicos controlador = null;
        private TabelaTaxaServico tabelaTaxaServicos = null;

        public OperacoesTaxaServicos(ControladorTaxasServicos controlador)
        {
            this.controlador = controlador;
            tabelaTaxaServicos = new TabelaTaxaServico(controlador);
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

            TaxasServicos taxasServicosSelecionado = controlador.SelecionarPorId(id);

            TelaTaxaServicosForm tela = new TelaTaxaServicosForm();

            tela.TaxasServicos = taxasServicosSelecionado;

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                controlador.Editar(id, tela.TaxasServicos);

                tabelaTaxaServicos.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{tela.TaxasServicos.Descricao}] editado com sucesso");
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

            TaxasServicos taxasServicosSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Taxa ou Serviço: [{taxasServicosSelecionado.Descricao}] ?",
                "Exclusão de Taxa ou Serviço", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (controlador.Excluir(id))
                {
                    tabelaTaxaServicos.AtualizarRegistros();

                    TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{taxasServicosSelecionado.Descricao}] removido com sucesso");
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

            tela.ShowDialog();
            if (tela.ValidarCampos() == "CAMPOS_VALIDOS" && tela.DialogResult == DialogResult.OK)
            {
                controlador.InserirNovo(tela.TaxasServicos);

                tabelaTaxaServicos.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Taxa ou Serviço: [{tela.TaxasServicos.Descricao}] inserido com sucesso");
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
