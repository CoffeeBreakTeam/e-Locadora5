using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.GrupoVeiculoModule
{
    public class GrupoVeiculoAppService
    {
        private readonly IGrupoVeiculoRepository grupoVeiculoRepository;

        public GrupoVeiculoAppService(IGrupoVeiculoRepository grupoVeiculoRepository)
        {
            this.grupoVeiculoRepository = grupoVeiculoRepository;
        }

        public string InserirNovo(GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, GrupoVeiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                grupoVeiculoRepository.Editar(id, registro);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                grupoVeiculoRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return grupoVeiculoRepository.Existe(id);
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            return grupoVeiculoRepository.SelecionarPorId(id);
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            return grupoVeiculoRepository.SelecionarTodos();
        }
    }
}
