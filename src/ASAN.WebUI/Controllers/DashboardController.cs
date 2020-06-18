using ASAN.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASAN.WebUI.Controllers
{
    public class DashboardController : BaseController
    {
        #region Constructor

        public DashboardController(ILogger<DashboardController> logger) : base(logger: logger)
        {
        }

        #endregion Constructor

        #region Actions

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion Actions
    }
}