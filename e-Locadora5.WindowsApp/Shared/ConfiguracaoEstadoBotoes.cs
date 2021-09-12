using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.WindowsApp.Shared
{

    public class ConfiguracaoEstadoBotoes
    {
        public ConfiguracaoEstadoBotoes()
        {
            Adicionar = true;
            Editar = true;
            Excluir = true;
            Devolucao = false;
            Classificacao = false;
            Email = false;
        }

        public bool Adicionar { get; internal set; }
        public bool Editar { get; internal set; }
        public bool Excluir { get; internal set; }
        public bool Agrupar { get; internal set; }
        public bool Desagrupar { get; internal set; }
        public bool Filtrar { get; internal set; }
        public bool Devolucao { get; internal set; }
        public bool Classificacao { get; internal set; }
        public bool Email { get; internal set; }
    }
}
