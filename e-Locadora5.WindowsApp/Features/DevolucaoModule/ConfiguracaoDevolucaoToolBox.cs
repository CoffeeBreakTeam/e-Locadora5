using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Features.DevolucaoModule
{
    public class ConfiguracaoDevolucaoToolBox: IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro de Devolução"; }
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
                Adicionar = "Adicionar uma nova Devolução",
                Editar = "Atualizar uma Devolução existente",
                Excluir = "Excluir uma Devolução existente"
            };
        }
    }
}
