using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class Mouvement
    {
        public int TransactionId { get; set; }
        public int MouvementArticleId { get; set; }
        public int Qte { get; set; }
        public string TransactipnType { get; set; }
        public int ExpediteurId { get; set; }
        public int DestinataireId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TransactionHeure { get; set; }
        public int? NumCommande { get; set; }
    }
}
