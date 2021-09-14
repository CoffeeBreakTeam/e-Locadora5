using e_Locadora5.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Aplicacao.FuncionarioModule
{
    public class FuncionarioAppService
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public FuncionarioAppService(IFuncionarioRepository funcionarioRepository) 
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public string InserirNovo(Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            string validarRepeticoes = ValidarFuncionarios(registro);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                funcionarioRepository.InserirNovo(registro);
            }

            return resultadoValidacao;
        }

        public string Editar(int id, Funcionario registro)
        {
            string resultadoValidacao = registro.Validar();

            string validarRepeticoes = ValidarFuncionarios(registro, id);
            if (resultadoValidacao == "ESTA_VALIDO" && validarRepeticoes == "ESTA_VALIDO")
            {
                funcionarioRepository.Editar(id, registro);
            }

            return resultadoValidacao;
        }

        public bool Excluir(int id)
        {
            try
            {
                funcionarioRepository.Excluir(id);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Existe(int id)
        {
            return funcionarioRepository.Existe(id);
        }

        public Funcionario SelecionarPorId(int id)
        {
            return funcionarioRepository.SelecionarPorId(id);
        }

        public List<Funcionario> SelecionarTodos()
        {
            return funcionarioRepository.SelecionarTodos();
        }

        public string ValidarFuncionarios(Funcionario novoFuncionario, int id = 0)
        {
            //validar CPF IGUAIS iguais
            if (novoFuncionario != null)
            {
                if (id != 0)
                {//situação de editar
                    int countCPFsIguais = 0;
                    int countUsuariosIguais = 0;
                    List<Funcionario> todosFuncionarios = SelecionarTodos();
                    foreach (Funcionario funcionario in todosFuncionarios)
                    {
                        if (novoFuncionario.NumeroCpf.Equals(funcionario.NumeroCpf) && funcionario.Id != id && novoFuncionario.NumeroCpf != "")
                            countCPFsIguais++;
                        if (novoFuncionario.Usuario.Equals(funcionario.Usuario) && funcionario.Id != id && novoFuncionario.Usuario != "")
                            countUsuariosIguais++;
                    }
                    if (countCPFsIguais > 0)
                        return "Funcionário com CPF já cadastrado, tente novamente.";
                    if (countUsuariosIguais > 0)
                        return "Este nome de usuário já está sendo usado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countCPFsIguais = 0;
                    int countUsuariosIguais = 0;

                    List<Funcionario> todosFuncionarios = SelecionarTodos();
                    foreach (Funcionario funcionario in todosFuncionarios)
                    {
                        if (novoFuncionario.NumeroCpf.Equals(funcionario.NumeroCpf) && novoFuncionario.NumeroCpf != "")
                            countCPFsIguais++;
                        if (novoFuncionario.Usuario.Equals(funcionario.Usuario) && novoFuncionario.Usuario != "")
                            countUsuariosIguais++;

                    }
                    if (countCPFsIguais > 0)
                        return "Funcionário com CPF já cadastrado, tente novamente.";
                    if (countUsuariosIguais > 0)
                        return "Este nome de usuário já está sendo usado, tente novamente.";

                }
            }
            return "ESTA_VALIDO";
        }
    }
}

/*
 using LocadoraVeiculos.Dominio.LocacaoModule;
using log4net;
using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Aplicacao.LocacaoModule
{
    public class LocacaoAppService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IRelatorioLocacao geradorRelatorio;
        private readonly IConexaoInternet verificadorInternet;
        private readonly IEmailLocacao notificadorEmail;
        private readonly ILog logger;

        public LocacaoAppService(ILocacaoRepository locacaoRepo,
           IRelatorioLocacao geradorRelatorio,
           IConexaoInternet verificadorInternet,
           IEmailLocacao notificadorEmail,
           ILog logger)
        {
            locacaoRepository = locacaoRepo;
            this.geradorRelatorio = geradorRelatorio;
            this.verificadorInternet = verificadorInternet;
            this.notificadorEmail = notificadorEmail;
            this.logger = logger;
        }

        public string RegistrarNovaLocacao(Locacao locacao)
        {
            string resultadoValidacaoDominio = locacao.Validar();

            if (resultadoValidacaoDominio == "ESTA_VALIDO")
            {
                logger.Debug($"Registrando locação do veículo {locacao.Veiculo} para {locacao.Condutor.Cliente.Nome}...");
                locacaoRepository.InserirLocacao(locacao);
                logger.Debug($"Locação do veículo {locacao.Veiculo} registrada com sucesso!");

                logger.Debug($"Gerando o relatório PDF da locação do veículo {locacao.Veiculo}...");
                var caminhoRelatorio = geradorRelatorio.GerarRelatorio(locacao);
                logger.Debug($"Relatório PDF da locação do veículo {locacao.Veiculo} gerado com sucesso");

                logger.Debug($"Verificando acesso a internet...");
                var temInternet = verificadorInternet.TemConexaoComInternet();

                if (temInternet)
                {
                    logger.Debug($"Acesso a internet: OK");
                    logger.Debug($"Enviando email para o cliente: {locacao.Condutor.Cliente.Nome}...");
                    notificadorEmail.EnviarEmail(caminhoRelatorio);
                    logger.Debug($"Email para o cliente: {locacao.Condutor.Cliente.Nome} enviado com sucesso.");
                }
                else
                {
                    logger.Warn("Acesso a internet: indisponível");
                    logger.Warn($"O email da locação do veículo {locacao.Veiculo} será enviado no próximo acesso ao sistema");
                }
            }

            return resultadoValidacaoDominio;
        }

        public List<Locacao> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public void RegistrarDevolucao(Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public void EditarLocacao(int id, Locacao locacao)
        {
            throw new NotImplementedException();
        }

        public void ExcluirLocacao(int id)
        {
            throw new NotImplementedException();
        }

        public Locacao SelecionarPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
 */