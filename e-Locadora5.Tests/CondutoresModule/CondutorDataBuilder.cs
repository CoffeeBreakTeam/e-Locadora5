using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.CondutoresModule;
using System;


namespace e_Locadora5.Tests.CondutoresModule
{
    public class CondutorDataBuilder
    {
        private Condutor condutor;

        public CondutorDataBuilder()
        {
            condutor = new Condutor();
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

        public CondutorDataBuilder ComRG(string RG)
        {
            condutor.Rg = RG;
            return this;
        }

        public CondutorDataBuilder ComCPF(string CPF)
        {
            condutor.Cpf = CPF;
            return this;
        }

        public CondutorDataBuilder ComNumeroCNH(string CNH)
        {
            condutor.NumeroCNH = CNH;
            return this;
        }

        public CondutorDataBuilder ComValidadeCNH(DateTime dataValidade)
        {
            condutor.ValidadeCNH = dataValidade;
            return this;
        }

        public CondutorDataBuilder ComCliente(Cliente clientes)
        {
            condutor.Cliente = clientes;
            return this;
        }

        public Condutor Build()
        {
            return condutor;
        }

        public Condutor GerarCondutorCompleto()
        {
            return this.ComCliente(new Cliente("JBS", "Ruaabc", "30180829", "","","123123-99","seilaoq@gmail.com"))
                .ComCPF("123")
                .ComEndereco("ruadoze")
                .ComNome("joão abcbolinhas")
                .ComNumeroCNH("8899")
                .ComTelefone("111111")     
                .ComRG("291231")
                .ComValidadeCNH(DateTime.Now.AddDays(10))
                .Build();
        }
    }
}
