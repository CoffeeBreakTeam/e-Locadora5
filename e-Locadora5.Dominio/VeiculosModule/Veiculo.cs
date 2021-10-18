using e_Locadora5.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.IO;
using e_Locadora5.Dominio.LocacaoModule;

namespace e_Locadora5.Dominio.VeiculosModule
{
    public class Veiculo : EntidadeBase<int>
    {
        public Veiculo() { }
        public Veiculo(string placa,string modelo, string fabricante, double quilometragem, int qtdlitros,int qtdPortas, string chassi,string cor,
            int passageiros,int ano,string portamalas, string combustivel,GrupoVeiculo grupo, byte[] imagem)
        {
            Placa = placa;
            Modelo = modelo;
            Fabricante = fabricante;
            Quilometragem = quilometragem;
            QtdLitrosTanque = qtdlitros;
            QtdPortas = qtdPortas;
            NumeroChassi = chassi;
            Cor = cor;
            CapacidadeOcupantes = passageiros;
            AnoFabricacao = ano;
            TamanhoPortaMalas = portamalas;
            Combustivel = combustivel;
            GrupoVeiculo = grupo;
            Imagem = imagem;
            Locacoes = new List<Locacao>();
            GrupoVeiculoId = grupo.Id;
        }

        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Fabricante { get; set; }
        public double Quilometragem { get; set; }
        public int QtdLitrosTanque { get; set; }
        public int QtdPortas { get; set; }
        public string NumeroChassi { get; set; }
        public string Cor { get; set; }
        public int CapacidadeOcupantes { get; set; }
        public int AnoFabricacao { get; set; }
        public string TamanhoPortaMalas { get; set; }
        public string Combustivel { get; set; }

        public int GrupoVeiculoId { get; set; }
        public GrupoVeiculo GrupoVeiculo { get; set; }

        public byte[] Imagem { get; set; }

        public List<Locacao> Locacoes { get; set; }
     
        public override string ToString()
        {
            return Modelo;
        }

        public override string Validar()
        {
            string resultadoValidacao = "";

            if (string.IsNullOrEmpty(Placa))
                resultadoValidacao = "O campo Placa é obrigatório";

            if (string.IsNullOrEmpty(Modelo))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Modelo é obrigatório";

            if (string.IsNullOrEmpty(Fabricante))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Fabricante é obrigatório";

            if (Quilometragem < 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quilometragem não pode ser menor que zero";

            if (QtdLitrosTanque <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo do Tanque de Combustivel não pode ser menor que zero";

            if (QtdPortas <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Quantidade de portas do Veiculo não pode ser menor ou igual a zero";

            if (string.IsNullOrEmpty(NumeroChassi))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Numero do Chassi é obrigatório";

            if (string.IsNullOrEmpty(Cor))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Cor do Veiculo é obrigatório";

            if (CapacidadeOcupantes < 2 || CapacidadeOcupantes > 7)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Capacidade de Ocupantes do Veiculo é obrigatório(Com Minimo 2 Lugares e Maximo 7)";

            if (AnoFabricacao <= 0)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano de Fabricação do Veiculo não pode ser menor que zero";

            if (AnoFabricacao > DateTime.Now.Year)
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Ano de Fabricação do Veiculo não pode ser maior que o ano atual";

            if (string.IsNullOrEmpty(TamanhoPortaMalas.ToString()))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tamanho do Porta Malas é obrigatório";

            if (string.IsNullOrEmpty(Combustivel.ToString()))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Tipo de combustivel é obrigatório";

            if (string.IsNullOrEmpty(GrupoVeiculo.ToString()))
                resultadoValidacao += QuebraDeLinha(resultadoValidacao) + "O campo Grupo de Veiculo é obrigatório";

            if (resultadoValidacao == "")
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Veiculo);
        }

        public bool Equals(Veiculo other)
        {
            return other != null &&
                   Id == other.Id &&
                   Placa == other.Placa &&
                   Modelo == other.Modelo &&
                   Fabricante == other.Fabricante &&
                   Quilometragem == other.Quilometragem &&
                   QtdLitrosTanque == other.QtdLitrosTanque &&
                   QtdPortas == other.QtdPortas &&
                   NumeroChassi == other.NumeroChassi &&
                   Cor == other.Cor &&
                   CapacidadeOcupantes == other.CapacidadeOcupantes &&
                   AnoFabricacao == other.AnoFabricacao &&
                   TamanhoPortaMalas == other.TamanhoPortaMalas &&
                   Combustivel == other.Combustivel &&
                   EqualityComparer<GrupoVeiculo>.Default.Equals(GrupoVeiculo, other.GrupoVeiculo) &&
                   Imagem.SequenceEqual(other.Imagem);
        }
        public int QuantidadeDeListrosParaAbastecer(MarcadorCombustivelEnum marcadorCombustivel)
        {
            switch (marcadorCombustivel)
            {
                case MarcadorCombustivelEnum.Vazio: return QtdLitrosTanque;

                case MarcadorCombustivelEnum.UmQuarto: return (QtdLitrosTanque - (QtdLitrosTanque * 1 / 4));

                case MarcadorCombustivelEnum.MeioTanque: return (QtdLitrosTanque - (QtdLitrosTanque * 1 / 2));

                case MarcadorCombustivelEnum.TresQuartos:
                    return (QtdLitrosTanque - (QtdLitrosTanque * 3 / 4));

                default:
                    return 0;
            }
        }
        public void RegistrarLocacao(Locacao locacao)
        {
            Locacoes.Add(locacao);
        }
        public bool EstaAlugado()
        {
            if (Locacoes != null && Locacoes.Count>0)
                return Locacoes.Exists(x => x.emAberto && x.Id != 0);
            else
                return false;
        }
    }
}
