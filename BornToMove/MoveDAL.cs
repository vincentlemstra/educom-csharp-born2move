using System.Data.SqlClient;

namespace BornToMove
{
    public class MoveDAL
    {
        // class variables
        static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\vince\\source\\repos\\educom-csharp-born2move\\BornToMove\\Data\\born2move.mdf;Integrated Security=True";

        public List<Move> GetAllMoves()
        {
            List<Move> movesList = new List<Move>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, name, sweatRate FROM move", conn);

                conn.Open();
                SqlDataReader data = cmd.ExecuteReader();

                while (data.Read())
                {
                    movesList.Add(new Move
                    {
                        Id = Convert.ToInt32(data[0]),
                        Name = data[1].ToString(),
                        SweatRate = Convert.ToInt32(data[2])
                    });
                }
            }

            return movesList;
        }

        public Move GetMoveById(int Id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM move WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Move GetMove = new Move();
                        GetMove.Name = reader[1].ToString();
                        GetMove.Description = reader[2].ToString();
                        GetMove.SweatRate = Convert.ToInt32(reader[3]);
                        return GetMove;
                    }

                    return null;
                }
            }
        }

        public Move GetMoveByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM move WHERE name=@name", conn);
                cmd.Parameters.AddWithValue("@name", name);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Move GetMove = new Move();
                        GetMove.Name = reader[1].ToString();
                        GetMove.Description = reader[2].ToString();
                        GetMove.SweatRate = Convert.ToInt32(reader[3]);
                        return GetMove;
                    }

                    return null;
                }
            }
        }

        public Move SetMove(Move newMove)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO move (name, description, sweatRate) VALUES (@name, @description, @sweatRate)", conn);
                cmd.Parameters.AddWithValue("@name", newMove.Name);
                cmd.Parameters.AddWithValue("@description", newMove.Description);
                cmd.Parameters.AddWithValue("@sweatRate", newMove.SweatRate);

                conn.Open();
                newMove.Id = cmd.ExecuteNonQuery();
                return newMove;

            }
        }

        public int MoveCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT count(Id) FROM move", conn);

                conn.Open();
                var count = cmd.ExecuteScalar();
                return (int)count;
            }
        }
    }
}