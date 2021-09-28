using e_Locadora5.Dominio;
using e_Locadora5.Dominio.GrupoVeiculoModule;
using Serilog;
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

            try
            {
                string resultadoValidacao = registro.Validar();

                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    grupoVeiculoRepository.InserirNovo(registro);
                    Log.Information("Grupo de veiculo {@grupo} foi inserido com sucesso.", registro);
                    return "ESTA_VALIDO";
                }
                else
                {
                    Log.Warning("Grupo de veiculo {@grupo} inválida: {@resultadoValidacao}", registro, resultadoValidacao);
                    return resultadoValidacao;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível inserir o grupo {@grupo}", registro);
                return "Não foi possível inserir o grupo de veículo";
            }

        }

        public string Editar(int id, GrupoVeiculo registro)
        {
            try
            {
                string resultadoValidacao = registro.Validar();


                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    grupoVeiculoRepository.Editar(id, registro);
                    Log.Information("Grupo {@grupo} foi editado com sucesso.", registro);
                    return "ESTA_VALIDO";
                }

                else
                {
                    Log.Warning("Grupo {@grupo} inválida: {@resultadoValidacao}", registro, resultadoValidacao);
                    return resultadoValidacao;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível editar a grupo {@grupo}", registro);
                return "Não foi possível editar o grupo";
            }


        }

        public bool Excluir(int id)
        {
            try
            {
                grupoVeiculoRepository.Excluir(id);
                Log.Information("TaxaServico de id {@id} foi excluído com sucesso", id);
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível excluir o grupo com id {@id}", id);
                return false;
            }
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = grupoVeiculoRepository.Existe(id);
                Log.Information("Verificado se existe o grupo com id {@id}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível verificar se existe o grupo com id {@id}", id);
                return false;
            }
        }

        public GrupoVeiculo SelecionarPorId(int id)
        {
            try
            {
                GrupoVeiculo grupoSelecionado = grupoVeiculoRepository.SelecionarPorId(id);
                Log.Information("Selecionado grupo {@grupo}", grupoSelecionado);
                return grupoSelecionado;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar o grupo com id {@id}", id);
                return null;
            }
        }

        public List<GrupoVeiculo> SelecionarTodos()
        {
            try
            {
                List<GrupoVeiculo> listaGrupos = grupoVeiculoRepository.SelecionarTodos();
                Log.Information("Selecionado todas os grupos {@todos}", listaGrupos);
                return listaGrupos;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Não foi possível selecionar todos os grupos");
                return null;
            }
        }
    }
}
