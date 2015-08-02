
namespace ConvertedListViewApp
{
    public class AddressBook
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public AddressBook(string firstname, string lastname, string address, string phone)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Address = address;
            this.Phone = phone;
        }
    }
}
