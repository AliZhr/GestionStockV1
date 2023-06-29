using System;
using System.Collections.Generic;

#nullable disable

namespace GestionStockV1.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public int StockArticleId { get; set; }
        public int ArticleQte { get; set; }

        public virtual Article StockArticle { get; set; }
    }
}
