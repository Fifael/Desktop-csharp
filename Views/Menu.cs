using System;
using System.Windows.Forms;

namespace Views {

    public class Menu {

        public static void MenuPage() {

            Form menu = new Form();
            menu.Text = "Menu";
            menu.Size = new System.Drawing.Size(300, 300);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;

            Button btnAdd = new Button();
            btnAdd.Text = "Produtos";
            btnAdd.Size = new System.Drawing.Size(100, 50);
            btnAdd.Location = new System.Drawing.Point(100, 100);
            btnAdd.Click += (sender, e) => {
                Produtos.Listar();
            };
            
            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new System.Drawing.Size(100, 50);
            sair.Location = new System.Drawing.Point(100, 200);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(btnAdd);
            menu.Controls.Add(sair);
            menu.ShowDialog();
    }



    
    }

}

