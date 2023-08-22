

using Deportivo.Web.Data.Entities;
using Deportivo.Web.Models;

namespace Deportivo.Web.IServices
{
    public interface IPagoCabecera
    {
        Task<List<GetPago>> Getpago();
		string Delete(int id_pagcab);
    }
}
