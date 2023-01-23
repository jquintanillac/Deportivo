using Deportivo.Web.Data;
using Deportivo.Web.Data.Entities;
using Deportivo.Web.IServices;
using Microsoft.EntityFrameworkCore;

namespace Deportivo.Web.Services
{
    public class TipoDocumentoService : ITipoDocumento
    {
        private readonly DataContext _context;
        public TipoDocumentoService(DataContext context)
        {
            _context = context;
        }
        public string Delete(int id_tipdoc)
        {
            var tipdocu = _context.tipoDocumentos.FirstOrDefault(x => x.id_tipdoc == id_tipdoc);
            if (tipdocu != null)
            {
                _context.tipoDocumentos.Remove(tipdocu);
                _context.SaveChanges();
            }
            return "Deleted";
        }  
        public async Task<List<TipoDocumento>> Gettipodoc()
        {
            return await _context.tipoDocumentos.ToListAsync();
        }

        public void Save(TipoDocumento oTipdocu)
        {
            _context.tipoDocumentos.Add(oTipdocu);
            _context.SaveChanges();
        }

        public void Update(TipoDocumento oTipdocu)
        {
            _context.tipoDocumentos.Update(oTipdocu);
            _context.SaveChanges();
        }
    }
}
