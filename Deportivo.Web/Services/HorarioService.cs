using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Deportivo.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Deportivo.Web.Services
{
    public class HorarioService : IHorario
    {
        private readonly DataContext _context;
        public HorarioService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_hordep)
        {
            var horarios = _context.horarios.FirstOrDefault(x => x.id_hordep == id_hordep);
            if (horarios != null)
            {
                _context.horarios.Remove(horarios);
                _context.SaveChanges();
                var oEvenpri = _context.eventos.FirstOrDefault(t => t.id_horario == id_hordep);
                _context.eventos.Remove(oEvenpri);
                _context.SaveChanges();

            }
            return "Deleted";
        }
        public async Task<List<VMHorario>> GetHorario()
        {
            var vmvhorario = await (from horario in _context.horarios
                                   join cliente in _context.clientes on horario.id_client equals cliente.id_client
                                   join espdepor in _context.espacioDeportivos on horario.id_espdep equals espdepor.id_espdep
                                   select new VMHorario
                                    {
                                        id_hordep = horario.id_hordep,
                                        id_espdep = horario.id_espdep,
                                        id_client = horario.id_client,
                                        client_desc = cliente.client_desc,
                                        espdep_desc = espdepor.espdep_desc,
                                        hordep_desc = horario.hordep_desc,
                                        hordep_fecing = horario.hordep_fecing,
                                        hordep_fecsal = horario.hordep_fecsal,
                                        hordep_obse = horario.hordep_obse,
                                        hordep_tipo = horario.hordep_tipo
                                   }).ToListAsync();
            return vmvhorario;
        }
        public string Save(Horario oHorario)
        {
            string acep = "S";
            var oEspdep = from horario in _context.horarios
                          orderby horario.id_hordep
                          where horario.hordep_fecing == oHorario.hordep_fecing && horario.hordep_fecsal == oHorario.hordep_fecsal && horario.id_espdep == oHorario.id_espdep
                          select horario;

            if(oEspdep.ToList().Count() > 0)
            {
				acep = "N";
			}
            else
            {
				VMHorario oHora = new VMHorario
				{
					id_espdep = oHorario.id_espdep,
					id_client = oHorario.id_client,
					hordep_desc = oHorario.hordep_desc,
					hordep_fecing = oHorario.hordep_fecing,
					hordep_fecsal = oHorario.hordep_fecsal,
					hordep_obse = oHorario.hordep_obse,
					hordep_tipo = "ACT"
				};
				_context.horarios.Add(oHora);
				_context.SaveChanges();
				var ohours = _context.horarios.OrderByDescending(t => t.id_hordep).FirstOrDefault();
				Eventos oEventos = new Eventos
				{
					id_horario = ohours.id_hordep,
					title = ohours.hordep_desc,
					start = ohours.hordep_fecing,
					end = ohours.hordep_fecsal,
					Description = "Programacion",
					Location = ""
				};
				_context.eventos.Add(oEventos);
				_context.SaveChanges();
				acep = "S";
			}

            return acep;

        }

        public string Update(Horario oHorario)
        {
			string acep = "S";
			var oEspdep = from horario in _context.horarios
						  orderby horario.id_hordep
						  where horario.hordep_fecing == oHorario.hordep_fecing && horario.hordep_fecsal == oHorario.hordep_fecsal && horario.id_espdep == oHorario.id_espdep
						  select horario;

			if (oEspdep.ToList().Count() > 0)
			{
				acep = "N";
			}
			else
			{
				VMHorario oHora = new VMHorario
				{
                    id_hordep = oHorario.id_hordep,
					id_espdep = oHorario.id_espdep,
					id_client = oHorario.id_client,
					hordep_desc = oHorario.hordep_desc,
					hordep_fecing = oHorario.hordep_fecing,
					hordep_fecsal = oHorario.hordep_fecsal,
					hordep_obse = oHorario.hordep_obse,
					hordep_tipo = "ACT"
				};
				_context.horarios.Update(oHora);
				_context.SaveChanges();

				var ohours = _context.horarios.OrderByDescending(t => t.id_hordep).FirstOrDefault();
				Eventos oEventos = new Eventos
				{
					id_horario = ohours.id_hordep,
					title = ohours.hordep_desc,
					start = ohours.hordep_fecing,
					end = ohours.hordep_fecsal,
					Description = "Programacion",
					Location = ""
				};
				_context.eventos.Add(oEventos);
				_context.SaveChanges();
				acep = "S";
			}

			return acep;

			_context.horarios.Update(oHorario);
            _context.SaveChanges();

            var oEvenpri = _context.eventos.FirstOrDefault(t => t.id_horario == oHorario.id_hordep);

            oEvenpri.start = oHorario.hordep_fecing;
            oEvenpri.end = oHorario.hordep_fecsal;
            oEvenpri.title = oHorario.hordep_desc;
            oEvenpri.Description = "Programacion nueva";
            oEvenpri.Location = "";

           
            _context.eventos.Update(oEvenpri);
            _context.SaveChanges();

            return acep;
        }
 
    }
}
