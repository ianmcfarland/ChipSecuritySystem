using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    internal static class ColorChipHelpers
    {
        public static bool HasColor(this ColorChip chip, Color color)
        {
            return chip.StartColor == color || chip.EndColor == color;
        }

        public static Color? OtherColor(this ColorChip chip, Color color)
        {
            if (chip.StartColor == color)
                return chip.EndColor;
            else if (chip.EndColor == color)
                return chip.StartColor;
            else
                return null;
        }
    }
}
