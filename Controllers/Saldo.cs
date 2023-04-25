namespace Controllers {
    public class Saldo {

        public static Models.Saldo BuscaSaldo(int id) {
            return Models.Saldo.BuscaSaldo(id);
        }

        public static void Create(int produtoId, int almoxarifadoId, int quantidade) {
            try {   
                    new Models.Saldo(produtoId, almoxarifadoId, quantidade);
                } catch {
                    throw new Exception("ERRO");
                }
        }

        public static List<Models.Saldo> Read() {
            Repository.Context context = new Repository.Context();
            return (from p in context.Saldos select p).ToList();
        }
        public static void Update(int id, int produtoId, int almoxarifadoId, int quantidade) 
        {
            Models.Saldo.AlteraSaldo(id, produtoId, almoxarifadoId, quantidade);
        }

        public static void Delete(int id) {
            Models.Saldo.RemoveSaldo(id);
        }


    }
}