using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class Article
    {
        public Article()
        {
            Stocks = new HashSet<Stock>();
        }

        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleDescription { get; set; }
        public int ArticleSeuilSecurite { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }

    

}
