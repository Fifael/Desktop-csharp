using System;
using System.Collections.Generic;   
using System.Linq;
using System.Threading.Tasks;


namespace Models {

    public class Saldo {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public Almoxerifado Almoxerifado { get; set; } 
        public int AlmoxerifadoId { get; set; }
        public int Quantidade { get; set; }

        public Saldo(int produtoId, int almoxarifadoId, int quantidade) {
            this.ProdutoId = produtoId;
            this.AlmoxerifadoId = almoxarifadoId;
            this.Quantidade = quantidade;

            Repository.Context context = new Repository.Context();
            context.Saldos.Add(this);
            context.SaveChanges();
        }

        public Saldo() {
            
        }

        public override string ToString() {
            return "Saldo{" +
                    "id=" + Id +
                    ", idProduto=" + ProdutoId +
                    ", AlmoxerifadoId=" + AlmoxerifadoId +
                    ", quantidade=" + Quantidade +
                    '}';
        }

        public static void AlteraSaldo (int id, int produtoId, int almoxarifadoId, int quantidade) 
        {
            Saldo saldoAntigo = BuscaSaldo(id);
            saldoAntigo.ProdutoId = produtoId;
            saldoAntigo.AlmoxerifadoId = almoxarifadoId;
            saldoAntigo.Quantidade = quantidade;

            Repository.Context context = new Repository.Context();
            context.Saldos.Update(saldoAntigo);
            context.SaveChanges();
        }

        public static Saldo? BuscaSaldo (int id) 
        {
            Repository.Context context = new Repository.Context();
            Saldo? saldo = (from s in context.Saldos where s.Id == id select s).First();

            if (saldo == null) {
                return null;
            }

            return saldo;
        }

        public static void RemoveSaldo (int id) 
        {
            Saldo saldo = BuscaSaldo(id);

            Repository.Context context = new Repository.Context();
            context.Saldos.Remove(saldo);
            context.SaveChanges();
        }
    
    }
}