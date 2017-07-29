using System;
using Medico.Core.DAL;
using Medico.Core.Webapi.Helpers;
using Medico.Core.Webapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Medico.Core.Webapi.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMedicationService _medicationService;

        public HomeController(IMedicationService medicationService)
        {
            _medicationService = medicationService;
        }

        [HttpGet("/")]
        public JsonResult Get()
        {
            if (_medicationService == null)
            {
                throw new Exception("Medication Service was not ready");
            }
            
            var dbMedication = _medicationService.GetOrCreate(1);
            return SingleResult(MedicationViewModelHelper.ConvertToViewModel(dbMedication));
        }
    }

    public class BaseController : Controller
    {
        protected JsonResult SingleResult(BaseViewModel singleResult)
        {
            return Json(new {
                Success = true,
                Result = singleResult
            });
        }
    }
}