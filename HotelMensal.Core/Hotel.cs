namespace HotelClub.Core
{
    public class Hotel : BaseDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}