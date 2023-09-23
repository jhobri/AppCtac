using Minedu.Fw.NetConnect.SQL;

namespace Back.Ctac.Data.Command
{
    public abstract class CommandGenericRepository : BaseUnitOfWork
    {
        protected int? _commandTimeOutSeconds = 30;

        protected CommandGenericRepository(string connectionString) : base(connectionString)
        {
        }
    }
}