using System.Data.SQLite;

namespace tp3.Models
{
    public class Personal_info
    {
        private static readonly string dbConfig = "Data Source=C:\\Users\\heha\\OneDrive\\Desktop\\GL3\\tp3.db";
        public static List<Person> GetAllPerson()
        {
            SQLiteConnection conn = new SQLiteConnection(dbConfig);
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Person> res = new List<Person>();
            while (reader.Read())
            {
                Person tmp = new Person(reader.GetInt32(0));
                tmp.firstName = reader.GetString(1);
                tmp.lastName = reader.GetString(2);
                tmp.email = reader.GetString(3);
                tmp.dateBirth = reader.GetString(4);
                tmp.image = reader.GetString(5);
                tmp.country = reader.GetString(6);

                res.Add(tmp);
            }

            conn.Close();
            return res;
        }
        public static Person? GetPerson(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbConfig))
            {
                conn.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info where id=@id", conn);
                cmd.Parameters.Add(new SQLiteParameter("@id", id));

                SQLiteDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Person res = new Person(id);
                    res.firstName = reader.GetString(1);
                    res.lastName = reader.GetString(2);
                    res.email = reader.GetString(3);
                    res.dateBirth = reader.GetString(4);
                    res.image = reader.GetString(5);
                    res.country = reader.GetString(6);
                    return res;
                }
            }
            return null;

        }
    }
}
