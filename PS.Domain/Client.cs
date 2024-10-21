using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PS.Domain
{
    public class Client
    {
        [Key]
        public int CIN { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateNaissance { get; set; }
        
        [EmailAddress]
        public String Mail { get; set; }
        [MaxLength(50)]
        public String Nom { get; set; }
        [MaxLength(50)]
        public String Prenom { get; set; }
        public virtual IList<Facture> Factures { get; set; }



    }
}
