using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
using System;
using System.Collections.Generic;

namespace e_Locadora5.Aplicacao.VeiculoModule
{
    public class VeiculoAppService
    {
        private readonly IVeiculoRepository veiculoRepository;

        public VeiculoAppService(IVeiculoRepository veiculoRepository)
        {
            this.veiculoRepository = veiculoRepository;
        }
        public string InserirNovo(Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if(veiculoRepository.ExisteVeiculoComEssaPlaca(registro.Placa))
            {
                Log.Logger.Contexto().Warning("Já há um veiculo cadastrado com esta placa {@placa}", registro.Placa);
                resultadoValidacao = "Placa já cadastrada, tente novamente.";
            }

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    veiculoRepository.InserirNovo(registro);
                    Log.Logger.Contexto().Information("Veiculo {@veiculo} foi inserido com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível inserir o veiculo {@veiculo}", registro);
                }
            }
            else
                Log.Logger.Contexto().Warning("Veiculo inválido: {@resultadoValidacao}", resultadoValidacao);

            return resultadoValidacao;
        }

        public string Editar(int id, Veiculo registro)
        {
            string resultadoValidacao = registro.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                try
                {
                    veiculoRepository.Editar(id, registro);
                    Log.Logger.Contexto().Information("Veiculo {@veiculo} foi editado com sucesso.", registro);
                }
                catch (Exception ex)
                {
                    Log.Logger.Contexto().Error(ex, "Não foi possível editar o veiculo {@veiculo}", registro);
                }
            }
            else
                Log.Logger.Contexto().Warning("Veiculo inválido: {@resultadoValidacao}", resultadoValidacao);


            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                veiculoRepository.Excluir(id);
                Log.Logger.Contexto().Information("Veiculo de id {@idVeiculo} foi excluído com sucesso", id);
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível excluir o veiculo com id {@idVeiculo}", id);
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            try
            {
                bool existe = veiculoRepository.Existe(id);
                Log.Logger.Contexto().Information("Verificado se existe o veiculo com id {@idVeiculo}", id);
                return existe;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível verificar se existe o veiculo com id {@idVeiculo}", id);
                return false;
            }
        }

        public Veiculo SelecionarPorId(int id)
        {
            try
            {
                Veiculo veiculoSelecionado = veiculoRepository.SelecionarPorId(id);
                Log.Logger.Contexto().Information("Selecionado veiculo {@veiculoSelecionado}", veiculoSelecionado);
                return veiculoSelecionado;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar o veiculo com id {@idVeiculo}", id);
                return null;
            }
        }

        public List<Veiculo> SelecionarTodos()
        {
            try
            {
                List<Veiculo> todosVeiculos = veiculoRepository.SelecionarTodos();
                Log.Logger.Contexto().Information("Selecionado todos os veiculos {@todosVeiculos}", todosVeiculos);
                return todosVeiculos;
            }
            catch (Exception ex)
            {
                Log.Logger.Contexto().Error(ex, "Não foi possível selecionar todos os veiculos");
                return null;
            }
        }

        public string Validar(Veiculo novoVeiculo, int id = 0)
        {
            //validar placas iguais
            if (novoVeiculo != null)
            {
                if (id != 0)
                {//situação de editar
                    int countPlacasIguais = 0;
                    List<Veiculo> todosVeiculos = SelecionarTodos();
                    foreach (Veiculo veiculo in todosVeiculos)
                    {
                        if (novoVeiculo.Placa.Equals(veiculo.Placa) && veiculo.Id != id)
                            countPlacasIguais++;
                    }
                    if (countPlacasIguais > 0)
                        return "Placa já cadastrada, tente novamente.";
                }
                else
                {//situação de inserir
                    int countPlacasIguais = 0;
                    List<Veiculo> todosVeiculos = SelecionarTodos();
                    foreach (Veiculo veiculo in todosVeiculos)
                    {
                        if (novoVeiculo.Placa.Equals(veiculo.Placa))
                            countPlacasIguais++;
                    }
                    if (countPlacasIguais > 0)
                        return "Placa já cadastrada, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

     
    }
}
