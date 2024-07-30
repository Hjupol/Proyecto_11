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

            //dataGridView2.DataSource = null;
            //dataGridView2.DataSource = BLL.Cerveza.ListarCervezas();            
            //dataGridView3.DataSource = null;
            //dataGridView3.DataSource = BLL.Combo.ListarCombos();
        }

        private void Vaciar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            hamb = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hamb = new BE.Hamburguesa();
            hamb.Nombre = textBox1.Text;
            hamb.Detalle = textBox2.Text;
            hamb.Baja = 0;
            gestorHamburguesa.Insertar(hamb);
            Enlazar();
            Vaciar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hamb == null)
            {
                hamb = (BE.Hamburguesa)dataGridView1.CurrentRow.DataBoundItem;
                textBox1.Text = hamb.Nombre;
                textBox2.Text = hamb.Detalle;
                button1.Enabled = false;    
                button2.Enabled = false;    
            }
            else
            {
                hamb.Nombre = textBox1.Text;
                hamb.Detalle = textBox2.Text;
                hamb.Baja = 0;
                gestorHamburguesa.Editar(hamb);
                Enlazar();
                Vaciar();
                button1.Enabled = true;
                button2.Enabled = true;
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hamb = (BE.Hamburguesa)dataGridView1.CurrentRow.DataBoundItem;
            gestorHamburguesa.Borrar(hamb);
            Enlazar();
            Vaciar();
        }
    }
}
