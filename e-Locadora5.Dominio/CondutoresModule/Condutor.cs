using e_Locadora5.Dominio.ClientesModule;
using e_Locadora5.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Dominio.CondutoresModule
{
    public class Condutor : EntidadeBase
    {
        public string Nome { get; }
        public string Endereco { get; }
        public string Telefone { get; }
        public string Rg { get; }
        public string Cpf { get; }
        public string NumeroCNH { get; }
        public DateTime ValidadeCNH { get; }
        public Clientes Cliente { get; }

        public Condutor(string nome, string endereco, string telefone, string rg, string cpf, 
            string numeroCNH, DateTime validadeCNH, Clientes cliente)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Rg = rg;
            Cpf = cpf;
            NumeroCNH = numeroCNH;
            ValidadeCNH = validadeCNH;
            Cliente = cliente;
        }

        public override string ToString()
        {
            return Nome;
        }


        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao = "O atributo nome é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(Endereco))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo endereço é obrigatório e não pode ser vazio.";

            if (Telefone.Length < 9)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo Telefone está invalido.";

            if (string.IsNullOrEmpty(Rg))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo Numero do Rg é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(Cpf))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo Numero do Cpf é obrigatório e não pode ser vazio.";

            if (string.IsNullOrEmpty(NumeroCNH))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O atributo Numero da CNH é obrigatório e não pode ser vazio.";

            if (ValidadeCNH == DateTime.MinValue)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Validade da CNH é obrigatório";

            if (ValidadeCNH < DateTime.Now)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "A validade da cnh inserida está expirada, tente novamente";

            if (string.IsNullOrEmpty(Cliente.ToString()))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Cliente é obrigatório e não pode ser Vazio";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }

        public  bool Equals(Condutor obj)
        {
            return obj is Condutor condutor &&
                   Id == condutor.Id &&
                   Nome == condutor.Nome &&
                   Endereco == condutor.Endereco &&
                   Telefone == condutor.Telefone &&
                   Rg == condutor.Rg &&
                   Cpf == condutor.Cpf &&
                   NumeroCNH == condutor.NumeroCNH &&
                   ValidadeCNH == condutor.ValidadeCNH &&
                   EqualityComparer<Clientes>.Default.Equals(Cliente, condutor.Cliente);
        }

        public override int GetHashCode()
        {
            int hashCode = 987487998;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nome);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Endereco);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Telefone);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Rg);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Cpf);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NumeroCNH);
            hashCode = hashCode * -1521134295 + ValidadeCNH.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Clientes>.Default.GetHashCode(Cliente);
            return hashCode;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Condutor);
        }

    }
}
