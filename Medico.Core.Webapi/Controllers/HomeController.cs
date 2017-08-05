using System;
using Medico.Core.DAL;
using Medico.Core.Webapi.Helpers;
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
            CheckForPresenceOfMedicationService();
            var dbMedication = _medicationService.GetOrCreate(1);
            return SingleResult(MedicationViewModelHelper.ConvertToViewModel(dbMedication));
        }

        /// <summary>
        /// Used to check that we have a valid <see cref="IMedicationService"/>, which
        /// we need to be able to perform any actions in this controller.
        /// </summary>
        /// <remarks>
        /// If there isn't a valid instance of a <see cref="IMedicationService"/>, then
        /// we will raise an exception because there's no point of attempting to process
        /// any requests 
        /// <remarks>
        private void CheckForPresenceOfMedicationService()
        {
            if (_medicationService == null)
            {
                throw new Exception("Medication Service was not ready");
            }
        }
    }
}