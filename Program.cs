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
                new ColorChip(Color.Blue, Color.Yellow),
                new ColorChip(Color.Red, Color.Green),
                new ColorChip(Color.Yellow, Color.Red),
                new ColorChip(Color.Orange, Color.Purple)
            };

            var result = Evaluator.CheckColorChips(chips);

            if (result.Success)
            {
                Console.WriteLine("Solution found! Use sequence: ");
                foreach (var chip in result.ChipSequence)
                {
                    Console.WriteLine(chip.ToString());
                }
            }
            else
            {
                Console.WriteLine(Constants.ErrorMessage);
            }

            Console.ReadKey();
        }
    }
}
