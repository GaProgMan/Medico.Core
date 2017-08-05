using System.Collections.Generic;
using Medico.Core.Webapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medico.Core.Webapi.Controllers
{
    public class BaseController : Controller
    {
        protected JsonResult SingleResult(BaseViewModel singleResult)
        {
            return Json(new
            {
                Success = true,
                Result = singleResult
            });
        }

        protected JsonResult MultipleResults(IEnumerable<BaseViewModel> multipleResults)
        {
            return Json(new
            {
                Success = true,
                Result = multipleResults
            });
        }
    }
}