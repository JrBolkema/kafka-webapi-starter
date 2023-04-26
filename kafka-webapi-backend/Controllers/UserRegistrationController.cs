using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kafka_webapi_backend.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net;
// these namespaces have been added for you as part of the started project
using Confluent.Kafka;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using kafka_webapi_backend.Helpers;

namespace kafka_webapi_backend.Controllers
{
    [ApiController]
    [Route("/api/user-registration")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly ProducerConfig _config;

        // TODO: dependency injection
        public UserRegistrationController(ProducerConfig config)
        {
            _config = config;
        }  

        [HttpGet]
        public string Get()
        {
            return "User Registration service is available!";
        }

        [HttpPost]
        public async Task<string> Post([FromBody] UserRegistrationModel body)
        {
            // TODO: Post method logic
            string topicName = "user-registration";
            string key = Guid.NewGuid().ToString();
            body.UserId = key;
            var response = "";
            try
            {
                string message = JsonConvert.SerializeObject(body);
                var producer = new ProducerHelper(this._config, topicName);
                await producer.SendMessage(key, message);
                response = $"Message written: {message}";
            }
            catch(Exception ex)
            {
                response = ex.Message;
            }
            return response;
        }

    }
}
