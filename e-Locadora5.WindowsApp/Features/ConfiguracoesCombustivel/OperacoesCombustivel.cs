using e_Locadora5.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Locadora5.WindowsApp.Features.ConfiguracoesCombustivel
{
     class OperacoesCombustivel : ICadastravel
    {
        private readonly TabelaCombustivelControl combustivelControl = null;
        public OperacoesCombustivel()
        {
            combustivelControl = new TabelaCombustivelControl();
        }
        public UserControl ObterTabela()
        {
            combustivelControl.CarregarConfiguracoes();
            return combustivelControl;
        }
        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void DesagruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            throw new NotImplementedException();
        }

        public void ExcluirRegistro()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            throw new NotImplementedException();
        }

 
    }
}
