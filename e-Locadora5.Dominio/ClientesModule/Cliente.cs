using e_Locadora5.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.ClientesModule
{
    public class Cliente : EntidadeBase<int> 
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string RG { get; set; }
        public string CPF { get; set;  }
        public string CNPJ { get; set; }
        public string Email { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nome, string endereco, string telefone, string rG,
            string cPF, string cNPJ, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            RG = rG;
            CPF = cPF;
            CNPJ = cNPJ;
            Email = email;
        }

        public override string ToString()
        {
            return Nome;
        }

        public override string Validar()
        {
            Regex templateEmail = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O atributo nome é obrigatório e não pode ser vazio.";
           
            if(string.IsNullOrEmpty(Endereco))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo endereço é obrigatório e não pode ser vazio.";
           
            if(Telefone.Length < 9 )
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo Telefone está invalido.";

            if (templateEmail.IsMatch(Email) == false)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Email está inválido";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public bool Equals(Cliente obj)
        {
            return obj is Cliente clientes &&
                   Id == clientes.Id &&
                   Nome == clientes.Nome &&
                   Endereco == clientes.Endereco &&
                   Telefone == clientes.Telefone &&
                   RG == clientes.RG &&
                   CPF == clientes.CPF &&
                   CNPJ == clientes.CNPJ &&
                   Email == clientes.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = 1618408693;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RG);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CPF);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CNPJ);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Cliente);
        }
    }
}
