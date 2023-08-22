using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
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
			var pagos = _context.pagoCabeceras.FirstOrDefault(x => x.id_pagcab == id_pagcab);
			if (pagos != null)
			{
				_context.pagoCabeceras.Remove(pagos);
				_context.SaveChanges();

                List<PagoDetalle> pagodet = _context.pagoDetalles.Where(x => x.id_pagcab == id_pagcab).ToList();
                foreach (PagoDetalle detalle in pagodet)
                {
                    _context.pagoDetalles.Remove(detalle);
                }

            }
			return "Deleted";
		}

        public async Task<List<GetPago>> Getpago()
        {
			var vmpago = await(from pago in _context.pagoCabeceras
									join cliente in _context.clientes on pago.id_client equals cliente.id_client
									select new GetPago
									{
										id_pagcab = pago.id_pagcab,
										client_desc = cliente.client_desc,
										pagcab_nro = pago.pagcab_nro,
										pagcab_fecemis = pago.pagcab_fecemis,
										pagcab_total = pago.pagcab_total
									}).ToListAsync();
			return vmpago;
		}

	}
}
