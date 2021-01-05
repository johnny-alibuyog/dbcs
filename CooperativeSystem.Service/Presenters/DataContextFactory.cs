using System.Data.Linq;
using CooperativeSystem.Service.Models;
using System.Configuration;

namespace CooperativeSystem.Service.Presenters
{
    internal class DataContextFactory : IDataContextFactory
    {
        #region IDataContextFactory Members

        public virtual DataContext CreateDataContext()
        {
            var cs = ConfigurationManager.ConnectionStrings[1];
            return new CooperativeSystemModelDataContext(cs.ConnectionString);
            //return new CooperativeSystemModelDataContext();
        }            

        #endregion
    }
}
