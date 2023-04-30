using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Usage: */

            var chips = new List<ColorChip>
            {
                /* Your set of chips here */
            };

            var result = Evaluator.CheckColorChips(chips);

            Console.WriteLine($"Solution found? { (result.Success ? "Yes!" : "No") }");
            Console.WriteLine(result.ChipSequence);

        }
    }
}
