using System.Collections.Generic;
using Outsources.Enum;

namespace Outsources.Models
{
    public class TrendViewModel
    {
        public List<TrendModel> Trend { get; set; }
        public bool Done { get; set; }

        public int[] CategoryId { get; set; }
        public int[] TrendId { get; set; }
        public int NewTrend { get; set; }
        
        
    }
}