using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MainProjekt.Database.Repositories;
using MainProjekt.Database.Entities;
using Microsoft.AspNetCore.Authorization;

namespace MainProjekt.Controllers
{
    [ApiController]
    [Route("kurs")]
    public class KursController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMessagesRepository _messagesRepository;
        public KursController(IConfiguration configuration, IMessagesRepository messagesRepository)
        {
            _configuration = configuration;
            _messagesRepository = messagesRepository;
        }

        [Authorize("Administrator")]
        [Route("getSomeSecretData")]
        public IActionResult GetSomeSecretData()
        {
            return Ok("SomeSecretKey");
        }

        [HttpGet]
        [Route("getMessage")]
        public IActionResult GetMessage()
        {
            var refreshTime = _configuration.GetValue<int>("Application:RefreshTime");

            Message message = new Message
            {
                Content = $"My refresh time is: {refreshTime}",
                Author = "Patryk Mikulski"
            };

            //var serializedMessage = JsonConvert.SerializeObject(message);
            //var deserializedMessage = JsonConvert.DeserializeObject <Message> (serializedMessage);

            return Ok(message);
        }

        [HttpPost]
        [Route("sendMessage")]
        public IActionResult SendMessage(Message message)
        {

            var messageEntity = new MessageEntity
            {
                Content = message.Content
            };

            var result = _messagesRepository.Add(messageEntity);
            if (result)
            {
                return Ok(message);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("deleteMessage")]
        public IActionResult DeleteRecord(Message message)
        {
            var messageEntity = new MessageEntity
            {
                Content = message.Content
            };

            var result = _messagesRepository.Delete(messageEntity);

            if (result)
                return NoContent();

            return NotFound();
        }
        
    }
}
