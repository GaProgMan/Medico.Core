using System;
using Medico.Core.Entities;

namespace Medico.Core.Webapi.ViewModels
{
    public class MedicationActionTimeViewModel : BaseViewModel, ICommonProperties
    {
        public bool Actioned { get; set; }
        public DateTime? TimeActioned { get; set; }
        public DateTime TimeToAction { get;set; }
        public string Notes { get; set; }
    }
}