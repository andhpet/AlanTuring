using System;
using System.Collections.Generic;

#nullable disable

namespace AlanTuring.Models
{
    public partial class User
    {
        public User()
        {
            ChatUserReceivers = new HashSet<Chat>();
            ChatUserSenders = new HashSet<Chat>();
            Comments = new HashSet<Comment>();
            FinanceReceivers = new HashSet<Finance>();
            FinanceSenders = new HashSet<Finance>();
        }

        public int Id { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        //public string AdditionalInfo { get; set; }
        public bool? Status { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public byte[] Picture { get; set; }
        public string Phone { get; set; }
        public byte[] Cv { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Chat> ChatUserReceivers { get; set; }
        public virtual ICollection<Chat> ChatUserSenders { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Finance> FinanceReceivers { get; set; }
        public virtual ICollection<Finance> FinanceSenders { get; set; }
    }
}
