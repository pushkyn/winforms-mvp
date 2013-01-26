namespace WinformsMVP.Model
{
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", Name, Address, Phone);
        }
    }
}
