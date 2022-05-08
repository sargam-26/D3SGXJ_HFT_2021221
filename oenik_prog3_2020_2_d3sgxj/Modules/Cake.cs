namespace CakeShop.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    /// <summary>
    /// This class acts as the table in the database.
    /// </summary>
    [Table("Cake")]
    public class Cake
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cake"/> class.
        /// Constructor.
        /// </summary>
        public Cake()
        {
            this.Bakers = new HashSet<Baker>();
        }

        /// <summary>
        /// Gets or sets the unique indentifier.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("cake_id", TypeName = "int")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the shape of the cake.
        /// </summary>
        public string Shape { get; set; }

        /// <summary>
        /// Gets or sets the color of the cake.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the price of the cake.
        /// </summary>
        public int? Price { get; set; }

        /// <summary>
        /// Gets or sets the delivery id.
        /// </summary>
        [ForeignKey(nameof(Delivery))]

        public int DeliveryId { get; set; }

        /// <summary>
        /// Gets or sets the delivery.
        /// </summary>
        [NotMapped]
        public virtual Delivery Delivery { get; set; }

        /// <summary>
        /// Gets or sets the baker id.
        /// </summary>
        [ForeignKey(nameof(Baker))]

        public int BakerId { get; set; }

        /// <summary>
        /// Gets or sets the baker.
        /// </summary>
        [NotMapped]
        public virtual Baker Baker { get; set; }

        /// <summary>
        /// Gets or sets the bakers.
        /// </summary>
        [NotMapped]
        public virtual ICollection<Baker> Bakers { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether gets or sets the cake whether it is selected.
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Gets or sets the Baseprice.
        /// </summary>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// ToString method.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return $"{this.Id} {this.Name} {this.Shape} {this.Price}";
        }
    }
}
