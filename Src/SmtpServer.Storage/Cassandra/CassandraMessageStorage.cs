using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SmtpServer.Protocol;

namespace SmtpServer.Storage.Cassandra
{
    /// <summary>
    /// 
    /// </summary>
    public class CassandraMessageStorage : MessageStore
    {
        public override Task<SmtpResponse> SaveAsync(ISessionContext context, IMessageTransaction transaction, CancellationToken cancellationToken)
        {
            return Task.FromResult(SmtpResponse.Ok);
        }
    }
}
