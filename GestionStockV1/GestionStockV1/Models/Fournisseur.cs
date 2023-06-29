using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class Fournisseur
    {
        public int FournisseurId { get; set; }
        public string FournisseurName { get; set; }
        public int NumeroFournisseur { get; set; }
        public bool Actif { get; set; }
    }
}
