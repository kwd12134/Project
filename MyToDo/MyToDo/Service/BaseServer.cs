using MyToDo.Shared.Contact;
using MyToDo.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Service
{
    public class BaseServer<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseServer(HttpRestClient client,string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }

        public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            BaseRequest Request = new BaseRequest();
            Request.Method = RestSharp.Method.Post;

            //相当于访问并调用serviceName控制器里的Add方法
            Request.Route = $"api/{serviceName}/Add";

            Request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(Request);
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            BaseRequest Request = new BaseRequest();
            Request.Method = RestSharp.Method.Post;

            //相当于访问并调用serviceName控制器里的Delete方法
            Request.Route = $"api/{serviceName}/Delete?={id}";

           return  await client.ExecuteAsync(Request);
        }

        public async Task<ApiResponse<PagedList<TEntity>>> GetAllAsync(QueryParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetAll?pageIndex={parameter.PageIndex}" +
                $"&pageSize={parameter.PageSize}" +
                $"&search={parameter.Search}";
            return await client.ExecuteAsync<PagedList<TEntity>>(request);
        }

        public async Task<ApiResponse<TEntity>> GetFirstOfDefaultAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/Get?id={id}";
            return await client.ExecuteAsync<TEntity>(request);
        }

        public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntity>(request);
        }
    }
}
