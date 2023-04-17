using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;


namespace Models {
    public class Produto {
        public int id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }

        public static List<Produto> Produtos { get; set; } = new List<Produto>();

        public Produto(int id, string nome, float preco) {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
        }

        public override string ToString() {
            return "Produto{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    ", preco=" + preco +
                    '}';
        }

        public static void AlteraProduto ( Produto produto) 
        {
            Produto produtoAntigo = BuscaProduto(produto.id);
            produtoAntigo.nome = produto.nome;
            produtoAntigo.preco = produto.preco;
        }

        public static Produto BuscaProduto (int id) 
        {
            Produto? produto = Produtos.Find(p => p.id == id);
            if (produto == null) {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }

        public static void RemoveProduto (int id) 
        {
            Produto produto = BuscaProduto(id);
            Produtos.Remove(produto);
        }

        public static void AdicionaProduto (Produto produto) 
        {
            Produtos.Add(produto);
        }      
    }
  
}