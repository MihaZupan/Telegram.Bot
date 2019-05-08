using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;
using System.Text.Json.Serialization;
using Telegram.Bot.Types;

namespace Performance
{
    class Program
    {
        static void Main()
        {
#if DEBUG
            var test = new NewtonsoftVsNative();
            test.Setup();
            test.NewtonsoftJson();
            test.SystemTextJson();
#else
            BenchmarkRunner.Run<NewtonsoftVsNative>();
#endif
        }
    }

    [MemoryDiagnoser]
    public class NewtonsoftVsNative
    {
        private byte[] UpdateJsonBytes;

        private JsonSerializerOptions JsonSerializerOptions;

        [GlobalSetup]
        public void Setup()
        {
            const string updatesPath = @"C:\MihaZupan\Telegram\Telegram.Bot\test\Performance\TestUpdates2.json";
            UpdateJsonBytes = System.IO.File.ReadAllBytes(updatesPath);
            JsonSerializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        [Benchmark]
        public void NewtonsoftJson()
        {
            string json = Encoding.UTF8.GetString(UpdateJsonBytes);
            var updates = Newtonsoft.Json.JsonConvert.DeserializeObject<Update[]>(json);
        }

        [Benchmark]
        public void SystemTextJson()
        {
            var updates = JsonSerializer.Parse<Update[]>(UpdateJsonBytes, JsonSerializerOptions);

        }
    }
}
