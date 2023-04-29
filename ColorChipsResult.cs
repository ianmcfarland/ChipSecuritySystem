using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public  class ColorChipsResult
    {
        public bool Success { get; set; }
        public int ChipsUsed { get; set; }
        public IList<ColorChip> ChipSequence { get; set; } = new List<ColorChip>();
    }
}
