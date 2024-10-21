using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
    public enum PackagingType
    {
        [Display(Name = "Carton")]
        Carton = 0,
        [Display(Name = "Plastic")]
        Plastic = 1
    }
    public class Product : Concept
    {
        public PackagingType Ptype { get; set; }
        public DateTime DateProd { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Category MyCategory { get; set; }
        public virtual IList<Provider> Providers { get; set; }
        public int? CategoryId { get; set; }
        public virtual IList<Facture> Factures { get; set; }

        public override void GetDetails()
        {
            System.Console.WriteLine("Name: " + Name +
                "\n Price: " + Price
                + "\n Quantity: " + Quantity);
        }

        public virtual void GetMyType()
        {
            System.Console.WriteLine("\n Product : UNKNOWN");
        }
    }
}
