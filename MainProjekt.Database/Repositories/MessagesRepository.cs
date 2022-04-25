using MainProjekt.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProjekt.Database.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ApplicationDbContex _dbContex;
        private DbSet<MessageEntity> Messages { get; set; }
        public MessagesRepository(ApplicationDbContex dbContex)
        {
            _dbContex = dbContex;
            Messages = dbContex.Messages;
            
        }
        public List<MessageEntity> GetAll()
        {  
            return Messages.ToList();
        }

        public bool Add(MessageEntity message)
        {
            Messages.Add(message);
            return _dbContex.SaveChanges() > 0;
        }

        public bool Delete(MessageEntity message)
        {
            Messages.Remove(message);
            return _dbContex.SaveChanges() > 0;
        }
    }
}
