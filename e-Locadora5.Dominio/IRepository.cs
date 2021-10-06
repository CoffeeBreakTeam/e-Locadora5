using System;

namespace e_Locadora5.Dominio
{
    public interface IRepository<TEntidadaBase, TKey>
    {
        bool InserirNovo(TEntidadaBase entidadaBase);

        bool Editar(TKey id, TEntidadaBase entidadaBase);

        bool Excluir(int id);

        bool Existe(int id);
    }
}
