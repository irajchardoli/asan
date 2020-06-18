using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAN.WebUI.Controllers
{
    public class OwnerController : BaseController
    {
        #region Fields

        private readonly ASAN.Services.Contracts.IOwnerService _ownerService;

        #endregion Fields

        #region Constructor

        public OwnerController(ILogger<OwnerController> logger
                              , ASAN.Services.Contracts.IOwnerService ownerService) : base(logger: logger)
        {
            this._ownerService = ownerService;
        }

        #endregion Constructor

        #region Actions

        public IActionResult Index()
        {
            var dataItems = new List<ASAN.Entities.Owner>();

            try
            {
                dataItems = this._ownerService.GetItems(predicate: null ,includes: null);
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }            

            return View(model: dataItems);
        }

        #endregion Actions
    }
}
