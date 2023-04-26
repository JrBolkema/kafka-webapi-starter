using Confluent.Kafka;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace kafka_webapi_backend.Helpers
{
    public class ProducerHelper
    {
        private string _topicName;
        private IProducer<string,string> _producer;
        private ProducerConfig _config;

        public ProducerHelper(ProducerConfig config,string topicName)
        {
            this._topicName = topicName;
            this._config = config;
            this._producer = new ProducerBuilder<string, string>(this._config).Build();
        }
        public async Task SendMessage(string key,string message){
            var res = await this._producer.ProduceAsync(this._topicName, new Message<string, string>()
                        {
                            Key = key,
                            Value = message
                        });
            Console.WriteLine($"KAFKA => Delivered '{res.Value}' to '{res.TopicPartitionOffset}'");
            return;
        }
    }
}