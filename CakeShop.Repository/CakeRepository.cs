namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CakeShop.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class stores the query related to the cake table.
    /// </summary>
    public class CakeRepository : AppRepo<Cake>, ICakeRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CakeRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbContext.</param>
        public CakeRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This method adds the cake data to the table.
        /// </summary>
        /// <param name="entity">Cake.</param>
        /// <returns>int.</returns>
        public override int Add(Cake entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            this.ctx.Set<Cake>().Add(entity);
            this.ctx.SaveChanges();
            return entity.Id;
        }

        /// <summary>
        /// This method updates the cake shape in the database.
        /// </summary>
        /// <param name="cakeId">cakeId.</param>
        /// <param name="shape">Shape.</param>
        public void UpdateCakeShape(int cakeId, string shape)
        {
            var cake = this.GetOne(cakeId);
            if (cake == null)
            {
                throw new InvalidOperationException();
            }

            cake.Shape = shape;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This method updates the cake info.
        /// </summary>
        /// <param name="cakeId">cake.</param>
        /// <param name="name">cake name.</param>
        /// <param name="shape">cake shape.</param>
        /// <param name="color">cake color.</param>
        /// <param name="bakerId">cake bakerid.</param>
        /// <param name="basePrice">cake price.</param>
        public void UpdateCake(int cakeId, string name, string shape, string color, int bakerId, int basePrice)
        {
            var cake = this.GetOne(cakeId);
            if (cake == null)
            {
                throw new InvalidOperationException();
            }

            cake.Shape = shape;
            cake.Name = name;
            cake.Color = color;
            cake.BakerId = bakerId;
            cake.BasePrice = basePrice;

            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This method gets an id as parameter and shows all related cakes.
        /// </summary>
        /// <param name="id">id.</param>
        /// <returns>cake.</returns>
        public override Cake GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// This method search the cake from the list.
        /// </summary>
        /// <param name="name">Cake.</param>
        /// <returns>Cakeobj.</returns>
        public IQueryable<Cake> Search(string name)
        {
            var q = from item in this.GetAll()
                    where item.Name == name
                    select item;

            return q;
        }

        /// <summary>
        /// This is the random cake methjod, takes the fields and put inot an array.
        /// </summary>
        /// <returns>Cake.</returns>
        public Cake RandomCake()
        {
            Random rand = new Random();
            List<string> names = new List<string>() { "Choco Lava", "Red Velvet", "Mango" };
            List<string> shapes = new List<string>() { "Circle", "Square", "Heart" };
            List<string> color = new List<string>() { "Red", "Yellow", "Blue" };
            int price = rand.Next(1000, 3000);

            Cake cake = new Cake();
            cake.Name = names.ToArray()[rand.Next(names.Count)];
            cake.Price = price;
            cake.Color = color.ToArray()[rand.Next(color.Count)];
            cake.Shape = shapes.ToArray()[rand.Next(shapes.Count)];

            return cake;
        }

        /// <summary>
        /// This methos selects the cake.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>bool.</returns>
        public bool Select(int id)
        {
            var cake = this.GetOne(id);
            if (cake == null)
            {
                return false;
            }

            cake.Selected = true;
            this.ctx.SaveChanges();
            return true;
        }

        /// <summary>
        /// This method unselects the cake.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Bool.</returns>
        public bool UnSelect(int id)
        {
            var cake = this.GetOne(id);
            if (cake == null)
            {
                return false;
            }

            cake.Selected = false;
            this.ctx.SaveChanges();
            return true;
        }
    }
}