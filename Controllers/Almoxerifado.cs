using Models;

namespace Controllers {
    public class Almoxerifado {
    
        public static Models.Almoxerifado BuscaAlmoxerifado(int id) {
            return Models.Almoxerifado.BuscaAlmoxerifado(id);
        }

        public static void AlteraAlmoxerifado(int id, string nome) {
            Models.Almoxerifado.AlteraAlmoxerifado(id, nome);
        }

        public static void DeletaAlmoxerifado(int id) {
            Models.Almoxerifado.DeletaAlmoxerifado(id);
        }

        public static void AdicionaAlmoxerifado(string nome) {
            try {   
                    new Models.Almoxerifado(nome);
                } catch {
                    throw new Exception("ERRO");
                }
        }

        public static List<Models.Almoxerifado> ListaAlmoxerifados () {
            Repository.Context context = new Repository.Context();
            return (from a in context.Almoxerifados select a).ToList();
        }

    }
}