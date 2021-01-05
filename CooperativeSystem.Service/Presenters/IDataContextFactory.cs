using System.Data.Linq;

namespace CooperativeSystem.Service.Presenters
{
    internal interface IDataContextFactory
    {
        DataContext CreateDataContext();
    }
}
