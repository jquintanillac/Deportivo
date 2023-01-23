using Deportivo.Web.Data;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class PagoService : IPagoCabecera
    {
        private readonly DataContext _context;
        public PagoService(DataContext context)
        {
            _context = context;
        }

        public string Delete(int id_pagcab)
        {
            throw new NotImplementedException();
        }

        public Task<List<VMPago>> Getpago()
        {
            throw new NotImplementedException();
        }

        public void Save(VMPago oPago)
        {
            throw new NotImplementedException();
        }

        public void Update(VMPago oPago)
        {
            throw new NotImplementedException();
        }
    }
}
