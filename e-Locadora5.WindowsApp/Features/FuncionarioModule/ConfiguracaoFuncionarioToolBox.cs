using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Features.FuncionarioModule
{
    public class ConfiguracaoFuncionarioToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro 
        {
            get { return "Cadastro de Funcionários"; }
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
                Adicionar = "Adicionar um novo Funcionário",
                Editar = "Atualizar um Funcionário existente",
                Excluir = "Excluir um Funcionário existente",               
            };
        }
    }
}
