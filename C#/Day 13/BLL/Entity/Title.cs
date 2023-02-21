using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Title : EntityBase
    {
		public string title_id { get; set; } = ((new Random()).Next() % 999999).ToString();
		public string title { get; set; } = "NA";
		public string type { get; set; } = "NA";
		public string pub_id { get; set; } = "0877";
		public decimal? price { get; set; } = 0;
		public decimal? advance { get; set; } = 0;
		public int? royalty { get; set; } = 0;
		public int? ytd_sales { get; set; } = 0;
		public string notes { get; set; } = "NULL";
		public DateTime? pubdate { get; set; } = DateTime.Today;
    }
}
