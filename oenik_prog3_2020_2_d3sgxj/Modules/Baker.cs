namespace CakeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    /// <summary>
    /// This piece of code act as the table of the bakers information in the Cake database.
    /// </summary>
    [Table("Baker")]
    public class Baker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Baker"/> class.
        /// </summary>
        public Baker()
        {
            this.Cakes = new HashSet<Cake>();
        }

        /// <summary>
        /// this method duplicate info of baker.
        /// </summary>
        /// <param name="baker">Baker.</param>
        public void CopyFrom(Baker baker)
        {
            this.Id = baker.Id;
            this.Name = baker.Name;
            this.Salary = baker.Salary;
            this.Workhours = baker.Workhours;
            this.Cakes = baker.Cakes;
        }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name of the baker.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the salary of the baker.
        /// </summary>
        public int Salary { get; set; }

        /// <summary>
        /// gets or sets position of the baker.
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// gets or sets the workhours of the baker.
        /// </summary>
        public int Workhours { get; set; }

        /// <summary>
        /// Gets or sets Cakes.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Cake> Cakes { get; set; }

        /// <summary>
        /// Returns the string of this class.
        /// </summary>
        /// <returns>String. </returns>
        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.Salary} {this.Position} {this.Workhours}";
        }
    }
}
