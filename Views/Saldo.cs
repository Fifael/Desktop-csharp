namespace Views {

    public class Saldo {
            
            public static void Listar() {
            Form produtos = new Form();
            produtos.Text = "Saldos";
            produtos.Size = new System.Drawing.Size(418, 366);
            produtos.StartPosition = FormStartPosition.CenterScreen;
            produtos.FormBorderStyle = FormBorderStyle.FixedSingle;
            produtos.MaximizeBox = false;
            produtos.MinimizeBox = false;

            ListView lista = new ListView();
            lista.Size = new System.Drawing.Size(400, 300);
            lista.Location = new System.Drawing.Point(0, 0);
            lista.View = View.Details;
            lista.Columns.Add("ID", 50);
            lista.Columns.Add("Produto", 110);
            lista.Columns.Add("Almoxarifado", 110);
            lista.Columns.Add("Quantidade", 125);
            lista.FullRowSelect = true;
            lista.GridLines = true;
            lista.MultiSelect = false;
            lista.HideSelection = false;


            List<Models.Saldo> saldosList = Controllers.Saldo.Read();
            foreach (Models.Saldo saldo in saldosList) {
                ListViewItem item = new ListViewItem(saldo.Id.ToString());
                item.SubItems.Add(Controllers.Produto.BuscaProduto(saldo.ProdutoId).nome);
                item.SubItems.Add(Controllers.Almoxerifado.BuscaAlmoxerifado(saldo.AlmoxerifadoId).nome);
                item.SubItems.Add(saldo.Quantidade.ToString());
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
            btnAdd.Click += delegate (object sender, EventArgs e) {
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
                produtos.Close();
                produtos.Dispose();
                Remover(Int32.Parse(id));
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


            public static void Adicionar() {
            Form adicionar = new Form();
            adicionar.Text = "Adicionar Saldo";
            adicionar.Size = new System.Drawing.Size(418, 366);
            adicionar.StartPosition = FormStartPosition.CenterScreen;
            adicionar.FormBorderStyle = FormBorderStyle.FixedSingle;
            adicionar.MaximizeBox = false;
            adicionar.MinimizeBox = false;

            Label lblProduto = new Label();
            lblProduto.Text = "Produto";
            lblProduto.Top = 25;
            lblProduto.Left = 0;
            lblProduto.Size = new System.Drawing.Size(100, 25);

            TextBox txtProduto = new TextBox();
            txtProduto.Top = 25;
            txtProduto.Left = 100;
            txtProduto.Size = new System.Drawing.Size(100, 25);

            Label lblAlmoxarifado = new Label();
            lblAlmoxarifado.Text = "Almoxarifado";
            lblAlmoxarifado.Top = 50;
            lblAlmoxarifado.Left = 0;
            lblAlmoxarifado.Size = new System.Drawing.Size(100, 25);

            TextBox txtAlmoxarifado = new TextBox();
            txtAlmoxarifado.Top = 50;
            txtAlmoxarifado.Left = 100; 
            txtAlmoxarifado.Size = new System.Drawing.Size(100, 25);

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade";
            lblQuantidade.Top = 75;
            lblQuantidade.Left = 0;
            lblQuantidade.Size = new System.Drawing.Size(100, 25);

            TextBox txtQuantidade = new TextBox();
            txtQuantidade.Top = 75;
            txtQuantidade.Left = 100;
            txtQuantidade.Size = new System.Drawing.Size(100, 25);

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 100;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Saldo.Create(Int32.Parse(txtProduto.Text), Int32.Parse(txtAlmoxarifado.Text), Int32.Parse(txtQuantidade.Text));
                    adicionar.Hide();
                    adicionar.Close();
                    adicionar.Dispose();
                    Listar(); 
                }
                catch
                {
                    MessageBox.Show("Erro ao adicionar produto");
                }
                finally 
                {
                    adicionar.Hide();
                    adicionar.Close();
                    adicionar.Dispose();
                    Listar();                    
                }
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 100;
            btnCancelar.Left = 100;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                adicionar.Close();
                adicionar.Dispose();
                adicionar.Hide();
            };

            adicionar.Controls.Add(lblProduto);
            adicionar.Controls.Add(txtProduto);
            adicionar.Controls.Add(lblAlmoxarifado);
            adicionar.Controls.Add(txtAlmoxarifado);
            adicionar.Controls.Add(lblQuantidade);
            adicionar.Controls.Add(txtQuantidade);
            adicionar.Controls.Add(btnSalvar);
            adicionar.Controls.Add(btnCancelar);
            adicionar.ShowDialog();
            }

            public static void Editar(int id) {
            Models.Saldo saldo = Controllers.Saldo.BuscaSaldo(id);
            Form editar = new Form();
            editar.Text = "Editar Saldo";
            editar.Size = new System.Drawing.Size(418, 366);
            editar.StartPosition = FormStartPosition.CenterScreen;
            editar.FormBorderStyle = FormBorderStyle.FixedSingle;
            editar.MaximizeBox = false;
            editar.MinimizeBox = false;
            
            Label lblProduto = new Label();
            lblProduto.Text = "Produto";
            lblProduto.Top = 25;
            lblProduto.Left = 0;
            lblProduto.Size = new System.Drawing.Size(100, 25);

            TextBox txtProduto = new TextBox();
            txtProduto.Top = 25;
            txtProduto.Left = 100;
            txtProduto.Size = new System.Drawing.Size(100, 25);
            txtProduto.Text = Controllers.Saldo.BuscaSaldo(id).ProdutoId.ToString();
            
            Label lblAlmoxarifado = new Label();
            lblAlmoxarifado.Text = "Almoxarifado";
            lblAlmoxarifado.Top = 50;
            lblAlmoxarifado.Left = 0;
            lblAlmoxarifado.Size = new System.Drawing.Size(100, 25);

            TextBox txtAlmoxarifado = new TextBox();
            txtAlmoxarifado.Top = 50;
            txtAlmoxarifado.Left = 100;
            txtAlmoxarifado.Size = new System.Drawing.Size(100, 25);
            txtAlmoxarifado.Text = Controllers.Saldo.BuscaSaldo(id).AlmoxerifadoId.ToString();

            Label lblQuantidade = new Label();
            lblQuantidade.Text = "Quantidade";
            lblQuantidade.Top = 75;
            lblQuantidade.Left = 0;
            lblQuantidade.Size = new System.Drawing.Size(100, 25);

            TextBox txtQuantidade = new TextBox();
            txtQuantidade.Top = 75;
            txtQuantidade.Left = 100;
            txtQuantidade.Size = new System.Drawing.Size(100, 25);
            txtQuantidade.Text = Controllers.Saldo.BuscaSaldo(id).Quantidade.ToString();

            Button btnSalvar = new Button();
            btnSalvar.Text = "Salvar";
            btnSalvar.Top = 100;
            btnSalvar.Left = 0;
            btnSalvar.Size = new System.Drawing.Size(100, 25);
            btnSalvar.Click += (sender, e) => {
                try
                {
                    Controllers.Saldo.Update(id, Int32.Parse(txtProduto.Text), Int32.Parse(txtAlmoxarifado.Text), Int32.Parse(txtQuantidade.Text));
                    editar.Hide();
                    editar.Close();
                    editar.Dispose();
                    Listar(); 
                }
                catch
                {
                    MessageBox.Show("Erro ao editar");
                }
                finally 
                {
                    editar.Hide();
                    editar.Close();
                    editar.Dispose();
                    Listar();                    
                }
            };

            Button btnCancelar = new Button();
            btnCancelar.Text = "Cancelar";
            btnCancelar.Top = 100;
            btnCancelar.Left = 100;
            btnCancelar.Size = new System.Drawing.Size(100, 25);
            btnCancelar.Click += (sender, e) => {
                editar.Close();
                editar.Dispose();
                editar.Hide();
            };

            editar.Controls.Add(lblProduto);
            editar.Controls.Add(txtProduto);
            editar.Controls.Add(lblAlmoxarifado);
            editar.Controls.Add(txtAlmoxarifado);
            editar.Controls.Add(lblQuantidade);
            editar.Controls.Add(txtQuantidade);
            editar.Controls.Add(btnSalvar);
            editar.Controls.Add(btnCancelar);
            editar.ShowDialog();
            }
            
            public static void Remover(int id) {
            Form remover = new Form();
            remover.Text = "Remover Saldo";
            remover.Size = new System.Drawing.Size(418, 366);
            remover.StartPosition = FormStartPosition.CenterScreen;
            remover.FormBorderStyle = FormBorderStyle.FixedSingle;
            remover.MaximizeBox = false;
            remover.MinimizeBox = false;

            Button sim = new Button();
            sim.Text = "Sim";
            sim.Top = 0;
            sim.Left = 0;
            sim.Size = new System.Drawing.Size(50, 25);
            sim.Click += (sender, e) => {
                try
                {
                    Controllers.Saldo.Delete(id);
                    remover.Hide();
                    remover.Close();
                    remover.Dispose();
                    Listar(); 
                }
                catch
                {
                    MessageBox.Show("Erro ao remover");
                }
                finally 
                {
                    remover.Hide();
                    remover.Close();
                    remover.Dispose();
                    Listar();                    
                }
            };

            Button nao = new Button();
            nao.Text = "Não";
            nao.Top = 0;
            nao.Left = 50;
            nao.Size = new System.Drawing.Size(50, 25); 
            nao.Click += (sender, e) => {
                remover.Hide();
                remover.Close();
                remover.Dispose();
            };


            remover.Controls.Add(sim);
            remover.Controls.Add(nao);
            remover.ShowDialog();
            }
    } 
}
