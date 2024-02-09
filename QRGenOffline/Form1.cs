using BLL;
using System.Drawing.Imaging;

namespace QRGenOffline
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Text = "Generer QR-kode";
            button2.Visible = false;
            button3.Text = "Gem QR-kode";
            button4.Text = "Afslut";
            button5.Text = "Vælg Frontfarve";
            button6.Text = "Vælg Baggrundsfarve";
            UpdateQrCode();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new();
            colorDialog.ShowDialog();
            tableLayoutPanel6.BackColor = colorDialog.Color;
            UpdateQrCode();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ();
            colorDialog.ShowDialog();
            tableLayoutPanel7.BackColor = colorDialog.Color;
            tableLayoutPanel1.BackColor = colorDialog.Color;
            UpdateQrCode();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "PNG|*.png",
                Title = "Gem QR-kode",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateQrCode()
        {
            if (textBoxURL.Text != "")
            {
                pictureBox1.Image = QRGen.GenerateQRCode(textBoxURL.Text, (int)numericUpDown1.Value, tableLayoutPanel6.BackColor, tableLayoutPanel7.BackColor);
            }
            else
            {
                pictureBox1.Image = QRGen.GenerateQRCode("https://www.example.com", (int)numericUpDown1.Value, tableLayoutPanel6.BackColor, tableLayoutPanel7.BackColor);
            }
        }

        private void TextBoxURL_TextChanged(object sender, EventArgs e)
        {
            UpdateQrCode();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateQrCode();
        }
    }
}
