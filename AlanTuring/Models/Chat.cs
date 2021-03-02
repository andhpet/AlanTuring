using System;
using System.Collections.Generic;

#nullable disable

namespace AlanTuring.Models
{
    public partial class Chat
    {
        public int MessageId { get; set; }
        public bool Status { get; set; }
        public string MessageContent { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? UserReceiverId { get; set; }
        public int? UserSenderId { get; set; }
        public int? GroupReceiverId { get; set; }

        public virtual Group GroupReceiver { get; set; }
        public virtual User UserReceiver { get; set; }
        public virtual User UserSender { get; set; }
    }
}
