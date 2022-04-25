using MainProjekt.Database.Entities;
using System.Collections.Generic;

namespace MainProjekt.Database.Repositories
{
    public interface IMessagesRepository
    {
        List<MessageEntity> GetAll();
        bool Add(MessageEntity Message);
        bool Delete(MessageEntity Message);
        
    }
}