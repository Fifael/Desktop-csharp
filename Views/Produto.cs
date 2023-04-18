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
            lista.Columns.Add("Nome", 200);
            lista.Columns.Add("Preço", 145);
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
            btnAdd.BackColor = Color.Transparent;
            btnAdd.ForeColor = Color.Black;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.MouseHover += (sender, e) => {
                btnAdd.BackColor = Color.SkyBlue;
            };
            btnAdd.MouseLeave += (sender, e) => {
                btnAdd.BackColor = Color.Transparent;
            };
            btnAdd.Click += (sender, e) => {
                produtos.Close();
                produtos.Dispose();
                Adicionar();   
            };
            
            
            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Top = 300;
            btnEdit.Left = 100;
            btnEdit.Size = new System.Drawing.Size(100, 25);
            btnEdit.BackColor = Color.Transparent;
            btnEdit.ForeColor = Color.Black;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.MouseHover += (sender, e) => {
                btnEdit.BackColor = Color.SkyBlue;
            };
            btnEdit.MouseLeave += (sender, e) => {
                btnEdit.BackColor = Color.Transparent;
            };
            btnEdit.Click += (sender, e) => {
                string id = lista.SelectedItems[0].Text;
                produtos.Close();
                produtos.Dispose();
                Editar(Int32.Parse(id));
                produtos.Close();
            };


            Button BtnRemove = new Button();
            BtnRemove.Text = "Remove";
            BtnRemove.Top = 300;
            BtnRemove.Left = 200;
            BtnRemove.Size = new System.Drawing.Size(100, 25);
            BtnRemove.BackColor = Color.Transparent;
            BtnRemove.ForeColor = Color.Black;
            BtnRemove.FlatStyle = FlatStyle.Flat;
            BtnRemove.MouseHover += (sender, e) => {
                BtnRemove.BackColor = Color.SkyBlue;
            };
            BtnRemove.MouseLeave += (sender, e) => {
                BtnRemove.BackColor = Color.Transparent;
            };
            BtnRemove.Click += (sender, e) => {
                string id = lista.SelectedItems[0].Text;
                Remove(Int32.Parse(id));
                produtos.Dispose();
                produtos.Close();  
            };

            Button BtnVoltar = new Button();
            BtnVoltar.Text = "Voltar";
            BtnVoltar.Top = 300;
            BtnVoltar.Left = 300;
            BtnVoltar.Size = new System.Drawing.Size(100, 25);
            BtnVoltar.BackColor = Color.Transparent;
            BtnVoltar.ForeColor = Color.Black;
            BtnVoltar.FlatStyle = FlatStyle.Flat;
            BtnVoltar.MouseHover += (sender, e) => {
                BtnVoltar.BackColor = Color.SkyBlue;
            };
            BtnVoltar.MouseLeave += (sender, e) => {
                BtnVoltar.BackColor = Color.Transparent;
            };
            BtnVoltar.Click += (sender, e) => {
                produtos.Hide();
                produtos.Close();
                produtos.Dispose();
            };

            produtos.Controls.Add(lista);
            produtos.Controls.Add(btnAdd);
            produtos.Controls.Add(btnEdit);
            produtos.Controls.Add(BtnRemove);
            produtos.Controls.Add(BtnVoltar);
            produtos.ShowDialog();
        } 


        public static void Editar(int id) {
            Models.Produto produto = Controllers.Produto.BuscaProduto(id);
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
            txtId.Text = produto.id.ToString();

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);
            txtNome.Text = produto.nome;

            Label lblPreco = new Label();
            lblPreco.Text = "Preço";
            lblPreco.Top = 50;
            lblPreco.Left = 0;
            lblPreco.Size = new System.Drawing.Size(100, 25);

            TextBox txtPreco = new TextBox();
            txtPreco.Top = 50;
            txtPreco.Left = 100;
            txtPreco.Size = new System.Drawing.Size(100, 25);
            txtPreco.Text = produto.preco.ToString();

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                Controllers.Produto.AlteraProduto(id, txtNome.Text, float.Parse(txtPreco.Text));
                editar.Hide();
                editar.Close();
                editar.Dispose();
                Listar();
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
                adicionar.Hide();
                adicionar.Close();
                adicionar.Dispose();
                Listar();
                
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

    public static void Remove(int id) {

        Form remove = new Form();
        remove.Text = "Remover Produto";
        remove.Size = new System.Drawing.Size(100, 100);
        remove.StartPosition = FormStartPosition.CenterScreen;
        remove.FormBorderStyle = FormBorderStyle.FixedSingle;
        remove.MaximizeBox = false;
        remove.MinimizeBox = false;

        Button sim = new Button();
        sim.Text = "Sim";
        sim.Top = 0;
        sim.Left = 0;
        sim.Size = new System.Drawing.Size(50, 25);
        sim.Click += (sender, e) => {
            Controllers.Produto.RemoveProduto(id);
            remove.Close();
            remove.Dispose();
            Listar();          
        };

        Button nao = new Button();
        nao.Text = "Não";
        nao.Top = 0;
        nao.Left = 50;
        nao.Size = new System.Drawing.Size(50, 25);
        nao.Click += (sender, e) => {
            remove.Hide();
            remove.Close();
            remove.Dispose();
            Listar();
        };

        remove.Controls.Add(sim);
        remove.Controls.Add(nao);   
        remove.ShowDialog();
    }
    }
}

