using Business.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Business.Services.Services
{
    public class ServiceTrataReturnApi
    {
        public object TreatReturn(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;

                var objBaseError = JsonConvert.DeserializeObject<BadRequest>(result);
                var objBadRequest = JsonConvert.DeserializeObject<BaseErrorModel>(result);
                if (objBadRequest.GenericMessage is null)
                    return new BaseErrorModel { GenericMessage = objBaseError.Errors.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = objBaseError.Title };
                else
                    return objBadRequest;
            }
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) || httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return new BaseErrorModel { GenericMessage = httpResponseMessage.RequestMessage.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = result.ToString() };
            }

            var resultContent = httpResponseMessage.Content.ReadAsStringAsync().Result;
            var convertjson = JsonConvert.DeserializeObject<BaseResult>(resultContent.ToString());

            if (convertjson != null)
            {
                BaseResult baseResult = JsonConvert.DeserializeObject<BaseResult>(resultContent);
                return baseResult;
            }
            else if (JsonConvert.DeserializeObject<BaseErrorModel>(httpResponseMessage.ToString()) is BaseErrorModel)
            {
                BaseErrorModel baseErrorModel = JsonConvert.DeserializeObject<BaseErrorModel>(resultContent);
                return baseErrorModel;
            }
            else
            {
                return httpResponseMessage.ToString();
            }
        }

        public object TreatReturnFile(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.BadRequest))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;

                var objBaseError = JsonConvert.DeserializeObject<BadRequest>(result);
                var objBadRequest = JsonConvert.DeserializeObject<BaseErrorModel>(result);
                if (objBadRequest.GenericMessage is null)
                    return new BaseErrorModel { GenericMessage = objBaseError.Errors.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = objBaseError.Title };
                else
                    return objBadRequest;
            }
            if (httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.Unauthorized) || httpResponseMessage.StatusCode.Equals(System.Net.HttpStatusCode.NotFound))
            {
                var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return new BaseErrorModel { GenericMessage = httpResponseMessage.RequestMessage.ToString(), GenericNumber = (int)httpResponseMessage.StatusCode, Message = result.ToString() };
            }

            var resultContent = httpResponseMessage.Content.ReadAsByteArrayAsync().Result;
            return resultContent;
        }

        public static object ConnectToService(string url, string endPoint, ModelEnumRequestType requestType, string token = "", string body = null, MultipartFormDataContent bodyFile = null, string bodyType = null)
        {
            try
            {
                HttpClient client = new HttpClient();
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    client.DefaultRequestHeaders.Accept.Clear();
                }

                client.BaseAddress = new Uri(url);

                var result = string.Empty;
                StringContent stringContent;

                switch (requestType)
                {
                    case ModelEnumRequestType.GET:
                        {
                            if (body != null)
                            {
                                return client.GetAsync(endPoint).Result;
                            }
                            else
                                return client.GetAsync(endPoint).Result;
                        }

                    case ModelEnumRequestType.POST:
                        {
                            stringContent = new StringContent(body, Encoding.UTF8, bodyType);
                            return client.PostAsync(endPoint, stringContent).Result;
                        }
                    case ModelEnumRequestType.PUT:
                        {
                            stringContent = new StringContent(body, Encoding.UTF8, bodyType);

                            return client.PutAsync(endPoint, stringContent).Result;
                        }
                    case ModelEnumRequestType.PATCH:
                        {
                            var content = new MultipartFormDataContent();
                            content = bodyFile;
                            return client.PatchAsync(endPoint, bodyFile).Result; ;
                        }
                    case ModelEnumRequestType.DELETE:
                        {
                            var returnRequest = client.DeleteAsync(endPoint).Result;
                            result = returnRequest.Content.ReadAsStringAsync().Result;
                            return returnRequest;
                            break;
                        }
                    default:
                        break;
                }
                return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            catch (Exception e)
            {
                BaseErrorModel baseErrorModel = new BaseErrorModel { GenericMessage = "Requisição inválida.", Message = e.InnerException.Message };
                return baseErrorModel;
            }
        }
    }
}
