using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.LocacaoModule
{
    public interface IRelatorioLocacao
    {
        string GerarRelatorio(Locacao locacao);
    }
}
