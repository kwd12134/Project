using MyToDo.Shared.Contact;
using MyToDo.Shared.Dtos;
using System.Threading.Tasks;

namespace MyToDo.Service
{
    public interface ILoginService
    {
        Task<ApiResponse> Login(UserDto user);

        Task<ApiResponse> Resgiter(UserDto user);
    }
}
