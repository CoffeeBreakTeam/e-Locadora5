using e_Locadora5.Dominio.FuncionarioModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DataBuilderTest.FuncionarioModule
{
    public class FuncionarioDataBuilder
    {
        private Funcionario funcionario;


        public FuncionarioDataBuilder()
        {
            funcionario = new Funcionario();

        }

        public FuncionarioDataBuilder comNome(string Nome)
        {
            funcionario.Nome = Nome;
            return this;
        }

        public FuncionarioDataBuilder comCPF(string cpf)
        {
            funcionario.NumeroCpf = cpf;
            return this;
        }

        public FuncionarioDataBuilder comSalario(double salario)
        {
            funcionario.Salario = salario;
            return this;
        }

        public FuncionarioDataBuilder comSenha(string senha)
        {
            funcionario.Senha = senha;
            return this;
        }

        public FuncionarioDataBuilder comUsuario(string usuario)
        {
            funcionario.Usuario = usuario;
            return this;
        }

        public Funcionario Build()
        {
            return funcionario;

        }

        public Funcionario GerarFuncionarioCompleto()
        {
            return this.comNome("Roberto").comCPF("1231231").comSalario(1000).comSenha("123").comUsuario("Ro").Build();
        }
    }
}
