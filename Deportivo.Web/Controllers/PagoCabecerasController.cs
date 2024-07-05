using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.Migrations;
using Deportivo.Web.Models;
using Deportivo.Web.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Globalization;
using Deportivo.Web.Data.DataSql;

namespace Deportivo.Web.Controllers
{
   // [Authorize(Roles = "Admin")]
    public class PagoCabecerasController : Controller
    {
        private readonly DataContext _context;
		IPagoCabecera _pagocabecera;
		public SPHorario _horario;
		
        public PagoCabecerasController(DataContext context, IPagoCabecera pagoCabecera)
        {
            _context = context;
			_pagocabecera = pagoCabecera;
			_horario = new SPHorario();
        }

        // GET: PagoCabeceras
        public async Task<IActionResult> Index()
        {
			ViewBag.tipodoc = await _context.tipoDocumentos.Where(x => x.tipodoc_tipo == "P").ToListAsync();
            ViewBag.cliente = await _context.clientes.Where(x => x.client_act == true).ToListAsync();			
			ViewBag.espacio = await _context.espacioDeportivos.Where(x => x.espdep_act == true).ToListAsync();
			ViewBag.adicional = await _context.adicionales.Where(x => x.adicio_est == true).ToListAsync();
			return View();
        }

		[HttpPost]
		public async Task<IActionResult> Pagoventa([FromBody] VMPago oPago)
		{
			try
			{
				bool respuesta = true;
				DateTime fecrea = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
				PagoCabecera oPagar = new PagoCabecera
				{
					id_pagcab = oPago.id_pagcab,
					id_tipodoc = oPago.id_tipodoc,
					id_client = oPago.id_client,
					pagcab_descr = oPago.pagcab_descr,
					pagcab_feccrea = fecrea,
					pagcab_fecemis = oPago.pagcab_fecemis,
					pagcab_nro = oPago.pagcab_nro,
					pagcab_obs = oPago.pagcab_obs,
					pagcab_total = oPago.pagcab_total

				};
				_context.pagoCabeceras.Add(oPagar);
				_context.SaveChanges();
				var opagocab = await _context.pagoCabeceras.OrderByDescending(t => t.id_pagcab).FirstOrDefaultAsync();
				if (opagocab.id_tipodoc == 3)
				{
					int Ifactu = opagocab.pagcab_nro.Length;
					int NFactu = Ifactu - 4;
					string Sfactu = opagocab.pagcab_nro.Substring(4,NFactu);
					var factura = await _context.numeraciones.Where(x => x.nume_tipo == "F").FirstOrDefaultAsync();
					factura.nume_numero = Sfactu;
					_context.numeraciones.Update(factura);
					_context.SaveChanges();
				}
				else
				{
					int Ibole = opagocab.pagcab_nro.Length;
					int Nbole = Ibole - 4;
					string SBole = opagocab.pagcab_nro.Substring(4, Nbole);
					var boleta = await _context.numeraciones.Where(x => x.nume_tipo == "B").FirstOrDefaultAsync();
					boleta.nume_numero = SBole;
					_context.numeraciones.Update(boleta);
					_context.SaveChanges();
				}

				//insertamos el detalle
				VMPago oPagodetalle = new VMPago();
				oPagodetalle.oPagoDet = oPago.oPagoDet;

				foreach (var item in oPago.oPagoDet.ToList())
				{					
					PagoDetalle oPagoDetalle = new PagoDetalle
					{
						id_pagcab = opagocab.id_pagcab,
						id_hordep = Convert.ToInt32(item.id_hordep),
						id_adicio = Convert.ToInt32(item.id_adicio),
						pagdet_monto = item.pagdet_monto,
						pagdet_unidad = item.pagdet_unidad,
						pagdet_total = item.pagdet_total
					};

					_context.pagoDetalles.Add(oPagoDetalle);
					_context.SaveChanges();

				}

				var horarios = _context.horarios.FirstOrDefault(t => t.id_client == oPago.id_client && t.hordep_tipo == "ACT");
				if (horarios != null)
				{
					horarios.hordep_tipo = "PAG";
					_context.horarios.Update(horarios);
					_context.SaveChanges();
				}
				
				return Json(new { respuesta });
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		[HttpPost]
		public async Task<IActionResult> Numeracion(int valor)
		{
			string respuesta = "";
			string Sfact;
			string Sbole;
			int lgFact;
			int lgBole;
			int Ifactu = 0;
			int Ibole = 0;
		
			if(valor == 3)
			{
				//var factura = await (from factu in _context.numeraciones where factu.nume_tipo == "F" select factu.nume_serie + "-" + factu.nume_numero).FirstAsync();
				var factura = await _context.numeraciones.Where(x => x.nume_tipo == "F").FirstOrDefaultAsync();
				Ifactu = Convert.ToInt32(factura.nume_numero);
				Ifactu = Ifactu + 1;
				lgFact = factura.nume_numero.ToString().Length - Ifactu.ToString().Length;
				switch (lgFact)
				{
					case 0:
						Sfact = Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					case 1:
						Sfact = "0" + Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					case 2:
						Sfact = "00" + Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					case 3:
						Sfact = "000" + Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					case 4:
						Sfact = "0000" + Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					case 5:
						Sfact = "00000" + Ifactu.ToString();
						respuesta = factura.nume_serie + "-" + Sfact;
						break;
					default:
						break;
				}				
			}
			else
			{
				//var boleta = await (from bole in _context.numeraciones where bole.nume_tipo == "B" select bole.nume_serie + "-" + bole.nume_numero).FirstAsync();
				var boleta = await _context.numeraciones.Where(x => x.nume_tipo == "B").FirstOrDefaultAsync();
				Ibole = Convert.ToInt32(boleta.nume_numero);
				Ibole = Ibole + 1;
				lgBole = boleta.nume_numero.ToString().Length - Ibole.ToString().Length;
				switch (lgBole)
				{
					case 0:
						Sbole = Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					case 1:
						Sbole = "0" + Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					case 2:
						Sbole = "00" + Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					case 3:
						Sbole = "000" + Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					case 4:
						Sbole = "0000" + Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					case 5:
						Sbole = "00000" + Ibole.ToString();
						respuesta = boleta.nume_serie + "-" + Sbole;
						break;
					default:
						break;
				}
			}									
			return Json(new { respuesta });
		}

        [HttpGet]
        public ActionResult tarjeta(string fechas, string horainis, string horafins, string cancha)
        {
			//Sacamos el numero de horas
			DateTime fecInicio = DateTime.Parse(horainis);
			DateTime fecFin = DateTime.Parse(horafins);

            // Calcular la diferencia entre las horas
            TimeSpan diferencia = fecFin - fecInicio;

            // Obtener el número total de horas
            double horas = diferencia.TotalHours;

            // Calcular el precio utilizando la tarifa de 80 por hora
            double precio = horas * 80;

            // Buscamos la descripcion de la cancha 
            string desCancha = _context.espacioDeportivos.Where(x => x.id_espdep == Convert.ToInt32(cancha)).Select(p => p.espdep_desc).FirstOrDefault() ?? "Descripción no encontrada";

            ViewBag.horini = horainis;
			ViewBag.horfin = horafins;
			ViewBag.cancha = desCancha;
			ViewBag.fecha = fechas;
			ViewBag.pago = precio;
            return View();
        }

		[HttpPost]
        public ActionResult GrabarHorario(VMFechas mFechas) 
        {
			if (mFechas != null)
			{
                string fechas = mFechas.fechas;
                string horainis = mFechas.horainis;
                string horafins = mFechas.horafins;

                string fechorini = fechas + " " + horainis;
                string fechorafin = fechas + " " + horafins;

                DateTime fechaInicial = DateTime.ParseExact(fechorini, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
                DateTime fechafinal = DateTime.ParseExact(fechorafin, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
				 

                // Devuelve "Ok" como respuesta JSON
                return Json(new { respuesta = "Ok", fechas = mFechas.fechas, horainis = mFechas.horainis, horafins = mFechas.horafins });
			}

			// Si la validación falla, puedes devolver un mensaje de error o un estado diferente
			return Json(new { respuesta = "Error" });

        }

        [HttpPost]
        public ActionResult cargarCanchas(VMFechas mFechas)
        {
			if (mFechas != null)
			{
				string fechas = mFechas.fechas;
				string horainis = mFechas.horainis;
				string horafins = mFechas.horafins;

				string fechorini = fechas + " " + horainis;
				string fechorafin = fechas + " " + horafins;

				DateTime fechaInicial = DateTime.ParseExact(fechorini, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
				DateTime fechafinal = DateTime.ParseExact(fechorafin, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

				var canchas = _horario.spCanchas(fechaInicial, fechafinal);

				if(canchas.Result != null)
				{
                    return Json(new { respuesta = "Ok", canchas = canchas.Result });
                }
				else
				{
                    return Json(new { respuesta = "Error" });
                }
				
			}

			// Si la validación falla, puedes devolver un mensaje de error o un estado diferente
			 return Json(new { respuesta = "Error" });

		}



        private bool PagoCabeceraExists(int id)
        {         
          return _context.pagoCabeceras.Any(e => e.id_pagcab == id);
        }
    }
}
