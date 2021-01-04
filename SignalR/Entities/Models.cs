using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
    }

    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string MessageBody { get; set; }
        public User User { get; set; }
    }
}
