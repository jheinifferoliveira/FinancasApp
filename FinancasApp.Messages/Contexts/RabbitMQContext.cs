using FinancasApp.Infra.Messages.Settings;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancasApp.Infra.Messages.Contexts
{
    public class RabbitMQContext
    {
        public IModel? CreateConnection()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = RabbitMQSettings.Host, 
                Port = RabbitMQSettings.Port,
                UserName=RabbitMQSettings.User,
                Password=RabbitMQSettings.Pass
            };

            using(var connection = connectionFactory.CreateConnection())
            {
                using(var model= connection.CreateModel())
                {
                    model.QueueDeclare(
                        queue:RabbitMQSettings.Queue,
                        durable:true,
                        autoDelete:false,
                        exclusive:false,
                        arguments:null
                        );
                    return model;
                }
            }
        }
    }
}
