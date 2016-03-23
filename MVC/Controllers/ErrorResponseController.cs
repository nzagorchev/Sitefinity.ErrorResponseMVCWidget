using SitefinityWebApp.Mvc.Models;
using System.ComponentModel;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Telerik.Sitefinity.Frontend.Mvc.Helpers;
using Telerik.Sitefinity.Mvc;

namespace SitefinityWebApp.Mvc.Controllers
{
    [ControllerToolboxItem(Name = "ErrorResponse", Title = "ErrorResponse", SectionName = "MvcWidgets")]
    public class ErrorResponseController : Controller
    {
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public IErrorResponseModel Model
        {
            get
            {
                if (this.model == null)
                    this.model = new ErrorResponseModel();

                return this.model;
            }
        }

        /// <summary>
        /// This is the default Action.
        /// </summary>
        public ActionResult Index()
        {
            if (!SitefinityContext.IsBackend)
            {
                if (!this.Model.IsDefault)
                {
                    Response.Status = this.Model.Status;
                    Response.StatusCode = this.Model.StatusCode;
                }
            }

            var viewModel = this.Model.CreateListViewModel();
            return View("Default", viewModel);
        }

        public string Options
        {
            get
            {
                var serializer = new JavaScriptSerializer();
                var serializedResult = serializer.Serialize(this.Model.InitializeOptions());
                return serializedResult;
            }
        }

        private IErrorResponseModel model;
    }
}