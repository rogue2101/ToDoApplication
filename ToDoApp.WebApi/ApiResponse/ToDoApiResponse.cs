using ToDoApp.WebApi.Models.ResponseModel;

namespace ToDoApp.WebApi.ApiResponse
{
    public class ToDoApiResponse
    {
        public int ResponseCode { get; set; }
        public bool IdSuccess { get; set; }
        public ToDoResponseModel? ToDoResponseModel { get; set; }
    }
}
