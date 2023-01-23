namespace BornToMove
{
    public class MoveBLL
    {
        public List<Move> GetAllMoves()
        {
            return new MoveDAL().GetAllMoves();
        }

        public Move GetMoveById(int Id)
        {
            return new MoveDAL().GetMoveById(Id);
        }

        public Move GetMoveByName(string name)
        {
            return new MoveDAL().GetMoveByName(name);
        }

        public Move SetMove(Move newMove)
        {
            return new MoveDAL().SetMove(newMove);
        }

        public int GetMoveCount()
        {
            return new MoveDAL().MoveCount();
        }
    }
}