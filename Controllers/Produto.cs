using System;
using System.Collections.Generic;
using System.Linq;

    namespace Controllers {

        public class Produto {
            public static void AdicionaProduto (int id, string nome, float preco) 
            {
                Models.Produto.AdicionaProduto(new Models.Produto(id, nome, preco));
            }

            public static void AlteraProduto (int id, string nome, float preco) 
            {
                Models.Produto.AlteraProduto(new Models.Produto(id, nome, preco));
            }
    
            public static void RemoveProduto (int id) 
            {
                Models.Produto.RemoveProduto(id);
            }
    
            public static List<Models.Produto> ListaProdutos () 
            {
                return Models.Produto.Produtos;
            }

        }

    }