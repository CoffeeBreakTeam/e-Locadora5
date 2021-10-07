using e_Locadora5.Dominio.ClientesModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Tests.ClientesModule
{
    
    public class ClienteDataBuilder
    {
        private Cliente clientes;



        public Cliente Build()
        {
            return clientes;
        }

        public ClienteDataBuilder()
        {
            clientes = new Cliente();
        }

        public ClienteDataBuilder ComNome(string nome)
        {
            clientes.Nome = nome;           
            return this;
        }
        public ClienteDataBuilder ComEndereco(string endereco)
        {
            clientes.Endereco = endereco;
            return this;
        }

        public ClienteDataBuilder ComTelefone(string telefone)
        {
            clientes.Telefone = telefone;
            return this;
        }

        public ClienteDataBuilder ComRG(string RG)
        {
            clientes.RG = RG;
            return this;
        }

        public ClienteDataBuilder ComCPF(string CPF)
        {
            clientes.CPF = CPF;
            return this;
        }
        public ClienteDataBuilder ComCNPJ(string CNPJ)
        {
            clientes.CNPJ = CNPJ;
            return this;
        }
        public ClienteDataBuilder ComEmail(string email)
        {
            clientes.Email = email;
            return this;
        }

        public Cliente GerarClienteCompleto()
        {
           return  this.ComNome("JBS").ComEndereco("ABC")
                .ComTelefone("363636")
                .ComRG("123")
                .ComCPF("54321")
                .ComCNPJ("")
                .ComEmail("umemail@gmail.com")
                .Build();
        }
    }
}
