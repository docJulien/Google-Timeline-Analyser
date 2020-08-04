using APS.Methods.Fitness;
using APS.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace APS.Areas.Fitness.Controllers
{
    [Area("Fitness")]
    [Authorize(Roles = Helpers.ConstanteRole.Administrateur)]
    public class ChartController : Controller
    {
        private readonly ILogger _logger;
        public ChartController(ILogger<ChartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            {
                return View();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>        
        [ExceptionMessages(ResourceKey = "ReadSport")]
        public IActionResult ReadSport()
        {
            return Json(Chart.GetSportData(User.Identity.Name));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>        
        [ExceptionMessages(ResourceKey = "ReadTransport")]
        public IActionResult ReadTransport()
        {
            return Json(Chart.GetTransportData(User.Identity.Name));
        }
    }
}