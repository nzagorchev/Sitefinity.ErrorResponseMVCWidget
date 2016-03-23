using System;
using System.Collections.Generic;
using System.Linq;

namespace SitefinityWebApp.Mvc.Models
{
    public class ErrorResponseModel : IErrorResponseModel
    {
        public int StatusCode { get; set; }

        public string Status { get; set; }

        public virtual ErrorResponseModel[] InitializeOptions()
        {
            var items = new List<ErrorResponseModel>();
            items.Add(new ErrorResponseModel()
            {
                Status = "404 Not Found",
                StatusCode = 404
            });
            items.Add(new ErrorResponseModel()
            {
                Status = "500 Internal Server Error",
                StatusCode = 500
            });
            items.Add(new ErrorResponseModel()
            {
                Status = "503 Service Unavailable",
                StatusCode = 503
            });

            return items.ToArray();
        }

        public virtual bool IsDefault
        {
            get
            {
                return (string.IsNullOrEmpty(this.Status) || this.StatusCode == 0);
            }
        }

        public ErrorResponseViewModel CreateListViewModel()
        {
            var viewModel = new ErrorResponseViewModel();
            viewModel.StatusMessage = this.Status;
            viewModel.IsDefault = this.IsDefault;
            viewModel.AdditionalInfo = this.GetAdditionalInfo();

            return viewModel;
        }

        protected string GetAdditionalInfo()
        {
            if (this.StatusCode == 404)
            {
                return "The resource you are trying to access cannot be found.";
            }

            return string.Empty;
        }
    }
}