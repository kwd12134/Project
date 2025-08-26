using MyToDo.Shared.Dtos;

namespace MyToDo.Service
{
    public class MemoService : BaseServer<MemoDto>, IMemoService
    {
        public MemoService(HttpRestClient client) : base(client, "Memo")
        {

        }
    }
}
