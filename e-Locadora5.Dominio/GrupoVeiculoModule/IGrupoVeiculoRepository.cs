using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.GrupoVeiculoModule
{
    public interface IGrupoVeiculoRepository
    {
        public void InserirNovo(GrupoVeiculo registro);

        public void Editar(int id, GrupoVeiculo registro);

        public void Excluir(int id);

        public bool Existe(int id);

        public GrupoVeiculo SelecionarPorId(int id);

        public List<GrupoVeiculo> SelecionarTodos();
    }
}
