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
                Person person = new Person(reader.GetInt32(0));
                person.firstName = reader.GetString(1);
                person.lastName = reader.GetString(2);
                person.email = reader.GetString(3);
                person.dateBirth = reader.GetString(4);
                person.image = reader.GetString(5);
                person.country = reader.GetString(6);

                res.Add(person);
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
                    Person person = new Person(id);
                    person.firstName = reader.GetString(1);
                    person.lastName = reader.GetString(2);
                    person.email = reader.GetString(3);
                    person.dateBirth = reader.GetString(4);
                    person.image = reader.GetString(5);
                    person.country = reader.GetString(6);
                    return person;
                }
            }
            return null;

        }
    }
}
