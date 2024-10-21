using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PS.Domain
{
    public class Facture
    {
        //1ere methode pour annoncer une clé secondaire
        [ForeignKey("Client")]
        public int CLientFK { get; set; }
        public DateTime DateAchat { get; set; }
        public float Prix { get; set; }
        public int ProductFK { get; set; }

        public virtual Client Client { get; set; }

        //2éme methode pour annoncer une clé secondaire
        [ForeignKey("ProductFK")]
        public virtual Product Product { get; set; }
    }
}
