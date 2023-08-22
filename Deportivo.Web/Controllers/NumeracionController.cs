using Deportivo.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Deportivo.Web.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class NumeracionController : Controller
	{
		private readonly DataContext _context;

		public NumeracionController(DataContext context)
		{
			_context = context;
		}
		// GET: NumeracionController
		public ActionResult Index()
		{
			return View();
		}
	
	}
}
