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

            if (result.Success)
            {
                Console.WriteLine("Solution found! Use sequence: ");
                Console.WriteLine(result.ChipSequence);
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }
        }
    }
}
