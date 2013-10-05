using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelClub.Interface
{
    public interface IBaseDataModel
    {
        DateTime CreatedOn { get; set; }
        DateTime ModifiedOn { get; set; }
    }
}
