using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Message
    {
        public int MessageID { get; set; }

        [Required]
        [StringLength(4000, MinimumLength = 1)]
        public string TextMessage { get; set; }
        public DateTime MessageDate { get; set; }
        public int CountMessages { get; set; }
        public string MessageAuthor { get; set; }
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public User user = new User();

        public Message() { TextMessage = "TextMessage"; }

        public Message(DateTime MessageDate, int CountMessages)
        {
            this.MessageDate = MessageDate;
            this.CountMessages = CountMessages;
        }
    }
}
