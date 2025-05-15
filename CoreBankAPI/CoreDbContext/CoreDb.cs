using CoreBankAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreBankAPI.CoreDbContext
{
    public class CoreDb: DbContext
    {
        public CoreDb(DbContextOptions<CoreDb> options) : base(options) { }

        public virtual DbSet<UserDta> UserDta { get; set; }
        public virtual DbSet<AccoutDta> AccountDta { get; set; }
        public virtual DbSet<TransactionDta> TransactionDta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDta>(entity => 
            {
                entity.ToTable("User");
                entity.Property(a => a.Id)
                .HasColumnName("Id");
                entity.Property(a => a.FirstName)
                .HasColumnName("FirstName");
                entity.Property(a => a.MiddleName)
                .HasColumnName("MiddleName");
                entity.Property(a => a.LastName)
                .HasColumnName("LastName");
                entity.Property(a => a.LastName2)
                .HasColumnName("LastName2");
                entity.Property(a => a.Idtype)
                .HasColumnName("Idtype");
                entity.Property(a => a.Idnumber)
                .HasColumnName("Idnumber");
                entity.Property(a => a.Birthdate)
                .HasColumnName("Birthdate");
                entity.Property(a => a.Gender)
                .HasColumnName("Gender");
                entity.Property(a => a.Income)
                .HasColumnName("Income");
                entity.Property(a => a.Registered)
                .HasColumnName("Registered");
                entity.Property(a => a.Isactive)
                .HasColumnName("Isactive");
               
            });
            modelBuilder.Entity<AccoutDta>(entity =>
            {
                entity.ToTable("Account");
                entity.Property(a => a.Id)
                .HasColumnName("Id");
                entity.Property(a => a.identifier)
               .HasColumnName("identifier");
                entity.Property(a => a.UserId)
                .HasColumnName("UserId");
                entity.Property(a => a.Currency)
                .HasColumnName("Currency");
                entity.Property(a => a.Balance)
                .HasColumnName("Balance");
                entity.Property(a => a.Registered)
                .HasColumnName("Registered");
                entity.Property(a => a.Isactive)
                .HasColumnName("Isactive");            
            });

            modelBuilder.Entity<TransactionDta>(entity => 
            {
                entity.ToTable("Transaction");
                entity.Property(a => a.Id)
                .HasColumnName("Id");
                entity.Property(a => a.AccountId)
                .HasColumnName("Accountid");
                entity.Property(a => a.Type)
                .HasColumnName("Type");
                entity.Property(a => a.Amount)
                .HasColumnName("Amount");
                entity.Property(a => a.Description)
                .HasColumnName("Description");
                entity.Property(a => a.Isreversed)
                .HasColumnName("Isreversed");
                entity.Property(a => a.identifier)
                .HasColumnName("identifier");
                entity.HasOne(a => a.Account)
               .WithMany(u => u.Transactions)
               .HasForeignKey(t => t.AccountId);
            });


            modelBuilder.Entity<UserDta>()
            .HasOne(u => u.account)
            .WithOne(a => a.User)
            .HasForeignKey<AccoutDta>(a => a.UserId);
        }
    }
}
