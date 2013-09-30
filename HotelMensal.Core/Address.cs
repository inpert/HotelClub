namespace HotelClub.Core
{
    public class Address : BaseDataModel
    {
        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public Country Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}