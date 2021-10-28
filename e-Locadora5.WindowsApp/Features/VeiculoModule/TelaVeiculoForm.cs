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
        private GrupoVeiculoAppService grupoVeiculoAppService = null;
        private VeiculoAppService veiculoAppService = null;
        private Veiculo veiculo;
        private string imgLocation = "";

        public TelaVeiculoForm(VeiculoAppService veiculoAppService, GrupoVeiculoAppService grupoVeiculoAppService)
        {
            this.grupoVeiculoAppService = grupoVeiculoAppService;
            this.veiculoAppService = veiculoAppService;
            InitializeComponent();
            CarregarGrupoVeiculo();
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
            //int capacidadeTanque = Convert.ToInt32(txtCapacidadeTanque.Text);

            int capacidadeTanque = 0;
            int.TryParse(txtCapacidadeTanque.Text, out capacidadeTanque);

            int qtdPortas = Convert.ToInt32(txtQtdPortas.Text);
            int ano = Convert.ToInt32(txtAno.Text);
            int capacidadePessoas = Convert.ToInt32(txtCapacidadePessoas.Text);
            string tipoGasolina = comboBoxCombustivel.SelectedItem.ToString();
            string tamanhoPortaMalas = comboBoxPortaMalas.SelectedItem.ToString();

            GrupoVeiculo grupoVeiculo = (GrupoVeiculo)comboBoxGrupoVeiculo.SelectedItem;

            veiculo = new Veiculo(placa, modelo, fabricante, quilometragem, capacidadeTanque, qtdPortas, chassi, cor, capacidadePessoas, ano, tamanhoPortaMalas, tipoGasolina, grupoVeiculo, imagem);

            veiculo.Id = Convert.ToInt32(txtId.Text);
        }

        byte[] ConvertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, pictureBoxVeiculo.Image.RawFormat);
                return ms.ToArray();
            }
        }

        private void CarregarGrupoVeiculo()
        {
            comboBoxGrupoVeiculo.Items.Clear();
            foreach (GrupoVeiculo grupoVeiculo in grupoVeiculoAppService.SelecionarTodos())
                comboBoxGrupoVeiculo.Items.Add(grupoVeiculo);
        }

        private void TelaVeiculoForm_Load(object sender, EventArgs e)
        {
        }

        #region MetodosLerSomenteint

        private void txtAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtCapacidadeTanque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtQtdPortas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtCapacidadePessoas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void txtQuilometragem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        #endregion
    }
}
