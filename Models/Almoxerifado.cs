
namespace Models {

    public class Almoxerifado {

        public int id { get; set; }
        public string nome { get; set; }

        public Almoxerifado(string nome) {
            this.nome = nome;

            Repository.Context context = new Repository.Context();
            context.Almoxerifados.Add(this);
            context.SaveChanges();
        }

        public Almoxerifado() {
            
        }

        public override string ToString() {
            return "Almoxerifado{" +
                    "id=" + id +
                    ", nome='" + nome + '\'' +
                    '}';
        }

        public static void AlteraAlmoxerifado (int id, string nome) 
        {
            Almoxerifado almoxarifadoAntigo = BuscaAlmoxerifado(id);
            almoxarifadoAntigo.nome = nome;

            Repository.Context context = new Repository.Context();
            context.Almoxerifados.Update(almoxarifadoAntigo);
            context.SaveChanges();
        }

        public static Almoxerifado BuscaAlmoxerifado (int id) 
        {
            Repository.Context context = new Repository.Context();
            Almoxerifado? almoxerifado = (from a in context.Almoxerifados where a.id == id select a).First();

            if (almoxerifado == null) {
                throw new Exception("Almoxerifado não encontrado");
            }

            return almoxerifado;
        }

        public static void DeletaAlmoxerifado (int id) 
        {
            Almoxerifado almoxerifado = BuscaAlmoxerifado(id);

            Repository.Context context = new Repository.Context();
            context.Almoxerifados.Remove(almoxerifado);
            context.SaveChanges();
        }

        public static List<Almoxerifado> ListaAlmoxerifados () 
        {
            Repository.Context context = new Repository.Context();
            List<Almoxerifado> almoxerifados = (from a in context.Almoxerifados select a).ToList();

            return almoxerifados;
        }

        
   
    }
}