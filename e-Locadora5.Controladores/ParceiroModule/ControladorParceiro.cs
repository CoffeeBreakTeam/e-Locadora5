using e_Locadora5.Controladores.Shared;
using e_Locadora5.Dominio.ParceirosModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Controladores.ParceiroModule
{
    public class ControladorParceiro : Controlador<Parceiro>
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

        private const string sqlSelecionarTodosParceiros =
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
        #endregion
        public override string InserirNovo(Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarParceiros(registro);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiros(registro));
            }

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                return resultadoValidacao;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }
 
        public override string Editar(int id, Parceiro registro)
        {
            string resultadoValidacao = registro.Validar();
            string resultadoValidacaoControlador = ValidarParceiros(registro, id);

            if (resultadoValidacao == "ESTA_VALIDO" && resultadoValidacaoControlador == "ESTA_VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiros(registro));
            }

            if (resultadoValidacao != "ESTA_VALIDO")
            {
                return resultadoValidacao;
            }
            else
            {
                return resultadoValidacaoControlador;
            }
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlExcluirParceiro, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteParceiros, AdicionarParametro("ID", id));
        }

        public override Parceiro SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        } 

        public override List<Parceiro> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);
        }
        private Dictionary<string, object> ObtemParametrosParceiros(Parceiro parceiro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", parceiro.Id);
            parametros.Add("PARCEIRO", parceiro.nome);
;

            return parametros;
        }
        private Parceiro ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string descricao = Convert.ToString(reader["PARCEIRO"]);


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
                    List<Parceiro> todosParceiros = SelecionarTodos();
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
                    List<Parceiro> todosParceiros = SelecionarTodos();
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
    }
}
