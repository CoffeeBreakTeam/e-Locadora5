using e_Locadora5.Dominio.VeiculosModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.VeiculoModule
{
    class VeiculoRepositoryEF : IVeiculoRepository
    {
        public void Editar(int id, Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Existe(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteVeiculoComEssaPlaca(string placa)
        {
            throw new NotImplementedException();
        }

        public void InserirNovo(Veiculo registro)
        {
            throw new NotImplementedException();
        }

        public Veiculo SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Veiculo> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
