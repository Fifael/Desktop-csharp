using System;
using System.Windows.Forms;

namespace Views {

    public class Almoxerifado {

        public static bool isOpen = false;
        public static Form produtos;

        public static void Listar() {
            Form produtos = new Form();
            produtos.Text = "Almoxerifado";
            produtos.Size = new System.Drawing.Size(418, 366);
            produtos.StartPosition = FormStartPosition.CenterScreen;
            produtos.FormBorderStyle = FormBorderStyle.FixedSingle;
            produtos.MaximizeBox = false;
            produtos.MinimizeBox = false;
    

            ListView lista = new ListView();
            lista.Size = new System.Drawing.Size(400, 300);
            lista.Location = new System.Drawing.Point(0, 0);
            lista.View = View.Details;
            lista.Columns.Add("ID", 30);
            lista.Columns.Add("Nome", 200);
            lista.FullRowSelect = true;
            lista.GridLines = true;
            lista.MultiSelect = false;
            lista.HideSelection = false;

            List<Models.Almoxerifado> almoxerifadoList = Controllers.Almoxerifado.ListaAlmoxerifados();
            foreach (Models.Almoxerifado almoxerifado in almoxerifadoList) {
                ListViewItem item = new ListViewItem(almoxerifado.id.ToString());
                item.SubItems.Add(almoxerifado.nome);
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
                try
                {
                    string id = lista.SelectedItems[0].Text;
                    produtos.Close();
                    produtos.Dispose();
                    Editar(Int32.Parse(id));
                    produtos.Close(); 
                }
                catch
                {
                    MessageBox.Show("Selecione um Almoxerifado para editar");
                }
                
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
                try
                {
                    string id = lista.SelectedItems[0].Text;
                    produtos.Close();
                    produtos.Dispose();
                    Remover(Int32.Parse(id));
                    produtos.Close();  
                }
                catch
                {
                    MessageBox.Show("Selecione um Almoxerifado para remover");
                }
                      
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


        public static void Adicionar() {
            Form adicionar = new Form();
            adicionar.Text = "Adicionar Almoxerifado";
            adicionar.Size = new System.Drawing.Size(418, 366);
            adicionar.StartPosition = FormStartPosition.CenterScreen;
            adicionar.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionar.MaximizeBox = false;
            adicionar.MinimizeBox = false;

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                    Controllers.Almoxerifado.AdicionaAlmoxerifado(txtNome.Text);
                    adicionar.Hide();
                    adicionar.Close();
                    adicionar.Dispose();
                    Listar();   
            };

            Button btnVoltar = new Button();
            btnVoltar.Text = "Cancelar";
            btnVoltar.Top = 75;
            btnVoltar.Left = 100;
            btnVoltar.Size = new System.Drawing.Size(100, 25);
            btnVoltar.Click += (sender, e) => {
                adicionar.Close();
            };

            adicionar.Controls.Add(lblNome);
            adicionar.Controls.Add(txtNome);
            adicionar.Controls.Add(btnSalvar);
            adicionar.Controls.Add(btnVoltar);
            adicionar.ShowDialog();
        }

        public static void Editar(int id) {
            Models.Almoxerifado almoxerifado = Controllers.Almoxerifado.BuscaAlmoxerifado(id);
            Form editar = new Form();
            editar.Text = "Editar Almoxerifado";
            editar.Size = new System.Drawing.Size(418, 366);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);
            txtNome.Text = almoxerifado.nome;

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 75;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                    Controllers.Almoxerifado.AlteraAlmoxerifado(id, txtNome.Text);
                    editar.Hide();
                    editar.Close();
                    editar.Dispose();
                    Listar();   
            };

            Button btnVoltar = new Button();
            btnVoltar.Text = "Cancelar";
            btnVoltar.Top = 75;
            btnVoltar.Left = 100;
            btnVoltar.Size = new System.Drawing.Size(100, 25);
            btnVoltar.Click += (sender, e) => {
                editar.Close();
            };

            editar.Controls.Add(lblNome);
            editar.Controls.Add(txtNome);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnVoltar);
            editar.ShowDialog();
        }

        public static void Remover(int id) {
            Form remover = new Form();
            remover.Text = "Remover Almoxerifado";
            remover.Size = new System.Drawing.Size(418, 366);
            remover.StartPosition = FormStartPosition.CenterScreen;
            remover.FormBorderStyle = FormBorderStyle.FixedSingle;
            remover.MaximizeBox = false;
            remover.MinimizeBox = false;

            Label lblNome = new Label();
            lblNome.Text = "Nome";
            lblNome.Top = 25;
            lblNome.Left = 0;
            lblNome.Size = new System.Drawing.Size(100, 25);

            TextBox txtNome = new TextBox();
            txtNome.Top = 25;
            txtNome.Left = 100;
            txtNome.Size = new System.Drawing.Size(100, 25);
            txtNome.Text = Controllers.Almoxerifado.BuscaAlmoxerifado(id).nome;
            txtNome.Enabled = false;

            Button btnRemover = new Button();
            btnRemover.Text = "Remover";
            btnRemover.Top = 75;
            btnRemover.Left = 0;
            btnRemover.Size = new System.Drawing.Size(100, 25);
            btnRemover.Click += (sender, e) => {
                    Controllers.Almoxerifado.DeletaAlmoxerifado(id);
                    remover.Hide();
                    remover.Close();
                    remover.Dispose();
                    Listar();   
            };

            Button btnVoltar = new Button();
            btnVoltar.Text = "Cancelar";
            btnVoltar.Top = 75;
            btnVoltar.Left = 100;
            btnVoltar.Size = new System.Drawing.Size(100, 25);
            btnVoltar.Click += (sender, e) => {
                if(isOpen){
                    remover.Close();
                    produtos.Close();
                    produtos.Dispose();
                }    
                Listar();
            };
            remover.Controls.Add(lblNome);
            remover.Controls.Add(txtNome);
            remover.Controls.Add(btnRemover);
            remover.Controls.Add(btnVoltar);
            remover.ShowDialog();
        }
    }
}
