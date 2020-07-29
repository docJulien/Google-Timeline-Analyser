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
    public class UploadController : Controller
    {
        private readonly ILogger _logger;
        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Appel Ajax de grille kendo principale de ce controlleur
        /// </summary>
        /// <param name="request"></param>        
        [ExceptionMessages(ResourceKey = "Read")]
        public IActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            if (request.Filters == null)
                request.Filters = new List<IFilterDescriptor>();
            request.Filters.Add(new FilterDescriptor("User", FilterOperator.IsEqualTo, User.Identity.Name));
            if (request.Sorts == null)
                request.Sorts = new List<SortDescriptor>();
            request.Sorts.Clear();
            request.Sorts.Add(new SortDescriptor("Date", ListSortDirection.Ascending));
            return Json(CommonMethods.GetDataResult<UploadData, UploadDataVM>(request));
        }

        public IActionResult Index()
        {
            {
                var model = new UploadModel()
                {
                    AllowedExtensions = new string[] { "json" }
                };


                return View(model);
            }
        }

        public ActionResult Save(IEnumerable<IFormFile> files)
        {
            Methods.Fitness.Upload.Save(files, User, _logger);

            // Return an empty string to signify success
            return Content("");
        }

        public async Task<IActionResult> ClearData()
        {
            Methods.Fitness.Upload.ClearData(User);
            _logger.LogInformation("Cleared fitness data of " + User.Identity.Name);
            return Json(new[] { true });
        }
    }
}