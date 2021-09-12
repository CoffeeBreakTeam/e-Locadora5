using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Features.ConfiguracoesCombustivel
{
    public class ConfiguracaoCombustivelToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro 
        {
            get { return "Cadastro de Preço de Combustível"; }
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
                Filtrar = false,
                Editar = false,
                Excluir = false,
                Adicionar = false
            };
        }

        public ConfiguracaoToolTips ObterToolTips()
        {
            return new ConfiguracaoToolTips()
            {
                            
            };
        }
    }
}
