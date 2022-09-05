namespace SudokuKata
{
    interface IBoardChange
    {
        (bool changeMade, bool stepChangeMade, int[] nextBoard) Apply(
            int[] candidateMasks, bool changeMade, bool stepChangeMade, int[] board);
    }
}