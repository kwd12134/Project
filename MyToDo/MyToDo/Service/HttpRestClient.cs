using MyToDo.Shared.Contact;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyToDo.Service
{
    public class HttpRestClient
    {
        private readonly string apiUrl;
        protected readonly RestClient client;

        public HttpRestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
            client = new RestClient();
        }

        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(apiUrl+baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter!=null)
            {
                request.AddParameter("Param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }
            var result =  await client.ExecuteAsync(request);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse<T>>(result.Content);

            else
                return new ApiResponse<T>()
                {
                    Status = false,
                    Message = result.ErrorMessage
                };
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(apiUrl + baseRequest.Route, baseRequest.Method);
            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter != null)
            {
                request.AddParameter("Param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
            }
            var result = await client.ExecuteAsync(request);
            return JsonConvert.DeserializeObject<ApiResponse>(result.Content);
        }

        #region MyRegion


        //{
        //  "messages": [
        //    {
        //      "content": "You are a helpful assistant", // 系统提示词
        //      "role": "system"                          // 角色标识
        //    },
        //    {
        //      "content": "Hi",                          // 用户输入内容
        //      "role": "user"                            // 用户标识
        //    }
        //  ],
        //  "model": "deepseek-chat",                     // 指定使用的模型
        //  "frequency_penalty": 0,                       // 频率惩罚系数（控制重复度）
        //  "max_tokens": 2048,                           // 响应最大 token 数
        //  "temperature": 1,                             // 温度参数（控制随机性，0-2）
        //  "top_p": 1,                                   // 核心采样参数（0-1）
        //  "stream": false                               // 是否启用流式响应
        //}
        public async Task<string> GetDeepSeek()
        {
            var client = new RestClient();
            var request = new RestRequest("https://api.deepseek.com/chat/completions", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", "Bearer sk-67ed785cba174a1792cf0c48b3382e9b");
            // 推荐使用对象序列化代替字符串拼接
            var requestBody = new ChatRequest
            {
                messages = new Message[] {
                new Message { role = "system", content = "你好,请介绍一下自己" },
                new Message{ role = "user", content = "Hi" }
                },
                model = "deepseek-chat",
                temperature = 1,
                max_tokens = 1024
            };
            request.AddJsonBody(requestBody);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            var a = JsonConvert.DeserializeObject<ChatResponse>(response.Content);
            return response.Content;
        }

        //{"id":"60b21fb1-467a-4be1-b208-3bf4cb1852ce",
        //"object":"chat.completion","created":1743345985,"model":"deepseek-chat",
        //"choices":[{"index":0,"message":{"role":"assistant",
        //"content":"你好呀！我是DeepSeek Chat，由深度求索公司打造的智能AI助手~ 🤖✨  \n\n我可以帮你解答各种问题，无论是学习、工作，还是日常生活中的小困惑。我擅长写作、编程、翻译、数据分析，还能陪你聊天解闷！📚💡  \n\n有什么我可以帮你的吗？😊"},
        //"logprobs":null,"finish_reason":"stop"}],
        //"usage":{ "prompt_tokens":9,"completion_tokens":69,"total_tokens":78,
        //"prompt_tokens_details":{ "cached_tokens":0},
        //"prompt_cache_hit_tokens":0,
        //"prompt_cache_miss_tokens":9},
        //"system_fingerprint":"fp_3d5141a69a_prod0225"}

        public class ChatRequest
        {
            public Message[] messages { get; set; }
            public string model { get; set; }
            public int temperature { get; set; }
            public int max_tokens { get; set; }
        }

        public class Message
        {
            public string role { get; set; }
            public string content { get; set; }
        }

        public class ChatResponse
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }

            [JsonPropertyName("object")]
            public string Object { get; set; }

            [JsonPropertyName("created")]
            public long Created { get; set; } // 时间戳可以用DateTime转换

            [JsonPropertyName("model")]
            public string Model { get; set; }

            [JsonPropertyName("choices")]
            public List<Choice> Choices { get; set; }

            [JsonPropertyName("usage")]
            public Usage Usage { get; set; }

            [JsonPropertyName("system_fingerprint")]
            public string SystemFingerprint { get; set; }
        }

        public class Choice
        {
            [JsonPropertyName("index")]
            public int Index { get; set; }

            [JsonPropertyName("message")]
            public Messages Message { get; set; }

            [JsonPropertyName("logprobs")]
            public object Logprobs { get; set; } // 根据实际情况可以定义具体类型

            [JsonPropertyName("finish_reason")]
            public string FinishReason { get; set; }
        }

        public class Messages
        {
            [JsonPropertyName("role")]
            public string Role { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }
        }

        public class Usage
        {
            [JsonPropertyName("prompt_tokens")]
            public int PromptTokens { get; set; }

            [JsonPropertyName("completion_tokens")]
            public int CompletionTokens { get; set; }

            [JsonPropertyName("total_tokens")]
            public int TotalTokens { get; set; }

            [JsonPropertyName("prompt_tokens_details")]
            public PromptTokensDetails PromptTokensDetails { get; set; }

            [JsonPropertyName("prompt_cache_hit_tokens")]
            public int PromptCacheHitTokens { get; set; }

            [JsonPropertyName("prompt_cache_miss_tokens")]
            public int PromptCacheMissTokens { get; set; }
        }

        public class PromptTokensDetails
        {
            [JsonPropertyName("cached_tokens")]
            public int CachedTokens { get; set; }
        }


        #endregion

    }
}
