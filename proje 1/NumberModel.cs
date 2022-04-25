namespace proje_1
{
    public class NumberModel
    {
        private string name;
        private string surName;
        private string phoneNumber;

        public NumberModel(){}
        
        public NumberModel(string name, string surName, string phoneNumber)
        {
            this.name = name;
            this.surName = surName;
            this.phoneNumber = phoneNumber;
        }

        public string Name { get => name; set => name = value; }
        public string SurName { get => surName; set => surName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    }
}