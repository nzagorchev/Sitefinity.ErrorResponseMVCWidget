namespace SitefinityWebApp.Mvc.Models
{
    public interface IErrorResponseModel
    {
        int StatusCode { get; set; }

        string Status { get; set; }

        bool IsDefault { get; }

        ErrorResponseModel[] InitializeOptions();

        ErrorResponseViewModel CreateListViewModel();
    }
}