using e_Locadora5.Aplicacao.CupomModule;
using e_Locadora5.Aplicacao.LocacaoModule;
using e_Locadora5.Dominio.CupomModule;
using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Infra.SQL.CupomModule;
using e_Locadora5.Infra.SQL.LocacaoModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.CuponsModule
{
    public partial class TelaQuantidadeCupomForms : Form
    {
        CupomAppService controladorCupom = new CupomAppService(new CupomDAO());
        LocacaoAppService controladorLocacao = new LocacaoAppService(new LocacaoDAO());

        public TelaQuantidadeCupomForms()
        {
            InitializeComponent();
            ListarCupons();
        }

        public void ListarCupons()
        {
            List<Locacao> todasLocacoes = controladorLocacao.SelecionarTodos();
            List<Cupons> todosCupons = controladorCupom.SelecionarTodos();

            foreach (Cupons cupom in todosCupons)
            {
                int cupomQuantidadeVezes = 0;
                foreach (Locacao locacao in todasLocacoes)
                {
                    if(locacao.cupom != null)
                        if (locacao.cupom.Equals(cupom))
                            cupomQuantidadeVezes++;
                }
                listBoxCupons.Items.Add("Parceiro: " + cupom.Parceiro +" - " +"Nome " + cupom.Nome + " - " + "Vezes Utilizado: " + cupomQuantidadeVezes);
            }
        }
    }
}
