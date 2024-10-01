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

        //contem os produtos da lbxProdutos
        List<produto> listaProdutos;
        //contem os produtos da lbxCompras
        List<produto> listaCompras;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lista dos produtos
            listaProdutos = new List<produto>()
            {
                new produto(){ nome = "Laranja", preco = 10},
                new produto(){ nome = "Abacaxi", preco = 25},
                new produto(){ nome = "Banana", preco = 5.5}
            };

            //insere cada produto a lbxProdutos
            foreach (produto p in listaProdutos)
            {
                lbxProdutos.Items.Add(ConstruirLinhaProduto(p));
            }

            //iniciar a compra
            IniciarCompras();

        }
        //função para formatar cada produto no laço foreach
        private string ConstruirLinhaProduto(produto p)
        {
            //formata o preço para duas casas decimais e com um cifrâo
            string preco = p.preco.ToString("0.00") + " $";
            //retorna o nome e o preço formatado
            return p.nome + new string(' ', 25 - p.nome.Length - preco.Length) + preco;
        }

        private void IniciarCompras()
        {
            //Inicia uma nova compra
            listaCompras = new List<produto>();//a lista é limpa
            lbxCompras.Items.Clear();//a lbxCompras é limpa
            lblTotal.Text = "0,00 $";//o tolal de compras é limpa
        }

        //Evento duplo click na lbxProduto
        private void lbxProdutos_DoubleClick(object sender, EventArgs e)
        {
            //se o duplo click nao acontecer, nâo retorna nada
            if (lbxProdutos.SelectedIndex == -1) return;
            //o produto p recebe um produto(indice"index") da listaProdutos e lbxProdutos
            produto p = listaProdutos[lbxProdutos.SelectedIndex];
            AdicionarProdutosCompra(p);
        }

        private void AdicionarProdutosCompra(produto p)
        {
            //adiciona um produto a compra
            listaCompras.Add(p);//adiciona um produto p a lista de compras
            lbxCompras.Items.Add(ConstruirLinhaProduto(p));//adiciona a lista a lbxCompras

            //calcular total
            var total = listaCompras.Sum(i => i.preco);//somatorio de todos os preços na listaCompras
            lblTotal.Text = total.ToString("0.00") + " $";//lblTotal recebe o total de preços formatados
        }

        //botao para limpar a lista de compras 
        private void btnNovaCompra_Click(object sender, EventArgs e)
        {
            IniciarCompras();
        }

        //botao para finalizar a compra exibindo o valor total da compra
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Compra Finalizada!" + Environment.NewLine + lblTotal.Text);
            IniciarCompras();
        }
    }
}
