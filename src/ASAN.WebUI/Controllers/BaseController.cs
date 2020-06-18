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
    public class BaseController :  Controller
    {
        protected readonly ILogger<BaseController> _logger;

        #region Constructor

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        #endregion Constructor

        public void ExceptionErrorOccured(Exception ex,
            [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
            [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
            [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0,
            params object[] args)
        {
            var message = $"MethodName: {memberName}";
            message += System.Environment.NewLine + $"File Path: {sourceFilePath}";
            message += System.Environment.NewLine + $"Line Number: {sourceLineNumber}";

            this._logger.LogError(5000, ex, message, args);
        }
    }
}