using COE.Application.Abstractions.Wrappers;
using COE.Application.Wrappers;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace COE.ClientExample
{
    public static class HttpClientExtension
    {
        public static async Task<IServiceResponse> GetServiceAsync<T>(this HttpClient Client, string Url) 
        {
            HttpResponseMessage ResponseMessage = await Client.GetAsync(Url);

            IServiceResponse Response;

            if(ResponseMessage.IsSuccessStatusCode) 
            {
                string Result = await ResponseMessage.Content.ReadAsStringAsync();

                Response = JsonConvert.DeserializeObject<SuccessResponse<T>>(Result);
            }
            else
            {
                Response = new ErrorResponse(new Exception("Get Service Error"));
            }

            return Response;
        }

        public static async Task<IServiceResponse> PostServiceAsync<Trequest, TResponse>(this HttpClient Client, string Url, Trequest Content) 
        {
            HttpResponseMessage ResponseMessage = await Client.PostAsJsonAsync<Trequest>(Url, Content);

            IServiceResponse Response;

            if (ResponseMessage.IsSuccessStatusCode)
            {
                string Result = await ResponseMessage.Content.ReadAsStringAsync();

                Response = JsonConvert.DeserializeObject<SuccessResponse<TResponse>>(Result);
            }
            else
            {
                Response = new ErrorResponse(new Exception("Get Service Error"));
            }

            return Response;
        }

        public static async Task<IServiceResponse> PutServiceAsync<Trequest, TResponse>(this HttpClient Client, string Url, Trequest Content)
        {
            HttpResponseMessage ResponseMessage = await Client.PutAsJsonAsync<Trequest>(Url, Content);

            IServiceResponse Response;

            if (ResponseMessage.IsSuccessStatusCode)
            {
                string Result = await ResponseMessage.Content.ReadAsStringAsync();

                Response = JsonConvert.DeserializeObject<SuccessResponse<TResponse>>(Result);
            }
            else
            {
                Response = new ErrorResponse(new Exception("Get Service Error"));
            }

            return Response;
        }

        public static async Task<IServiceResponse> DeleteServiceAsync<Trequest, TResponse>(this HttpClient Client, string Url, Trequest Content)
        {
            HttpRequestMessage Request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(Content), Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(Url)
            };

            HttpResponseMessage ResponseMessage = await Client.SendAsync(Request);

            IServiceResponse Response;

            if (ResponseMessage.IsSuccessStatusCode)
            {
                string Result = await ResponseMessage.Content.ReadAsStringAsync();

                Response = JsonConvert.DeserializeObject<SuccessResponse<TResponse>>(Result);
            }
            else
            {
                Response = new ErrorResponse(new Exception("Get Service Error"));
            }

            return Response;
        }
    }
}
