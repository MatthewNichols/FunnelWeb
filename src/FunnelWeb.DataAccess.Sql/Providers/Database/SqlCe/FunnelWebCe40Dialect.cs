using NHibernate;
using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace FunnelWeb.DataAccess.Sql.Providers.Database.SqlCe
{
    public class FunnelWebMsSqlCe40Dialect : MsSqlCe40Dialect
    {
        public FunnelWebMsSqlCe40Dialect()
        {
            RegisterFunction("concat", new VarArgsSQLFunction(NHibernateUtil.String, "(", "+", ")"));
        }
    }
}