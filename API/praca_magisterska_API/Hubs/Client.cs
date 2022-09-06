using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using praca_magisterska.DAL.DbModels;
using praca_magisterska_API.Interfaces;
using praca_magisterska_API.Models;
using praca_magisterska_API.Models.UserController;

namespace praca_magisterska_API.Hubs
{
    public interface IClient
    {
        Task ReceiveMessage(Message message);
    }
}
