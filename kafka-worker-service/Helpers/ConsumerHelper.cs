using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace kafka_worker_service.Helpers
{
    public class ConsumerHelper
    {
        private string _topicName;
        private IConsumer<string,string> _consumer;
        private ConsumerConfig _config;

        public ConsumerHelper(ConsumerConfig config,string topicName)
        {
            this._topicName = topicName;
            this._config = config;
            this._consumer = new ConsumerBuilder<string, string>(this._config).Build();
            this._consumer.Subscribe(topicName);
        }
        public string ReadMessage()
        {
            var res = this._consumer.Consume();
            return res.Message.Value;
        }
    }
}