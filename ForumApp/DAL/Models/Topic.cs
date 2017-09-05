namespace DataAccessLayer.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        public int TopicID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string TopicName { get; set; }
        public string TopicMessage { get; set; }
        public DateTime LastMessage { get; set; }
        public int CountMessage { get; set; }
        public Message mes = new Message();

        public Topic() { }

        public Topic(int TopicID, string TopicName, string TopicAuthor, DateTime LastMessage, int CountMessage)
        {
            this.TopicID = TopicID;
            this.TopicName = TopicName;
            mes.MessageAuthor = TopicAuthor;
            this.LastMessage = LastMessage;
            this.CountMessage = CountMessage;
        }
    }
}
