using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Features.TaxasServicosModule
{
    public class ConfiguracaoTaxaServicosToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro Taxas e Servicos"; }
        }

        public string ObterDescricao()
        {
            return TipoCadastro;
        }

        public ConfiguracaoEstadoBotoes ObterEstadoBotoes()
        {
            return new ConfiguracaoEstadoBotoes()
            {
                Agrupar = false,
                Desagrupar = false,
                Filtrar = false
            };
        }

        public ConfiguracaoToolTips ObterToolTips()
        {
            return new ConfiguracaoToolTips()
            {
                Adicionar = "Adicionar uma Taxa ou Serviço",
                Editar = "Atualizar uma Taxa ou Serviço",
                Excluir = "Excluir uma Taxa ou Serviço",
                Agrupar = "Agrupar Taxa e Serviço",
                Desagrupar = "Desagrupar Taxa e Serviço"
            };
        }
    }
}
