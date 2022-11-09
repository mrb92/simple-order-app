//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//using Respawn;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SimpleOrderApp.IntegrationTests.Infrastructure
//{
//    public class TestingHelper : IDisposable
//    {
//        private static bool _initialized;

//        private static IConfigurationRoot _configuration;
//        private static IServiceScopeFactory _scopeFactory;
//        private static Respawner _respawner;

//        static TestingHelper()
//        {
//            EnsureInitialized();
//        }

//        private static void EnsureInitialized()
//        {
//            if (!_initialized)
//            {
//                Init();
//                _initialized = true;
//            }
//        }

//        private static void Init()
//        {
//            var builder = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json", true, true)
//                .AddEnvironmentVariables();

//            _configuration = builder.Build();

//            //var startup = new Startup
//        }
//    }
//}
