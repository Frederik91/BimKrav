using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BimKrav.Server
{
    public interface IMySqlDbConnection
    {
        Task<List<T>> ExecuteQuery<T>(string sql, CancellationToken cancellationToken = default);
    }
}