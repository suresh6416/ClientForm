using ClientRequest.Data.Context;
using ClientRequest.Entities.Models;
using ClientRequest.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ClientRequest.Services.Services
{
    public class ClientService : IClientService
    {
        APIContext _webcontext = new APIContext();

        public List<Client> Get()
        {
            List<Client> clients = _webcontext.Clients.Where(m => m.IsActive == true).ToList();
            return clients;
        }

        public Client GetById(int id)
        {
            return _webcontext.Clients.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
        }

        public void Save(Client data, string loggedInUserName)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                Client client = new Client();

                //Add Client
                if (data.ID == 0 && !IsNumberExists(data.Number))
                {
                    client.Number = data.Number;
                    client.Name = data.Name;
                    client.Address = data.Address;
                    client.Phone = data.Phone;
                    client.Email = data.Email;
                    client.IsActive = true;
                    client.CreatedBy = loggedInUserName;
                    client.CreatedOn = DateTime.Now;
                    _webcontext.Clients.Add(client);
                }
                else
                {
                    client = _webcontext.Clients.Where(m => m.ID == data.ID).FirstOrDefault();
                    client.Name = data.Name;
                    client.Address = data.Address;
                    client.Phone = data.Phone;
                    client.Email = data.Email;
                    client.UpdatedBy = loggedInUserName;
                    client.UpdatedOn = DateTime.Now;
                }
                _webcontext.SaveChanges();

                if (data.ClientModules.Count > 0)
                {
                    //Delete existing client and module associations
                    var clients = _webcontext.ClientModules.Where(m => m.ClientId == client.ID).ToList();
                    _webcontext.ClientModules.RemoveRange(clients);
                    _webcontext.SaveChanges();

                    //Add Modules
                    foreach (var module in data.ClientModules)
                    {
                        module.ClientId = client.ID;
                        module.ModuleID = module.ModuleID;                        
                        _webcontext.ClientModules.Add(module);
                        _webcontext.SaveChanges();
                    }
                }

                transaction.Complete();
            }                
        }

        public void Delete(int id)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                //Delete existing client and module associations
                var clients = _webcontext.ClientModules.Where(m => m.ClientId == id).ToList();
                if (clients.Count > 0)
                {
                    _webcontext.ClientModules.RemoveRange(clients);
                    _webcontext.SaveChanges();
                }

                var client = _webcontext.Clients.Where(m => m.ID == id).FirstOrDefault();
                client.IsActive = false;
                _webcontext.SaveChanges();

                transaction.Complete();
            }
        }

        public bool IsNumberExists(string number)
        {
            var client = _webcontext.Clients.Where(m => m.Number == number && m.IsActive == true).FirstOrDefault();
            return client != null ? true : false;
        }
    }
}
