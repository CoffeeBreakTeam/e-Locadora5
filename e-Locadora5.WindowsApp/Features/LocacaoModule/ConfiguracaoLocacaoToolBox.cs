using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Features.LocacaoModule
{
    public class ConfiguracaoLocacaoToolBox: IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro de Locação"; }
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
                Filtrar = true,
                Devolucao = true,
                Email = true
            };
        }

        public ConfiguracaoToolTips ObterToolTips()
        {
            return new ConfiguracaoToolTips()
            {
                Adicionar = "Adicionar uma nova Locação",
                Editar = "Atualizar uma Locação existente",
                Excluir = "Excluir uma Locação existente",
                Filtrar = "Filtrar uma Locação existente",
                Devolucao = "Realizar uma Devolução",
                Email = "Visualizar Emails Pendentes"
            };
        }
    }
}
