using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.DataBuilderTest.CondutorModule
{
    public class CondutorDataBuilder
    {
           string nome;
           string Endereco;
           string Telefone;
           string Rg;
           string Cpf;
           string NumeroCNH;
           DateTime ValidadeCNH;
           Cliente Cliente;

        private Condutor condutor;

        public Condutor Build()
        {
            return condutor;
        }

        public CondutorDataBuilder()
        {
            condutor = new Condutor();

            nome = "Lucas";
            Endereco = "wssw";
            Telefone = "5055555552";
            Rg = "2222222";
            Cpf = "55555555";
            NumeroCNH = "500";
            ValidadeCNH = DateTime.Now.AddDays(5);
            Cliente = new Cliente("Joao","wsw","wsws","sws","wss","wswsw","wsws");
        }

        public CondutorDataBuilder ComNome(string nome)
        {
            condutor.Nome = nome;
            return this;
        }
        public CondutorDataBuilder ComEndereco(string endereco)
        {
            condutor.Endereco = endereco;
            return this;
        }

        public CondutorDataBuilder ComTelefone(string telefone)
        {
            condutor.Telefone = telefone;
            return this;
        }

        public CondutorDataBuilder ComRG(string rg)
        {
            condutor.Rg = rg;
            return this;
        }

        public CondutorDataBuilder ComCPF(string cpf)
        {
            condutor.Cpf = cpf;
            return this;
        }

        public CondutorDataBuilder ComNumeroCNH(string numeroCnh)
        {
            condutor.NumeroCNH = numeroCnh;
            return this;
        }

        public CondutorDataBuilder ComValidadeCNH(DateTime validadeCnh)
        {
            condutor.ValidadeCNH = validadeCnh;
            return this;
        }

        public CondutorDataBuilder ComClienteId(Cliente cliente)
        {
            condutor.Cliente = cliente;
            return this;
        }

        public Condutor GerarCondutorCompleto()
        {
            return this.ComNome(nome)
                .ComEndereco(Endereco)
                .ComTelefone(Telefone)
                .ComRG(Rg)
                .ComCPF(Cpf)
                .ComNumeroCNH(NumeroCNH)
                .ComValidadeCNH(ValidadeCNH)
                .ComClienteId(Cliente)
                .Build();
        }
    }
}
