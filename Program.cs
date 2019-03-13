using System;using 
System.ComponentModel.DataAnnotations;
using Microsoft.Azure.Devices.Client;
using System.Net.Http;
using McMaster.Extensions.CommandLineUtils; //dotnet add package McMaster.Extensions.CommandLineUtilsusing Microsoft.Azure.Devices.Client;//dotnet add package Microsoft.Azure.Devices.Client
using Newtonsoft.Json; //dotnet add package Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
namespace IoTDeviceSimulator{    public class Program    {


        #region Properties        
        [Option("-iot", Description = "IoT Connectionstring")]
        [Required]
        public string s_deviceConnectionString { get; }
        [Option("-payload", Description = "Payload Url")]
        [Required]
        public string payload { get; }
        [Option("-transportType", Description = "Transport Type")]        
        public string transportType { get; set; } = "mqtt";        
        [Option(Description = "No. of Repeat")]        
        public int Count { get; set; } = 1;


        #endregion
        public static int Main(string[] args)
           => CommandLineApplication.Execute<Program>(args);


        private void OnExecute()
        {
            DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(s_deviceConnectionString, TransportProtocol);
            var sample = new MessageBroker(deviceClient);
            sample.RunSampleAsync(payload, Count).GetAwaiter().GetResult();            
            Console.WriteLine("Done.\n");
        }
        private TransportType TransportProtocol        
        {            
            get            
            {                
                switch (transportType.ToLower())
                {
                    case "mqtt":
                                return TransportType.Mqtt;
                    case "http":
                                return TransportType.Http1;

                    default:
                    case "amqp":                        
                        return TransportType.Amqp;
                        break;                
                }            
            }        
        }


    }

    internal class MessageBroker
    {
        private DeviceClient _deviceClient;

        public MessageBroker(DeviceClient deviceClient)
        {
            _deviceClient = deviceClient ?? throw new ArgumentNullException(nameof(deviceClient));
        }
        private dynamic DownloadFile(string url)
        {
            var wc = new System.Net.WebClient();
            var bdata = wc.DownloadData(url);
            string data = System.Text.Encoding.UTF8.GetString(bdata);
            return JsonConvert.DeserializeObject(data);
        }
        public async Task RunSampleAsync(string url, int count)
        {
            dynamic json = DownloadFile(url);
            try
            {
                await SendEvent(json, count).ConfigureAwait(false);
            }
            catch { Console.WriteLine("Exception"); }
        }

        private async Task SendEvent(dynamic json, int count)
        {
            
            try
            {
                for (int i = 0; i <= count; i++)
                    foreach (dynamic d in json)
                    {
                        Console.Write("sending...");
                        byte[] data = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(d));
                        Message eventMessage = new Message(data);
                        await _deviceClient.SendEventAsync(eventMessage).ConfigureAwait(false);
                        Console.WriteLine("...sent");
                    }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }


}