using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Models
{
    partial class DividendPatronageRatio
    {
        partial void OnCreated()
        {
            this.DividendRatio = 60;
            this.PatronageRatio = 40;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (DividendRatio + PatronageRatio != 100)
                throw new Exception("Invalid Ratio. Sum must be equal to 100.");
        }
    }
}
