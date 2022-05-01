using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logging.Application.Services
{
    public class KafkaServices : IKafkaServices
    {
        public async Task Producer(string topic, string format, string message)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            using (var p = new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync(topic, new Message<Null, string> { Value = format + " : " + message });
                    //  Console.WriteLine($"Delivered '{dr.Value}' to '{dr.TopicPartitionOffset}'");
                }
                catch (ProduceException<Null, string> e)
                {
                     Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                }
            }
        }

        public void Consumer(string topic)
        {
            var config = new ConsumerConfig { BootstrapServers = "localhost:9092" };

            using (var c = new ConsumerBuilder<Null, string>(config).Build())
            {
                c.Subscribe(topic);
                try
                {
                    while (true)
                    {
                        try
                        {
                            var cr = c.Consume();
                            Console.WriteLine($"Consumed message '{cr.Message.Value}' at: '{cr.TopicPartitionOffset}'.");
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Error occurred: {e.Error.Reason}");

                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Ensure the consumer leaves the group cleanly and final offsets are committed.
                    c.Close();
                }
            }
        }
    }
}
