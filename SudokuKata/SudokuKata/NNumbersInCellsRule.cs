using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuKata
{
    class NNumbersInCellsRule : IBoardChange
    {
        private IDictionary<int, int> MaskToOnesCount { get; }
        private IEnumerable CellGroups { get; }

        public NNumbersInCellsRule(IDictionary<int, int> maskToOnesCount, IEnumerable cellGroups)
        {
            MaskToOnesCount = maskToOnesCount;
            CellGroups = cellGroups;
        }

        public (bool changeMade, bool stepChangeMade, int[] nextBoard) Apply(int[] candidateMasks, bool changeMade,
            bool stepChangeMade, int[] board)
        {
            //if (!changeMade && !stepChangeMade)
            //{
            //    IEnumerable<int> masks =
            //        MaskToOnesCount
            //            .Where(tuple => tuple.Value > 1)
            //            .Select(tuple => tuple.Key).ToList();

            //    var groupsWithNMasks =
            //        masks
            //            .SelectMany(mask =>
            //                CellGroups
            //                    .Where(group => group.All(cell => board[cell.Index] == 0 || (mask & (1 << (board[cell.Index] - 1))) == 0))
            //                    .Select(group => new
            //                    {
            //                        Mask = mask,
            //                        Description = group.First().Description,
            //                        Cells = group,
            //                        CellsWithMask =
            //                            group.Where(cell => board[cell.Index] == 0 && (candidateMasks[cell.Index] & mask) != 0).ToList(),
            //                        CleanableCellsCount =
            //                            group.Count(
            //                                cell => board[cell.Index] == 0 &&
            //                                    (candidateMasks[cell.Index] & mask) != 0 &&
            //                                    (candidateMasks[cell.Index] & ~mask) != 0)
            //                    }))
            //            .Where(group => group.CellsWithMask.Count() == MaskToOnesCount[group.Mask])
            //            .ToList();

            //    foreach (var groupWithNMasks in groupsWithNMasks)
            //    {
            //        int mask = groupWithNMasks.Mask;

            //        if (groupWithNMasks.Cells
            //            .Any(cell =>
            //                (candidateMasks[cell.Index] & mask) != 0 &&
            //                (candidateMasks[cell.Index] & ~mask) != 0))
            //        {
            //            StringBuilder message = new StringBuilder();
            //            message.Append($"In {groupWithNMasks.Description} values ");

            //            string separator = string.Empty;
            //            int temp = mask;
            //            int curValue = 1;
            //            while (temp > 0)
            //            {
            //                if ((temp & 1) > 0)
            //                {
            //                    message.Append($"{separator}{curValue}");
            //                    separator = ", ";
            //                }
            //                temp = temp >> 1;
            //                curValue += 1;
            //            }

            //            message.Append(" appear only in cells");
            //            foreach (var cell in groupWithNMasks.CellsWithMask)
            //            {
            //                message.Append($" ({cell.Row + 1}, {cell.Column + 1})");
            //            }

            //            message.Append(" and other values cannot appear in those cells.");

            //            Console.WriteLine(message.ToString());
            //        }

            //        foreach (var cell in groupWithNMasks.CellsWithMask)
            //        {
            //            int maskToClear = candidateMasks[cell.Index] & ~groupWithNMasks.Mask;
            //            if (maskToClear == 0)
            //                continue;

            //            candidateMasks[cell.Index] &= groupWithNMasks.Mask;
            //            stepChangeMade = true;

            //            int valueToClear = 1;

            //            string separator = string.Empty;
            //            StringBuilder message = new StringBuilder();

            //            while (maskToClear > 0)
            //            {
            //                if ((maskToClear & 1) > 0)
            //                {
            //                    message.Append($"{separator}{valueToClear}");
            //                    separator = ", ";
            //                }
            //                maskToClear = maskToClear >> 1;
            //                valueToClear += 1;
            //            }

            //            message.Append($" cannot appear in cell ({cell.Row + 1}, {cell.Column + 1}).");
            //            Console.WriteLine(message.ToString());

            //        }
            //    }
            //}

            return (changeMade, stepChangeMade, board);
        }
    }
}