using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsCartS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           /* var Data= DataBase.GetpProtestoAll();
            dataGridViewMain.DataSource = Data;
            dataGridViewMain.Columns["VALOR"].DefaultCellStyle.Format = "C2";*/
            
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelAdd.Visible = false;
        }

        private void buttonSalvarAdd_Click(object sender, EventArgs e)
        {
            var data = DateTime.Now;

            var dt = DataBase.GetpProtestoDataAdd(data);
            dataGridViewAdd.DataSource = dt;
            if (comboBoxProtestoAdd.Text != "Protestado" && comboBoxProtestoAdd.Text != "Cancelado")
            {
                MessageBox.Show("Alerta!", "Tipo de protesto não selecionado", MessageBoxButtons.OK);
            }
            else if(textBoxCertidãoAdd.Text == string.Empty && textBoxQuantidadeAdd.Text == string.Empty && textBoxRemessaAdd.Text == string.Empty)
            {
                MessageBox.Show("Alerta!", "Tipo de protesto não selecionado", MessageBoxButtons.OK);
            }
            else
            {
                
                Relatorio relatorio = new Relatorio();
                relatorio.Certidao = Convert.ToInt32(textBoxCertidãoAdd.Text);
                relatorio.Protesto = comboBoxProtestoAdd.Text;
                relatorio.Remessa = textBoxRemessaAdd.Text;
                relatorio.Data = dateTimePickerAdd.Text;
                relatorio.Quantidade = Convert.ToInt32(textBoxQuantidadeAdd.Text);
                relatorio.Valor = HelpProtesto.ResultProtesto(Convert.ToInt32(textBoxCertidãoAdd.Text), Convert.ToInt32(textBoxQuantidadeAdd.Text));
                DataBase.AddProtesto(relatorio);
                
            }
        }

        private void buttonBuscarData_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dateTimePickerInicial.Text, dateTimePickerFinal.Text);
            var Data = DataBase.GetpProtestoData(dateTimePickerInicial.Value, dateTimePickerFinal.Value);
            dataGridViewMain.DataSource = Data;
            dataGridViewMain.Columns["VALOR"].DefaultCellStyle.Format = "C2";
            dataGridViewMain.Columns[0].Visible = false;
            
            
        }
    }
}
