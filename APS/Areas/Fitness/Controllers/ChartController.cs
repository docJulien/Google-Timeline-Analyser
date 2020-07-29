using Kendo.Mvc.UI;
using APS.Model;
using APS.Methods.Common;
using APS.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using APS.Areas.Fitness.Models;
using Kendo.Mvc;
using Microsoft.Extensions.Logging;

namespace APS.Areas.Fitness.Controllers
{
    [Area("Fitness")]
    [Authorize(Roles = Helpers.ConstanteRole.Administrateur)]
    public class ChartController : Controller
    {
        private readonly ILogger _logger;
        public ChartController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            {
                return View();
            }
        }
    }
}