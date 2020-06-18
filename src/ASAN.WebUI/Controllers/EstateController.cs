using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAN.WebUI.Controllers
{
    public class EstateController : BaseController
    {
        #region Fields

        private readonly ASAN.Services.Contracts.IEstateService _estateService;
        private readonly ASAN.Services.Contracts.IOwnerService _ownerService;

        #endregion Fields

        #region Constructor

        public EstateController(ILogger<EstateController> logger
                              , ASAN.Services.Contracts.IEstateService estateService
                              , ASAN.Services.Contracts.IOwnerService ownerService) : base(logger: logger)
        {
            this._estateService = estateService;
            this._ownerService = ownerService;
        }

        #endregion Constructor

        #region Actions

        public IActionResult Index()
        {
            var dataItems = new List<ASAN.Entities.Estate>();

            try
            {
                var includes = new List<string>();
                includes.Add(nameof(ASAN.Entities.Estate.Owner));

                dataItems = this._estateService.GetItems(predicate: null, includes: includes.ToArray());
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return View(model: dataItems);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var modelItem = new ASAN.Entities.Estate();
            try
            {
                modelItem.Owners =await this.GetOwnersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return View(model: modelItem);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ASAN.Entities.Estate entityItem)
        {
            var serviceResult = new Common.ServiceResultInfo();

            try
            {
                if(ModelState.IsValid)
                {
                    serviceResult = await this._estateService.CreateAsync(entityItem: entityItem, savechange: true).ConfigureAwait(false);

                    if(serviceResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //ToDo: show error message
                    }
                }
                else
                {
                    //ToDo: show model state error
                }
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            try
            {
                entityItem.Owners =await this.GetOwnersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return View(model: entityItem);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Int64 id)
        {
            var modelItem = new ASAN.Entities.Estate();
            try
            {
                modelItem = await this._estateService.GetItemByKeyAsync(id: id).ConfigureAwait(false);
                modelItem.Owners = await this.GetOwnersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return View(model: modelItem);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ASAN.Entities.Estate entityItem)
        {
            var serviceResult = new Common.ServiceResultInfo();

            try
            {
                if (ModelState.IsValid)
                {
                    serviceResult = await this._estateService.UpdateAsync(entityItem: entityItem, savechange: true).ConfigureAwait(false);

                    if (serviceResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //ToDo: show error message
                    }
                }
                else
                {
                    //ToDo: show model state error
                }
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            try
            {
                entityItem.Owners = await this.GetOwnersAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return View(model: entityItem);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Int64 id)
        {
            var serviceResult = new Common.ServiceResultInfo();
            try
            {
                serviceResult = await this._estateService.DeleteByKeysAsync(id: id ,savechange: true).ConfigureAwait(false);
                
                if(serviceResult.Succeeded)
                {
                    //Show Successfully Message
                }
                else
                {
                    //Show Error Message
                }
            }
            catch (Exception ex)
            {
                this.ExceptionErrorOccured(ex);
            }

            return RedirectToAction("Index");
        }

        #endregion Actions

        #region privateMethods

        private async Task<List<SelectListItem>> GetOwnersAsync()
        {
            var result = new List<SelectListItem>();

            var owners = await this._ownerService.GetItemsAsync().ConfigureAwait(false);

            if(owners?.Any() == true)
            {
                result = owners.Select(x=>new SelectListItem { Text = $"{x.FirstName} {x.LastName}" ,Value=$"{x.Id}" }).ToList();
            }

            return result;
        }

        #endregion privateMethods
    }
}
