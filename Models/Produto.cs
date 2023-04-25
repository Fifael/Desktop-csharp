using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;


namespace Models {
    public class Produto {
        public int id { get; set; }
        public string nome { get; set; }
        public float preco { get; set; }

        public Produto(string nome, float preco) {
            this.nome = nome;
            this.preco = preco;
           
            Repository.Context context = new Repository.Context();
            context.Produtos.Add(this);
            context.SaveChanges();
        }

        public Produto() {
            
        }

        public override string ToString() {
            return "Produto{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    ", preco=" + preco +
                    '}';
        }

        public static void AlteraProduto (int id, string nome, float preco) 
        {
            Produto produtoAntigo = BuscaProduto(id);
            produtoAntigo.nome = nome;
            produtoAntigo.preco = preco;

            Repository.Context context = new Repository.Context();
            context.Produtos.Update(produtoAntigo);
            context.SaveChanges();
        }

        public static Produto BuscaProduto (int id) 
        {
            Repository.Context context = new Repository.Context();
            Produto? produto = (from p in context.Produtos where p.id == id select p).First();

            if (produto == null) {
                throw new Exception("Produto não encontrado");
            }

            return produto;
        }

        

        public static void RemoveProduto (int id) 
        {
            Produto produto = BuscaProduto(id);
            
            Repository.Context context = new Repository.Context();
            context.Produtos.Remove(produto);
            context.SaveChanges();
        }
  
    }
  
}