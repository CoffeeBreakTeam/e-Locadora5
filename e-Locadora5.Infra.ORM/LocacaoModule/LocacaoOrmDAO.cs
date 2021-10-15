using e_Locadora5.Dominio.LocacaoModule;
using e_Locadora5.Dominio.TaxasServicosModule;
using e_Locadora5.Infra.ORM.LocadoraModule;
using e_Locadora5.Infra.ORM.ParceiroModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.ORM.LocacaoModule
{
    public class LocacaoOrmDAO : RepositoryBase<Locacao, int>, ILocacaoRepository
    {
        LocadoraDbContext locadoraDbContext;

        public LocacaoOrmDAO(LocadoraDbContext locadoraDbContext) : base(locadoraDbContext)
        {
            this.locadoraDbContext = locadoraDbContext;
        }

        public bool ExisteLocacaoComVeiculoRepetido(int id, int idVeiculo)
        {
            try
            {
                Serilog.Log.Logger.Information("Tentando selecionar todas as locacaoes com veiculos repetidos no banco de dados...");
                bool veiculosRepetidos = locadoraDbContext.locacoes.ToList().Exists(x => x.Veiculo.Id == idVeiculo);
                if (veiculosRepetidos)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarLocacaoCompleta(int id)
        {
            var locacoes = locadoraDbContext.locacoes
                .Include(x => x.Veiculo)
                .ThenInclude(x => x.GrupoVeiculo).Where(x => x.GrupoVeiculo.categoria == "SUV")
               ;
            return null;
        }

        public List<Locacao> SelecionarLocacoesEmailPendente()
        {
            try
            {
                Serilog.Log.Logger.Information("Tentando selecionar todas locações com emails pendentes no banco de dados...");
                List<Locacao> todasLocacoes = new List<Locacao>();
               
                Serilog.Log.Logger.Information("Tentando atribuir individualmente as taxas e serviços de cada locação...");
                foreach (Locacao locacaoIndividual in todasLocacoes)
                {
                    List<TaxasServicos> taxasServicosIndividuais = SelecionarTaxasServicosPorLocacaoId(locacaoIndividual.Id);
                    locacaoIndividual.TaxasServicos = taxasServicosIndividuais;
                }

                return todasLocacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarLocacoesPendentes(bool emAberto, DateTime dataDevolucao)
        {
            try
            {
                Serilog.Log.Logger.Information("Tentando selecionar locações pendentes no banco de dados...");
                
                List<Locacao> locacoesPendentes = locadoraDbContext.locacoes.ToList().FindAll(x => x.emAberto == emAberto || x.dataDevolucao < dataDevolucao);
             
                return locacoesPendentes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Locacao> SelecionarLocacoesPorVeiculoId(int id)
        {
            try
            {
                Serilog.Log.Logger.Information("Tentando selecionar Id do veículo em locação no banco de dados...");
                List<Locacao> todasLocacoes = locadoraDbContext.locacoes.ToList().FindAll(x => x.Veiculo.Id == id);

                return todasLocacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TaxasServicos> SelecionarTaxasServicosPorLocacaoId(int idLocacao)
        {
            try
            {
                Serilog.Log.Logger.Information("Tentando selecionar Id do veículo em locação no banco de dados...");

                Locacao locacaoSelecionada = SelecionarPorId(idLocacao);

                List<TaxasServicos> TaxasDaLocacao = locacaoSelecionada.TaxasServicos;

                return TaxasDaLocacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      

        public List<LocacaoTaxasServicos> SelecionarTodosLocacaoTaxasServicos()
        {
            return null;
        }
    }
}
