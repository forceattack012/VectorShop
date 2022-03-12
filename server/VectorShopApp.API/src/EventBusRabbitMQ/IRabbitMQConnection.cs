using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public interface IRabbitMQConnection
    {
        bool IsConected { get; }
        bool TryConnect();
        IModel CreateModel();
        void Dispose();
    }
}
