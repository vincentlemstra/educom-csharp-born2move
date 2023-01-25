using BornToMove.DAL;

namespace BornToMove.BLL
{
    public class MoveBL
    {
        public void AddMove(string name, string description, int sweatRate)
        {
            new MoveCrud().AddMove(name, description, sweatRate);
        }

        public Move GetMoveById(int id)
        {
            return new MoveCrud().GetMoveById(id);
        }

        public Move GetMoveByName(string name)
        {
            return new MoveCrud().GetMoveByName(name);
        }

        public List<Move> GetAllMoves()
        {
            return new MoveCrud().GetAllMoves();
        }

        public int GetMoveCount()
        {
            return new MoveCrud().GetAllMoves().Count;
        }

        public Move GetRndMove()
        {
            Random rnd = new Random();
            int max = new MoveCrud().GetAllMoves().Count;
            int id = rnd.Next(1, max);
            return new MoveCrud().GetMoveById(id);
        }
    }
}
