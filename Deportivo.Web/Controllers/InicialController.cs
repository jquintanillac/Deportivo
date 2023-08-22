using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deportivo.Web.Controllers
{
	public class InicialController : Controller
	{
		// GET: InicialController
		public ActionResult Index()
		{
			return View();
		}

	}
}
