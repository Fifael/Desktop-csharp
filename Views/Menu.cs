using System;
using System.Windows.Forms;

namespace Views {

    public class Menu {

        public static void MenuPage() {

            Form menu = new Form();
            menu.Text = "Menu";
            menu.Size = new System.Drawing.Size(190, 150);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;

            Button btnAdd = new Button();
            btnAdd.Text = "Produtos";
            btnAdd.AutoSize = true;
            btnAdd.Location = new System.Drawing.Point(50, 25);
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
            sair.Location = new System.Drawing.Point( 50 , 60);
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

            menu.Controls.Add(btnAdd);
            menu.Controls.Add(sair);
            menu.ShowDialog();
    }



    
    }

}

