﻿using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;


namespace EventBusRabbitMQ
{
    public class RabbitMQConnection : IRabbitMQConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            if(!IsConected)
            {
                TryConnect();
            }
        }
        public bool IsConected
        {
            get
            {
                return _connection != null && _connection.IsOpen && !_disposed;
            }
        }

        public IModel CreateModel()
        {
            if(!IsConected)
            {
                throw new InvalidOperationException("No rabbitMQ Connection");
            }
            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            try
            {
                _connection.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool TryConnect()
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();
            }
            catch(BrokerUnreachableException)
            {
                Thread.Sleep(2000);
                _connection = _connectionFactory.CreateConnection();
            }

            if(IsConected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
