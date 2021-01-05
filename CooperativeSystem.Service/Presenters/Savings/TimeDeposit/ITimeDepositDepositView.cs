﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperativeSystem.Service.Presenters.Savings.TimeDeposit
{
    public interface ITimeDepositDepositView
    {
        event EventHandler AssessmentAdd;

        decimal Amount { get; set; }
        int Terms { get; set; }
        DateTime DepositDate { get; set; }
        DateTime MaturityDate { get; set; }
    }
}
