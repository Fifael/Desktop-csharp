using System;
using System.Collections.Generic;
using System.Linq;

    namespace Controllers {

        public class Produto {
            public static void AdicionaProduto (string nome, float preco) 
            {
                try {   
                    new Models.Produto(nome, preco);
                } catch {
                    throw new Exception("ERRO");
                }
            }

            public static void AlteraProduto (int id, string nome, float preco) 
            {
                Models.Produto.AlteraProduto(id, nome, preco);
            }
    
            public static void RemoveProduto (int id) 
            {
                Models.Produto.RemoveProduto(id);
            }

            public static Models.Produto BuscaProduto (int id) 
            {
                return Models.Produto.BuscaProduto(id);
            }
    
            public static List<Models.Produto> ListaProdutos () 
            {
                Repository.Context context = new Repository.Context();
                return (from p in context.Produtos select p).ToList();
            }

        }

    }