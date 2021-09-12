using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Shared
{
    public interface IConfiguracaoToolBox
    {
        string TipoCadastro { get; }
        string ObterDescricao();
        ConfiguracaoToolTips ObterToolTips();
        ConfiguracaoEstadoBotoes ObterEstadoBotoes();

    }
}
