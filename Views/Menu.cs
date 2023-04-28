using System;
using System.Windows.Forms;

namespace Views {

    public class Menu {

        public static void MenuPage() {
            
            Form menu = new Form();
            menu.Text = "Menu";
            menu.Size = new System.Drawing.Size(190, 215);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;

            Button btnAdd = new Button();
            btnAdd.Text = "Produtos";
            btnAdd.AutoSize = true;
            btnAdd.Location = new System.Drawing.Point(50, 20);
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
                Produtos.Listar();
            };
            
            
            Button sair = new Button();
            sair.Text = "Sair";
            sair.AutoSize = true;
            sair.Location = new System.Drawing.Point( 50 , 55);
            sair.BackColor = Color.Transparent;
            sair.ForeColor = Color.Black;
            sair.FlatStyle = FlatStyle.Flat;
            sair.MouseHover += (sender, e) => {
                sair.BackColor = Color.SkyBlue;
            };
            sair.MouseLeave += (sender, e) => {
                sair.BackColor = Color.Transparent;
            };
            sair.Click += (sender, e) => {
                menu.Close();
            };


            Button btnSaldo = new Button();
            btnSaldo.Text = "Saldo";
            btnSaldo.AutoSize = true;
            btnSaldo.Location = new System.Drawing.Point(50, 90);
            btnSaldo.BackColor = Color.Transparent;
            btnSaldo.ForeColor = Color.Black;
            btnSaldo.FlatStyle = FlatStyle.Flat;
            btnSaldo.MouseHover += (sender, e) => {
                btnSaldo.BackColor = Color.SkyBlue;
            };
            btnSaldo.MouseLeave += (sender, e) => {
                btnSaldo.BackColor = Color.Transparent;
            };
            btnSaldo.Click += (sender, e) => {
                Saldo.Listar();
            };

            Button btnAlmoxarifado = new Button();
            btnAlmoxarifado.Text = "Almoxarifado";
            btnAlmoxarifado.AutoSize = true;
            btnAlmoxarifado.Location = new System.Drawing.Point(45, 125);
            btnAlmoxarifado.BackColor = Color.Transparent;
            btnAlmoxarifado.ForeColor = Color.Black;
            btnAlmoxarifado.FlatStyle = FlatStyle.Flat;
            btnAlmoxarifado.MouseHover += (sender, e) => {
                btnAlmoxarifado.BackColor = Color.SkyBlue;
            };
            btnAlmoxarifado.MouseLeave += (sender, e) => {
                btnAlmoxarifado.BackColor = Color.Transparent;
            };  
            btnAlmoxarifado.Click += (sender, e) => {
                Almoxerifado.Listar();
            };


            menu.Controls.Add(btnAdd);
            menu.Controls.Add(sair);
            menu.Controls.Add(btnSaldo);
            menu.Controls.Add(btnAlmoxarifado);
            menu.ShowDialog();
    }
    }

}

