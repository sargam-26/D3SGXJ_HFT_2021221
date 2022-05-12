namespace CakeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class makes the model of the database.
    /// </summary>
    public partial class CakeDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CakeDbContext"/> class.
        /// Constructor.
        /// </summary>
        public CakeDbContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the delivery.
        /// </summary>
        ///
        public virtual DbSet<Delivery> Deliveries { get; set; }

        /// <summary>
        /// Gets or sets the cakes.
        /// </summary>
        public virtual DbSet<Cake> Cakes { get; set; }

        /// <summary>
        /// Gets or sets the bakers.
        /// </summary>
        public virtual DbSet<Baker> Bakers { get; set; }

        /// <summary>
        /// This connects the database with the application.
        /// </summary>
        /// <param name="optionsBuilder">OptionBuilder.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;  AttachDbFilename= |DataDirectory|\CakesDb.mdf;  Integrated Security=True; MultipleActiveResultSets= true");
                }
            }

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Creates the model of the database.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new Exception();
            }

            // modelBuilder.Entity<Cake>(entity =>
            // {
            //    entity.HasOne(cake => cake.Delivery).
            //                    WithMany(delivery => delivery.Cakes).
            //                    HasForeignKey(cake => cake.DeliveryId).
            //                    OnDelete(DeleteBehavior.ClientSetNull);
            // });
            // modelBuilder.Entity<Cake>(entity =>
            // {
            //    entity.HasOne(cake => cake.Baker).
            //                    WithMany(baker => baker.Cakes).
            //                    HasForeignKey(cake => cake.BakerId).
            //                    OnDelete(DeleteBehavior.ClientSetNull);
            // });
            Delivery tom = new Delivery() { Id = 1, Person = "Tom", Income = 5000, Mins = 30, Schedule = 2020 - 02 - 12 };
            Delivery kim = new Delivery() { Id = 2, Person = "Kim", Income = 4000, Mins = 40, Schedule = 2020 - 03 - 14 };
            Delivery norbi = new Delivery() { Id = 3, Person = "Norbi", Income = 3800, Mins = 45, Schedule = 2020 - 02 - 19 };
            Delivery tina = new Delivery() { Id = 4, Person = "Tina", Income = 6500, Mins = 25, Schedule = 2020 - 07 - 26 };
            Delivery rita = new Delivery() { Id = 5, Person = "Rita", Income = 4000, Mins = 40, Schedule = 2020 - 06 - 16 };

            Cake chocolate = new Cake() { Id = 1, DeliveryId = 1, BakerId = 1, Name = "Chocolate", Shape = " Round", Color = "Brown", Price = 4500 };
            Cake vanilla = new Cake() { Id = 2, DeliveryId = 3, BakerId = 4, Name = "Vanilla", Shape = " Round", Color = "White", Price = 3000 };
            Cake cheesecake = new Cake() { Id = 3, DeliveryId = 5, BakerId = 3, Name = "Cheesecake", Shape = " Rectangle", Color = "Purple", Price = 5000 };
            Cake fruitcake = new Cake() { Id = 4, DeliveryId = 2, BakerId = 5, Name = "Fruitcake", Shape = " Heart", Color = "Pink", Price = 4500 };
            Cake blueberry = new Cake() { Id = 5, DeliveryId = 4, BakerId = 2, Name = "Blueberry", Shape = " Round", Color = "Blue", Price = 6500 };

            Baker roby = new Baker() { Id = 1, Name = "Roby", Salary = 40000, Position = "head", Workhours = 6 };
            Baker lana = new Baker() { Id = 2, Name = "Lana", Salary = 50000, Position = "assistant", Workhours = 7 };
            Baker ritu = new Baker() { Id = 3, Name = "Ritu", Salary = 60000, Position = "new", Workhours = 6 };
            Baker dani = new Baker() { Id = 4, Name = "Dani", Salary = 70000, Position = "head", Workhours = 5 };
            Baker peter = new Baker() { Id = 5, Name = "Peter", Salary = 40000, Position = "assitant", Workhours = 8 };

            modelBuilder.Entity<Cake>().HasData(chocolate, vanilla, cheesecake, fruitcake, blueberry);
            modelBuilder.Entity<Delivery>().HasData(tom, kim, norbi, tina, rita);
            modelBuilder.Entity<Baker>().HasData(roby, lana, ritu, dani, peter);
        }
    }
}
