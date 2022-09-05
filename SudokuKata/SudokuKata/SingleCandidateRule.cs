using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuKata
{
    class SingleCandidateRule : IBoardChange
    {
        private Random RandomGenerator { get; }
        private IDictionary<int, int> MaskToOnesCount { get; }
        private IDictionary<int, int> SingleBitToIndex { get; }

        public SingleCandidateRule(Random rng, IDictionary<int, int> maskToOnesCount, IDictionary<int, int> singleBitToIndex)
        {
            RandomGenerator = rng;
            MaskToOnesCount = maskToOnesCount;
            SingleBitToIndex = singleBitToIndex;
        }

        public (bool changeMade, bool stepChangeMade, int[] nextBoard) Apply(
            int[] candidateMasks, bool changeMade, bool stepChangeMade, int[] board)
        {
            int[] singleCandidateIndices =
                candidateMasks
                    .Select((mask, index) => new
                    {
                        CandidatesCount = MaskToOnesCount[mask],
                        Index = index
                    })
                    .Where(tuple => tuple.CandidatesCount == 1)
                    .Select(tuple => tuple.Index)
                    .ToArray();

            if (singleCandidateIndices.Length > 0)
            {
                int pickSingleCandidateIndex = RandomGenerator.Next(singleCandidateIndices.Length);
                int singleCandidateIndex = singleCandidateIndices[pickSingleCandidateIndex];
                int candidateMask = candidateMasks[singleCandidateIndex];
                int candidate = SingleBitToIndex[candidateMask];

                int row = singleCandidateIndex / 9;
                int col = singleCandidateIndex % 9;

                board[singleCandidateIndex] = candidate + 1;
                candidateMasks[singleCandidateIndex] = 0;
                changeMade = true;

                Console.WriteLine("({0}, {1}) can only contain {2}.", row + 1, col + 1, candidate + 1);
            }

            return (changeMade, stepChangeMade, board);
        }
    }
}
