﻿using e_Locadora5.Dominio.ParceirosModule;
using e_Locadora5.Infra.GeradorLogs;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.SQL.ParceiroModule
{
    public class ParceiroDAO : IParceiroRepository
    {
        #region Queries

        private const string sqlInserirParceiro =
        @"INSERT INTO TBPARCEIROS
	                (	
		                [PARCEIRO]
	                )
	                VALUES
	                (
                        @PARCEIRO
	                )";

        private const string sqlEditarParceiro =
        @"UPDATE TBPARCEIROS
                    SET
                        [PARCEIRO] = @PARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlExcluirParceiro =
         @"DELETE 
	                FROM
                        TBPARCEIROS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarParceiroPorId =
         @"SELECT
                        [ID],
                        [PARCEIRO]
	                FROM
                        TBPARCEIROS
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosParceirosParceiros =
        @"SELECT
                        [ID],
                        [PARCEIRO]

                        FROM TBPARCEIROS";


        private const string sqlExisteParceiros =
         @"SELECT 
                COUNT(*) 
            FROM 
                [TBPARCEIROS]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteParceiroComNome = @"SELECT 
                COUNT(*) 
            FROM 
                [TBPARCEIROS]
            WHERE 
                [PARCEIRO] = @PARCEIRO";

        #endregion

        public void InserirParceiro(Parceiro parceiro)
        {
            Log.Logger.Contexto().Information("Tentando inserir {@parceiro} no banco de dados...", parceiro);
            parceiro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiros(parceiro));
        }

        public void EditarParceiro(int id, Parceiro parceiro)
        {
            Serilog.Log.Logger.Contexto().Information("Tentando editar o parceiro com id {@id} no banco de dados...", id);
            Db.Update(sqlEditarParceiro, ObtemParametrosParceiros(parceiro));
        }

        public void ExcluirParceiro(int id)
        {
            Serilog.Log.Logger.Contexto().Information("Excluindo parceiro com id {@id} no banco de dados...", id);
            Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));
        }

        public List<Parceiro> SelecionarTodosParceiros()
        {
            return Db.GetAll(sqlSelecionarTodosParceirosParceiros, ConverterEmParceiro);
        }

        public bool Existe(int id)
        {
            Serilog.Log.Logger.Contexto().Information("Tentando verificar se existe um parceiro com id {@id} no banco de dados...", id);
            return Db.Exists(sqlExisteParceiros, AdicionarParametro("ID", id));
        }

        public Parceiro SelecionarParceiroPorId(int id)
        {
            Serilog.Log.Logger.Contexto().Information("Tentando selecionar o parceiro com id {@id} no banco de dados...", id);
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        }

        #region metodos privados

        private Dictionary<string, object> ObtemParametrosParceiros(Parceiro parceiro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", parceiro.Id);
            parametros.Add("PARCEIRO", parceiro.nome);

            return parametros;
        }
        private Parceiro ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string descricao = ((string)reader["PARCEIRO"]);


            Parceiro parceiros = new Parceiro(descricao);

            parceiros.Id = id;

            return parceiros;
        }
        public string ValidarParceiros(Parceiro NovosParceiros, int id = 0)
        {
            if (NovosParceiros != null)
            {
                if (id != 0)
                {//situação de editar
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodosParceiros();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (NovosParceiros.nome.Equals(parceiro.nome) && parceiro.Id != id)
                            countparceirosIguais++;
                    }
                    if (countparceirosIguais > 0)
                        return "Parceiro já Cadastrado, tente novamente.";
                }
                else
                {//situação de inserir
                    int countparceirosIguais = 0;
                    List<Parceiro> todosParceiros = SelecionarTodosParceiros();
                    foreach (Parceiro parceiro in todosParceiros)
                    {
                        if (NovosParceiros.nome.Equals(parceiro.nome))
                            countparceirosIguais++;
                    }
                    if (countparceirosIguais > 0)
                        return "Parceiro já Cadastrado, tente novamente.";
                }
            }
            return "ESTA_VALIDO";
        }

        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }

        public bool ExisteParceiroComEsseNome(string nome)
        {
            return Db.Exists(sqlExisteParceiroComNome, AdicionarParametro("PARCEIRO", nome));
        }


        #endregion
    }
}
