using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Context;
using SignalR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.Hubs
{
    public class ChatHub: Hub
    {
        public readonly AppDbContext _context;

        public ChatHub(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Register(string username, string password)
        {
            try
            {
                var user = await _context.Users.AddAsync(new User()
                {
                    Password = password,
                    Username = username
                });

                _context.SaveChanges();

                return user.Entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
