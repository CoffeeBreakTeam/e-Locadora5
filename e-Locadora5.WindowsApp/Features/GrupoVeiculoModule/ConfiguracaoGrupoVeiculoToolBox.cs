using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.GrupoVeiculoModule
{
    public class ConfiguracaoGrupoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro 
        {
            get { return "Cadastro Grupo de Veiculos"; }
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
                Adicionar = "Adicionar um novo Grupo de Veiculo",
                Editar = "Atualizar um Grupo de Veiculo existente",
                Excluir = "Excluir um Grupo de Veiculo existente"
            };
        }
    }
}
