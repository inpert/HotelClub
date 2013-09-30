using System;

namespace HotelClub.Core
{
    public class BaseDataModel
    {
        public BaseDataModel()
        {
            CreatedOn = DateTime.UtcNow;
            ModifiedOn = DateTime.UtcNow;
        }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
