using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
    }
}
