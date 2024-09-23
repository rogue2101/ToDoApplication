namespace ToDoApp.WebApi.Models.ResponseModel
{
    public class AuthenticationResponse
    {
        public string? UserName { get; set; }
        public string? Token { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
