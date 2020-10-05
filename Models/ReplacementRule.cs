using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cipherNg.Models
{
    public class ReplacementRule
    {
        public int Id { get; set; }
        public char OldSymbol { get; set; }
        public char NewSymbol { get; set; }
    }
}
