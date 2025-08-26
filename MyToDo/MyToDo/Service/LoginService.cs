using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using System.Threading.Tasks;

namespace MyToDo.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName = "Login";

        public LoginService(HttpRestClient client)
        {
            this.client = client;
        }

        public async Task<ApiResponse> Login(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Login";
            request.Parameter = user;
            return await client.ExecuteAsync(request);
        }

        public async Task<ApiResponse> Resgiter(UserDto user)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Resgiter";
            request.Parameter = user;
            return await client.ExecuteAsync(request);
        }
    }
}
