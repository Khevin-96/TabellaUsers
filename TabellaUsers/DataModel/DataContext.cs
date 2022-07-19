

namespace TabellaUsers.DataModel
{
    using Microsoft.EntityFrameworkCore;
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        public DbSet<ModelUsers> Users { get; set; }

        public DbSet<ModelAzienda> Azienda { get; set; }

        public DbSet<ModelContract> Contratto { get; set; }

        public DbSet<PivotUserContract> ContractUsersPivot { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ModelUsers>()
                .Property<bool>("isDeleted");

            modelBuilder.Entity<ModelUsers>()
            .HasQueryFilter(user => EF.Property<bool>(user, "isDeleted") == false);


            modelBuilder.Entity<ModelAzienda>()
            .Property<bool>("isDeleted");

            modelBuilder.Entity<ModelAzienda>()
            .HasQueryFilter(azienda => EF.Property<bool>(azienda, "isDeleted") == false);


            modelBuilder.Entity<ModelContract>()
           .Property<bool>("isDeleted");

            modelBuilder.Entity<ModelContract>()
            .HasQueryFilter(contract => EF.Property<bool>(contract, "isDeleted") == false);

            modelBuilder.Entity<PivotUserContract>().HasKey(t => new { t.User_id, t.Contract_id });

            modelBuilder.Entity<PivotUserContract>()
           .HasOne(x => x.user)
           .WithMany(y => y.Contracts)
           .HasForeignKey(z => z.User_id);

            modelBuilder.Entity<PivotUserContract>()
            .HasOne(a => a.contract)
            .WithMany(b => b.Users)
            .HasForeignKey(c => c.Contract_id);


            modelBuilder.Entity<PivotUserContract>()
            .Property<bool>("isDeleted");

            modelBuilder.Entity<PivotUserContract>()
            .HasQueryFilter(contractuser => EF.Property<bool>(contractuser, "isDeleted") == false);

        }


        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {

            foreach (var item in ChangeTracker.Entries<PivotUserContract>())
            {
                foreach (var entry in ChangeTracker.Entries<ModelUsers>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.CurrentValues["isDeleted"] = false;
                            item.CurrentValues["isDeleted"] = false;
                            break;

                        case EntityState.Deleted:
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["isDeleted"] = true;
                            item.State=EntityState.Modified;
                            item.CurrentValues["isDeleted"] = true;
                            break;
                    }
                }

                foreach (var entryss in ChangeTracker.Entries<ModelContract>())
                {

                    switch (entryss.State)
                    {
                        case EntityState.Added:
                            entryss.CurrentValues["isDeleted"] = false;
                            item.CurrentValues["isDeleted"] = false;
                            break;

                        case EntityState.Deleted:
                            entryss.State = EntityState.Modified;
                            entryss.CurrentValues["isDeleted"] = true;
                            item.CurrentValues["isDeleted"] = true;
                            break;
                    }
                }

            }


            foreach (var entrys in ChangeTracker.Entries<ModelAzienda>())
            {
                switch (entrys.State)
                {
                    case EntityState.Added:
                        entrys.CurrentValues["isDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entrys.State = EntityState.Modified;
                        entrys.CurrentValues["isDeleted"] = true;
                        break;
                }
            }


            //foreach (var item2 in ChangeTracker.Entries<PivotUserContract>())
            //{
            //    foreach (var entryss in ChangeTracker.Entries<ModelContract>())
            //    {

            //        switch (entryss.State)
            //        {
            //            case EntityState.Added:
            //                entryss.CurrentValues["isDeleted"] = false;
            //                item2.CurrentValues["isDeleted"] = false;
            //                break;

            //            case EntityState.Deleted:
            //                entryss.State = EntityState.Modified;
            //                entryss.CurrentValues["isDeleted"] = true;
            //                item2.CurrentValues["isDeleted"] = true;
            //                break;
            //        }
            //    }
            //}

        }
    }
}
