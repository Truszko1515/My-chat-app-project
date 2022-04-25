using System.ComponentModel.DataAnnotations.Schema;

namespace MainProjekt.Database.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Content { get; set; }
        public string FirstNameAuthor { get; set; }
        public string  LastNameAuthor { get; set; }

    }
}
