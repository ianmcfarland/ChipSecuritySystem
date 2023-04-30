using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChipSecuritySystem
{
    public class Evaluator
    {
        public static ColorChipsResult CheckColorChips(IEnumerable<ColorChip> chips)
        {
            var result = new ColorChipsResult();

            /* If input is empty OR does not have a blue (cannot start) OR does not have 
             * a green (cannot end), there is no path; return default as failure */
            if (chips.Any() 
                && chips.Where(c => c.HasColor(Color.Blue)).Any()
                && chips.Where(c => c.HasColor(Color.Green)).Any())
            {
                var blueChips = chips.Where(c => c.HasColor(Color.Blue)).ToList();
                
                /* In case of multiple blue (starter) chips, check all as starting points */
                var resultsList = new List<ColorChipsResult>();
                foreach (var blue in blueChips)
                {
                    var chipsListCopy = new List<ColorChip>(chips);
                    chipsListCopy.Remove(blue);
                    var path = new List<ColorChip>() { blue };

                    var pathResult = FindPath(blue.OtherColor(Color.Blue).Value, chipsListCopy, 0, path);
                    resultsList.Add(pathResult);
                }

                /* find the max depth where successful path */
                result = GetMax(resultsList);
            }

            return result;
        }

        private static ColorChipsResult GetMax(IEnumerable<ColorChipsResult> resultsList)
        {
            var result = new ColorChipsResult() { Success = false };

            if (resultsList.Any())
            {
                result = resultsList.Aggregate(
                    (i, j) =>
                    {
                        if (i.Success && j.Success)
                            return i.ChipsUsed > j.ChipsUsed ? i : j;
                        else if (i.Success)
                            return i;
                        else if (j.Success)
                            return j;
                        else
                            return new ColorChipsResult() { Success = false, ChipsUsed = 0 };
                    });
            }

            return result;
        }

        private static ColorChipsResult FindPath(
            Color currentColor, IList<ColorChip> chipsPool, 
            int depth, IList<ColorChip> currentPath) 
        {
            if (currentColor == Color.Green && !chipsPool.Any())
            {
                return new ColorChipsResult() { Success = true, ChipsUsed = depth + 1, ChipSequence = currentPath };
            }
            else if (!chipsPool.Any())
            {
                return new ColorChipsResult() { Success = false, ChipsUsed = depth + 1, ChipSequence = currentPath };
            }
            else if (currentColor == Color.Green)
            {
                var resultsList = new List<ColorChipsResult>();
                foreach (var match in chipsPool.Where(c => c.HasColor(currentColor)).ToList())
                {
                    var newPool = new List<ColorChip>(chipsPool);
                    newPool.Remove(match);

                    var newPath = new List<ColorChip>(currentPath);
                    newPath.Add(match);

                    var pathResult = FindPath(match.OtherColor(currentColor).Value, newPool, depth + 1, newPath);
                    resultsList.Add(pathResult);
                }
                // Aggregate on path results + current result
                resultsList.Add(new ColorChipsResult() { Success = true, ChipsUsed = depth + 1, ChipSequence = currentPath });

                return GetMax(resultsList);
            }
            else
            {
                var resultsList = new List<ColorChipsResult>();
                foreach (var match in chipsPool.Where(c => c.HasColor(currentColor)).ToList())
                {
                    var newPool = new List<ColorChip>(chipsPool);
                    newPool.Remove(match);

                    var newPath = new List<ColorChip>(currentPath);
                    newPath.Add(match);

                    var pathResult = FindPath(match.OtherColor(currentColor).Value, newPool, depth + 1, newPath);
                    resultsList.Add(pathResult);
                }
                // Aggregate on path results + current result
                return GetMax(resultsList);
            }
        }
    }
}
