using e_Locadora5.Dominio.LocacaoModule;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Locadora5.Infra.PDF.LocacaoModule
{
    class RelatorioLocacaoPDF : IRelatorioLocacao
    {
        public string GerarRelatorio(Locacao locacao)
        {
            string nomeArquivo = $@"..\..\..\" + "Contrato.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritoPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            //doc.Open();
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14));

            paragrafo.Alignment = Element.ALIGN_LEFT;
            paragrafo.Add("==================================\n");
            paragrafo.Add("Cliente: " + locacao.cliente.Nome + " " + "RG: " + locacao.cliente.RG + "\n");
            paragrafo.Add("Condutor: " + locacao.condutor.Nome + " " + "RG: " + locacao.condutor.Rg + "\n");
            paragrafo.Add("==================================\n");

            paragrafo.Add("Veiculo: " + locacao.veiculo.Modelo + "\n");
            paragrafo.Add("Placa: " + locacao.veiculo.Placa + "\n");
            paragrafo.Add("Cor: " + locacao.veiculo.Cor + "\n");
            paragrafo.Add("==================================\n");

            foreach (var taxasServicos in locacao.taxasServicos)
            {
                paragrafo.Add("Taxas e Serviços: " + taxasServicos.Descricao + "\n");
            }

            paragrafo.Add("==================================\n");
            paragrafo.Add("PLano Selecionado: " + locacao.plano + "\n");
            paragrafo.Add("==================================\n");
            paragrafo.Add("Data de Locação: " + locacao.dataLocacao.ToShortDateString() + "\n");
            paragrafo.Add("==================================\n");
            paragrafo.Add("Data de Devolução: " + locacao.dataDevolucao.ToShortDateString() + "\n");
            paragrafo.Add("==================================\n");

            if (locacao.cupom != null)
            {
                if (locacao.cupom.ValorMinimo <= locacao.CalcularValorLocacao())
                {
                    if (locacao.cupom.ValorFixo != 0)
                        paragrafo.Add("Cupom: " + locacao.cupom.Nome + "\nValor do Desconto: " + locacao.cupom.ValorFixo + "R$\n");

                    else
                        paragrafo.Add("Cupom: " + locacao.cupom.Nome + "\nPorcentagem de Desconto na Locação: " + locacao.cupom.ValorPercentual + "%\n");

                    paragrafo.Add("==================================\n");
                }

                else
                {
                    paragrafo.Add("Cupom: " + locacao.cupom.Nome + "\n");
                    paragrafo.Add("Cupom atualmente inválido, pois o valor total não cumpre os requisitos do cupom!\n");
                }
            }

            paragrafo.Add("==================================\n");
            paragrafo.Add("Valor Total:" + locacao.CalcularValorLocacao() + "\n");

            doc.Open();
            doc.Add(paragrafo);
            doc.Close();

            return nomeArquivo;
        }
    }
}
