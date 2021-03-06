﻿using ClientRequest.Data.Context;
using ClientRequest.Entities.Models;
using ClientRequest.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRequest.Services.Services
{
    public class RequestService : IRequestService
    {
        APIContext _webcontext = new APIContext();

        public List<Request> Get()
        {
            List<Request> requests = _webcontext.Requests.Where(m => m.IsActive == true).ToList();
            return requests;
        }

        public Request GetById(int id)
        {
            return _webcontext.Requests.Where(m => m.ID == id && m.IsActive == true).FirstOrDefault();
        }

        public void Save(Request data, string loggedInUserName)
        {
            if (data.ID == 0 && !IsNumberExists(data.Number))
            {
                data.IsActive = true;
                data.CreatedBy = loggedInUserName;
                data.CreatedOn = DateTime.Now;
                _webcontext.Requests.Add(data);
            }
            else
            {
                var request = _webcontext.Requests.Where(m => m.ID == data.ID).FirstOrDefault();

                request.ModuleID = data.ModuleID;
                request.JobNatureID = data.JobNatureID;
                request.ClientID = data.ClientID;
                request.Description = data.Description;
                request.Assessment = data.Assessment;
                request.RequestedBy = data.RequestedBy;
                request.RequestedOn = data.RequestedOn;
                request.AssignedTo = data.AssignedTo;
                request.CRW = data.CRW;
                request.UpdatedBy = loggedInUserName;
                request.UpdatedOn = DateTime.Now;
            }
            _webcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = _webcontext.Requests.Where(m => m.ID == id).FirstOrDefault();
            request.IsActive = false;
            _webcontext.SaveChanges();
        }

        public bool IsNumberExists(string number)
        {
            var request = _webcontext.Requests.Where(m => m.Number == number && m.IsActive == true).FirstOrDefault();
            return request != null ? true : false;
        }
    }
}
