namespace TheGarage.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Web.Mvc;

    public abstract class AdministrationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        public bool IsHidden { get; set; }
    }
}