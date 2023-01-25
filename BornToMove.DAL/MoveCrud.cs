using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BornToMove.DAL
{
    public class MoveCrud
    {
        public void AddMove(string name, string description, int sweatRate)
        {
            using (var context = new MoveContext())
            {
                var move = new Move
                {
                    Name = name,
                    Description = description,
                    SweatRate = sweatRate
                };

                context.Add(move);
                context.SaveChanges();
            }
        }

        public Move GetMoveById(int id)
        {
            using (var context = new MoveContext())
            {
                Move move = context.Moves.Single(move => move.MoveId == id);
                return move;
            }
        }

        public Move GetMoveByName(string name)
        {
            using (var context = new MoveContext())
            {
                Move move = context.Moves.Single(move => move.Name == name);
                return move;
            }
        }

        public List<Move> GetAllMoves() 
        {
            List<Move> moves = new List<Move>();
            using (var context = new MoveContext())
            {
                foreach(var move in context.Moves)
                {
                    moves.Add(new Move
                    {
                        MoveId = move.MoveId,
                        Name = move.Name,
                        Description = move.Description,
                        SweatRate = move.SweatRate
                    });
                }
                return moves;
            }
        }

        public void UpdateMove(int id, string name, string description, int sweatRate)
        {
            throw new NotImplementedException();
        }

        public void DeleteMove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
