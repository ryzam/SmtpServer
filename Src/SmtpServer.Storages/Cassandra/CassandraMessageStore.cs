using Cassandra;
using SmtpServer.Protocol;
using SmtpServer.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmtpServer.Storages.Cassandra
{
    public class CassandraMessageStorage : MessageStore
    {
        public override Task<SmtpResponse> SaveAsync(ISessionContext context, IMessageTransaction transaction, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello from Cassandra");

            var cluster = Cluster.Builder()
              .AddContactPoint("127.0.0.1").WithPort(9042)
              .Build();

            var session = cluster.Connect("nextgenmail");

            var mailMessage = $"INSERT INTO emailmessage (id, fromadd, toadd, message) VALUES ({Guid.NewGuid()},'{transaction.From.User}@{transaction.From.Host}','{transaction.To[0].User}@{transaction.To[0].Host}','{transaction.Message.ToString()}')";

            session.Execute(mailMessage);
           
            return Task.FromResult(SmtpResponse.Ok);
        }
    }
}
