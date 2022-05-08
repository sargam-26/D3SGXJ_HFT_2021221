namespace CakeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This is class Delivery of the database.
    /// </summary>
    [Table("Delivery")]
    public class Delivery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Delivery"/> class.
        /// Constructor.
        /// </summary>
        public Delivery()
        {
            this.Cakes = new HashSet<Cake>();
        }

        /// <summary>
        /// Gets or sets the unique ientifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the delivery man.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Person { get; set; }

        /// <summary>
        /// Gets or sets the Income of the delivery.
        /// </summary>
        public int Income { get; set; }

        /// <summary>
        /// Gets or sets the delivery minutes.
        /// </summary>
        public int Mins { get; set; }

        /// <summary>
        /// Gets or sets the schedule of the delivery person.
        /// </summary>
        public int Schedule { get; set; }

        /// <summary>
        /// Gets or sets the Cakes collection.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Cake> Cakes { get; set; }

        /// <summary>
        /// Returns the string of the class.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"{this.Id} {this.Person} {this.Income} {this.Mins} {this.Schedule}";
        }
    }
}
