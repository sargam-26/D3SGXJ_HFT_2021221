namespace CakeShop.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CakeShop.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// THis class stores the query related to baker table.
    /// </summary>
    public class BakerRepository : AppRepo<Baker>, IBakerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BakerRepository"/> class.
        /// </summary>
        /// <param name="ctx">DbCOntext.</param>
        public BakerRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// This method adds the baker data to the baker table.
        /// </summary>
        /// <param name="entity">Baker.</param>
        /// <returns>int.</returns>
        public override int Add(Baker entity)
        {
            if (entity == null)
            {
                throw new Exception();
            }

            this.ctx.Set<Baker>().Add(entity);
            this.ctx.SaveChanges();
            return entity.Id;
        }

        /// <summary>
        /// this method edits baker with a paticular id.
        /// </summary>
        /// <param name="id">bakerId.</param>
        /// <param name="bakerModified">Baker.</param>
        public void EditBaker(int id, Baker bakerModified)
        {
            var bakerToModified = this.GetOne(id);
            if (bakerToModified == null || bakerModified == null)
            {
                return;
            }

            bakerToModified.Name = bakerModified.Name;
            bakerToModified.Salary = bakerModified.Salary;
            bakerToModified.Position = bakerModified.Position;
            bakerToModified.Workhours = bakerModified.Workhours;
            this.ctx.SaveChanges();
        }

        /// <summary>
        /// This method returns the Baker with the particular Id.
        /// </summary>
        /// <param name="id">Baker Id.</param>
        /// <returns>Baker.</returns>
        public override Baker GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// This method updates the salary of the baker in the baker database.
        /// </summary>
        /// <param name="bakerId">BakerId.</param>
        /// <param name="salary">Salary.</param>
        public void UpdateSalary(int bakerId, int salary)
        {
            var baker = this.GetOne(bakerId);
            if (baker == null)
            {
                throw new InvalidOperationException();
            }

            baker.Salary = salary;
            this.ctx.SaveChanges();
        }
    }
}
