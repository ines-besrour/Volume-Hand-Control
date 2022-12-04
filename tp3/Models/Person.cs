namespace tp3.Models
{
    public class Person
    {
        // id, first_name, last_name, email, date_birth, image, country
        private int _id;
        private string _firstName, _lastName, _email, _dateBirth, _image, _country;

        public int id {  get { return _id; } }
        public string firstName { get { return _firstName; } set { _firstName = value; }  }
        public string lastName { get { return _lastName; } set { _lastName = value; } }
        public string email { get { return _email; } set { _email = value; } }
        public string dateBirth { get { return _dateBirth; } set { _dateBirth = value; } }
        public string image { get { return _image; } set { _image = value; }  }
        public string country {  get { return _country; } set { _country = value; } }

        public Person(int id)
        {
            this._id = id;
        }
    }
}
