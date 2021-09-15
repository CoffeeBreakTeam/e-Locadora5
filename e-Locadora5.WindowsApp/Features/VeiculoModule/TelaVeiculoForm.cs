using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Locadora5.Aplicacao.GrupoVeiculoModule;
using e_Locadora5.Aplicacao.VeiculoModule;
using e_Locadora5.Dominio;
using e_Locadora5.Dominio.VeiculosModule;
using e_Locadora5.Infra.SQL.GrupoVeiculoModule;
using e_Locadora5.Infra.SQL.VeiculoModule;

namespace e_Locadora5.WindowsApp.Features.VeiculoModule
{
    public partial class TelaVeiculoForm : Form
    {
        private GrupoVeiculoAppService grupoVeiculoAppService = new GrupoVeiculoAppService(new GrupoVeiculoDAO());
        private VeiculoAppService veiculoAppService = new VeiculoAppService(new VeiculoDAO());
        private Veiculo veiculo;
        private string imgLocation = "";

        public TelaVeiculoForm()
        {
            InitializeComponent();
            CarregarContatos();
        }

        public Veiculo Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                txtId.Text = veiculo.Id.ToString();
                txtPlaca.Text = veiculo.Placa;
                txtModelo.Text = veiculo.Modelo;
                txtFabricante.Text = veiculo.Fabricante;
                txtQuilometragem.Text = veiculo.Quilometragem.ToString();
                txtChassi.Text = veiculo.NumeroChassi;
                txtCor.Text = veiculo.Cor;
                txtCapacidadeTanque.Text = veiculo.QtdLitrosTanque.ToString();
                txtQtdPortas.Text = veiculo.QtdPortas.ToString();
                txtAno.Text = veiculo.AnoFabricacao.ToString();
                txtCapacidadePessoas.Text = veiculo.CapacidadeOcupantes.ToString();
                comboBoxCombustivel.SelectedItem = veiculo.Combustivel.ToString();
                comboBoxPortaMalas.SelectedItem = veiculo.TamanhoPortaMalas.ToString();

                comboBoxGrupoVeiculo.SelectedItem = veiculo.GrupoVeiculo;

                pictureBoxVeiculo.Image = ConvertBinaryToImage(veiculo.Imagem);

            }
        }

        //Convert binary to image
        Image ConvertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBoxVeiculo.ImageLocation = imgLocation;             
            }     
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            string validacaoCampos = ValidarCampos();
            if (validacaoCampos.Equals("VALIDO"))
            {
                DialogResult = DialogResult.OK;
                //Código para obter imagem
                byte[] imagem = null;


                imagem = ConvertImageToBinary(pictureBoxVeiculo.Image);



                string placa = txtPlaca.Text;
                string modelo = txtModelo.Text;
                string chassi = txtChassi.Text;
                double quilometragem = Convert.ToDouble(txtQuilometragem.Text);
                string cor = txtCor.Text;
                string fabricante = txtFabricante.Text;
                int capacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);
                int qtdPortas = Convert.ToInt32(txtQtdPortas.Text);
                int ano = Convert.ToInt32(txtAno.Text);
                int capacidadePessoas = Convert.ToInt32(txtCapacidadePessoas.Text);
                string tipoGasolina = comboBoxCombustivel.SelectedItem.ToString();
                string tamanhoPortaMalas = comboBoxPortaMalas.SelectedItem.ToString();

                GrupoVeiculo grupoVeiculo = (GrupoVeiculo)comboBoxGrupoVeiculo.SelectedItem;

                veiculo = new Veiculo(placa, modelo, fabricante, quilometragem, capacidadeTanque, qtdPortas, chassi, cor, capacidadePessoas, ano, tamanhoPortaMalas, tipoGasolina, grupoVeiculo, imagem);

                int id = Convert.ToInt32(txtId.Text);
                string resultadoValidacaoDominio = veiculo.Validar();

                string resultadoValidacaoControlador = veiculoAppService.Validar(veiculo, id);

                if (resultadoValidacaoDominio != "ESTA_VALIDO")
                {
                    string primeiroErroDominio = new StringReader(resultadoValidacaoDominio).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroDominio);

                    DialogResult = DialogResult.None;
                }
                else if (resultadoValidacaoControlador != "ESTA_VALIDO")
                {
                    string primeiroErroControlador = new StringReader(resultadoValidacaoControlador).ReadLine();

                    TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErroControlador);

                    DialogResult = DialogResult.None;
                }
            }
            else
            {
                string primeiroErro = new StringReader(validacaoCampos).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
            }
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, pictureBoxVeiculo.Image.RawFormat);
                return ms.ToArray();
            }
        }

        private void CarregarContatos()
        {
            comboBoxGrupoVeiculo.Items.Clear();
            foreach (GrupoVeiculo grupoVeiculo in grupoVeiculoAppService.SelecionarTodos())
                comboBoxGrupoVeiculo.Items.Add(grupoVeiculo);
        }

        public string ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtPlaca.Text))
            {
                return "Placa é obrigatório"; ;
            }

            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                return "Modelo é obrigatório"; ;
            }

            if (string.IsNullOrEmpty(txtFabricante.Text))
            {
                return "Fabricante é obrigatório";
            }

            if (string.IsNullOrEmpty(txtQuilometragem.Text))
            {
                return "Quilometragem é obrigatório";
            }

            if (!ValidarTipoInt(txtQuilometragem.Text))
            {
                return "Digite um valor válido para Quilometragem";
            }

            if (string.IsNullOrEmpty(txtChassi.Text))
            {
                return "Chassi é obrigatório";
            }

            if (string.IsNullOrEmpty(txtCor.Text))
            {
                return "Cor é obrigatório";
            }

            if (string.IsNullOrEmpty(txtCapacidadeTanque.Text))
            {
                return "Capacidade Tanque é obrigatório";
            }

            if (!ValidarTipoInt(txtCapacidadeTanque.Text))
            {
                return "Digite um valor válido para Capacidade do Tanque";
            }

            if (string.IsNullOrEmpty(txtQtdPortas.Text))
            {
                return "Quantidade de Portas é obrigatório";
            }

            if (!ValidarTipoInt(txtQtdPortas.Text))
            {
                return "Digite um valor válido para Quantidade de Portas";
            }

            if (string.IsNullOrEmpty(txtAno.Text))
            {
                return "Ano de Fabricação é obrigatório";
            }

            if (!ValidarTipoInt(txtAno.Text))
            {
                return "Digite um valor válido para Ano de Fabricação";
            }

            if (string.IsNullOrEmpty(txtCapacidadePessoas.Text))
            {
                return "Capacidade de Pessoas é obrigatório";
            }

            if (!ValidarTipoInt(txtCapacidadePessoas.Text))
            {
                return "Digite um valor válido para Capacidade de Pessoas";
            }

            if (comboBoxCombustivel.SelectedItem == null)
            {
                return "Tipo de combustível é obrigatório";
            }

            if (comboBoxGrupoVeiculo.SelectedItem == null)
            {
                return "Grupo do veículo é obrigatório";
            }

            if (comboBoxPortaMalas.SelectedItem == null)
            {
                return "Tamanho do porta malas é obrigatório";
            }

            if (pictureBoxVeiculo.Image == null)
            {
                return "Imagem do veículo é obrigatório";
            }

            return "VALIDO";
        }

        private bool ValidarTipoInt(string texto)
        {
            try
            {
                double numeroConvertido = Convert.ToInt32(texto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void TelaVeiculoForm_Load(object sender, EventArgs e)
        {
        }
    }
}
