using Minedu.Fw.NetConnect.SQL;

namespace Back.Ctac.Data.Query
{
    public abstract class QueryGenericRepository : BaseUnitOfWork
    {
        protected int? _commandTimeOutSeconds = 30;

        protected QueryGenericRepository(string connectionString) : base(connectionString)
        {
        }
    }
}