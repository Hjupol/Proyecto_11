using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;


namespace GUI
{
    public partial class Form1 : Form
    {
        BE.Hamburguesa hamb;
        BLL.Hamburguesa gestorHamburguesa = new BLL.Hamburguesa();

        BE.Cerveza cerv;
        BLL.Cerveza gestorCerveza = new BLL.Cerveza();

        BE.Combo combo;
        BLL.Combo gestorCombo = new BLL.Combo();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Enlazar();
        }
        
        private void Enlazar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = BLL.Hamburguesa.ListarHamburguesas();

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = BLL.Cerveza.ListarCervezas();

            dataGridView3.DataSource = null;
            dataGridView3.DataSource = BLL.Combo.ListarCombos();
        }


    }
}
