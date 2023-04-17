using System;
using System.Windows.Forms;

namespace Views {
    
    public class Produtos {
        
        public static void Listar() {
            Form produtos = new Form();
            produtos.Text = "Produtos";
            produtos.Size = new System.Drawing.Size(400, 400);
            produtos.StartPosition = FormStartPosition.CenterScreen;
            produtos.FormBorderStyle = FormBorderStyle.FixedSingle;
            produtos.MaximizeBox = false;
            produtos.MinimizeBox = false;

            ListView lista = new ListView();
            lista.Size = new System.Drawing.Size(400, 300);
            lista.Location = new System.Drawing.Point(0, 0);
            lista.View = View.Details;
            lista.Columns.Add("ID", 50);
            lista.Columns.Add("Nome", 100);
            lista.Columns.Add("Preço", 100);
            lista.FullRowSelect = true;
            lista.GridLines = true;
            lista.MultiSelect = false;
            lista.HideSelection = false;

            List<Models.Produto> produtosList = Controllers.Produto.ListaProdutos();
            foreach (Models.Produto produto in produtosList) {
                ListViewItem item = new ListViewItem(produto.id.ToString());
                item.SubItems.Add(produto.nome);
                item.SubItems.Add(produto.preco.ToString());
                lista.Items.Add(item);
            }

            Button btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.Top = 300;
            btnAdd.Left = 0;
            btnAdd.Size = new System.Drawing.Size(100, 25);
            btnAdd.Click += (sender, e) => {
                Adicionar(); 
            };
            
            var produtoSelecionado = (Models.Produto)lista.SelectedItems[0].Tag;
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 300;
            btnEdit.Left = 100;
            btnEdit.Size = new System.Drawing.Size(100, 25);
            btnAdd.Click += (sender, e) => {
                Editar(produtoSelecionado.id); 
            };

            produtos.Controls.Add(lista);
            produtos.Controls.Add(btnAdd);
            produtos.Controls.Add(btnEdit);
            produtos.ShowDialog();
        } 


        public static void Adicionar() {
            Form adicionar = new Form();
            adicionar.Text = "Adicionar Produto";
            adicionar.Size = new System.Drawing.Size(400, 400);
            adicionar.StartPosition = FormStartPosition.CenterScreen;
            adicionar.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionar.MaximizeBox = false;
            adicionar.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "ID";
            lblId.Top = 0;
            lblId.Left = 0;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 0;
            txtId.Left = 100;
            txtId.Size = new System.Drawing.Size(100, 25);


            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);

            Label lblPreco = new Label();
            lblPreco.Text = "Preço";
            lblPreco.Top = 50;
            lblPreco.Left = 0;
            lblPreco.Size = new System.Drawing.Size(100, 25);

            TextBox txtPreco = new TextBox();
            txtPreco.Top = 50;
            txtPreco.Left = 100;
            txtPreco.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Produto.AdicionaProduto(int.Parse(txtId.Text), txtNome.Text, float.Parse(txtPreco.Text));
                Listar();
                adicionar.Close();
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 75;
            btnCancelar.Left = 100;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                adicionar.Close();
            };

            adicionar.Controls.Add(lblId);
            adicionar.Controls.Add(txtId);
            adicionar.Controls.Add(lblNome);
            adicionar.Controls.Add(txtNome);
            adicionar.Controls.Add(lblPreco);
            adicionar.Controls.Add(txtPreco);
            adicionar.Controls.Add(btnSalvar);
            adicionar.Controls.Add(btnCancelar);
            adicionar.ShowDialog();
        }
        public static void Editar(int id) {
            Form editar = new Form();
            editar.Text = "Editar Produto";
            editar.Size = new System.Drawing.Size(400, 400);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;

            Label lblId= new Label();
            lblId.Text = "ID";
            lblId.Top = 0;
            lblId.Left = 0;
            lblId.Size = new System.Drawing.Size(100, 25);

            TextBox txtId = new TextBox();
            txtId.Top = 0;
            txtId.Left = 100;
            txtId.Size = new System.Drawing.Size(100, 25);

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);

            Label lblPreco = new Label();
            lblPreco.Text = "Preço";
            lblPreco.Top = 50;
            lblPreco.Left = 0;
            lblPreco.Size = new System.Drawing.Size(100, 25);

            TextBox txtPreco = new TextBox();
            txtPreco.Top = 50;
            txtPreco.Left = 100;
            txtPreco.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Produto.AlteraProduto(id, txtNome.Text, float.Parse(txtPreco.Text));
                Listar();
                editar.Close();
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 75;
            btnCancelar.Left = 100;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                editar.Close();
            };

            editar.Controls.Add(lblId);
            editar.Controls.Add(txtId);
            editar.Controls.Add(lblNome);
            editar.Controls.Add(txtNome);
            editar.Controls.Add(lblPreco);
            editar.Controls.Add(txtPreco);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
            
            



    }
    }
}