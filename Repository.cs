using Microsoft.EntityFrameworkCore;


namespace Repository {
    public class Context : DbContext {
        public DbSet<Models.Produto> Produtos { get; set; }
        public DbSet<Models.Almoxerifado> Almoxerifados { get; set; }  
        public DbSet<Models.Saldo> Saldos { get; set; } 
        public string connection = "Server=localhost;User Id=root;Database=Tela";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }
}