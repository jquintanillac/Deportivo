

using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface IPagoCabecera
    {
        Task<List<VMPago>> Getpago();    
        void Save(VMPago oPago);
        void Update(VMPago oPago);
        string Delete(int id_pagcab);
    }
}
