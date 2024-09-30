using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListadeCompras
{
    public partial class Form1 : Form
    {
        class produto
        {
            public string nome;
            public double preco;
        }

        //contem os produtos da lista produto
        List<produto> listaProdutos;
        //contem os produtos da lista compra
        List<produto> listaCompras;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
