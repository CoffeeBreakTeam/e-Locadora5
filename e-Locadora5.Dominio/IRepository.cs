using System;

namespace e_Locadora5.Dominio
{
    public interface IRepository<TEntidadaBase, TKey>
    {
        bool InserirNovo(TEntidadaBase entidadeBase);

        bool Editar(int id, TEntidadaBase entidadeBase);

        bool Excluir(int id);

        bool Existe(int id);
    }
}
