using System.Data.Entity;
using Lab1.Models;

namespace Lab1.Infrastucture
{
    public class UserContext : DbContext
    {
        public UserContext() : base("ClientDbConnection") { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountCode> AccountCodes { get; set; }

        public DbSet<AccountType> AccountTypes { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientCard> ClientCards { get; set; }

        public DbSet<ClientDepositCredit> ClientDepositCredits { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<DepositCredit> DepositCredits { get; set; }

        public DbSet<Disability> Disabilities { get; set; }

        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public DbSet<FamilyStatus> FamilyStatuses { get; set; }

        public DbSet<Nationality> Nationalities { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<AccountOperation> AccountOperations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientDepositCredit>()
                .HasRequired(x => x.MainAccount)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClientDepositCredit>()
                .HasRequired(x => x.PersentAccount)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ExchangeRate>()
            .HasRequired(x => x.StartCurrency)
            .WithMany()
            .WillCascadeOnDelete(false);

            modelBuilder.Properties<decimal>().Configure(c => c.HasPrecision(18, 6));
        }
    }
}
