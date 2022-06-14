namespace SampleAPI.Shared.Helpers
{
    public class DbHelper : DbContext
    {
        public DbSet<NotesModel> Notes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Sample;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("ConnectionString") ?? throw new InvalidOperationException());
        }
        
    }
    
}
