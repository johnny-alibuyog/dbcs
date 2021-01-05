using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CooperativeSystem.Sandbox.Models;
using CooperativeSystem.Sandbox.Models.DividendModels;

namespace CooperativeSystem.Sandbox
{
    public class DividendRepository
    {
        private IList<Member> _members;

        public DividendRepository()
        {
            _members = CreateMembers();
        }

        #region Routine Helpers

        private IList<Member> CreateMembers()
        {
            // create Member
            return new List<Member>()
            {
                new Member() 
                { 
                    FirstName = "Arwind", 
                    LastName = "Santos",
                    CapitalShares = new List<CapitalShare>()
                    {
                        new CapitalShare(){ Date = new DateTime(2009, 12, 28), Amount = 100000M, Balance = 100000M },
                        new CapitalShare(){ Date = new DateTime(2010, 5, 30), Amount = 50000M, Balance = 150000M },
                        new CapitalShare(){ Date = new DateTime(2010, 10, 31), Amount = 50000M, Balance = 200000M },
                    }
                },
                new Member()
                {
                    FirstName = "Michael", 
                    LastName = "Jordan",
                    CapitalShares = new List<CapitalShare>()
                    {
                        new CapitalShare(){ Date = new DateTime(2009, 12, 30), Amount = 40000M, Balance = 40000M },
                        new CapitalShare(){ Date = new DateTime(2010, 3, 1), Amount = 10000M, Balance = 50000M },
                        new CapitalShare(){ Date = new DateTime(2010, 8, 31), Amount = 5000M, Balance = 550000M },
                    }
                },
                new Member()
                {
                    FirstName = "Lisence", 
                    LastName = "Victa",
                    CapitalShares = new List<CapitalShare>()
                    {
                        new CapitalShare(){ Date = new DateTime(2009, 12, 1), Amount = 50000M, Balance = 50000M },
                        new CapitalShare(){ Date = new DateTime(2010, 6, 1), Amount = 50000M, Balance = 100000M },
                    }
                }
            };
        }

        #endregion

        public IList<DividendComputation> ComputeMemberDividends(int year, decimal totalDividendForDistribution)
        {
            var dividendComputations = new List<DividendComputation>();

            // compute dividend of each member
            foreach (var member in _members)
                dividendComputations.Add(new DividendComputation(year, member, totalDividendForDistribution));

            // get total average share
            var totalAverageShare = dividendComputations.Sum(dc => dc.AverageShare);

            // supply total average share to each computation
            foreach (var dividendComputation in dividendComputations)
                dividendComputation.TotalAverageShare = totalAverageShare;

            return dividendComputations;
        }

    }
}
