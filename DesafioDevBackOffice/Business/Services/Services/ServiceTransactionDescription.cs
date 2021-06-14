using Business.Models;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.SharePoint.Client;
using System;
using System.IO;
using System.Net.Http;

namespace Business.Services.Services
{
    public class ServiceTransactionDescription : ServiceTrataReturnApi, IServiceTransactionDescription
    {
        private ModelApi _modelApi;
        public ServiceTransactionDescription(ModelApi modelApi)
        {
            _modelApi = modelApi;
        }
        public object ImportFileCNABAsync(ModelFiles files)
        {
            using (var content = new MultipartFormDataContent())
            {
                foreach (var item in files.Archive)
                {
                    byte[] fileBytes = ConvertToBytes(item);
                    ByteArrayContent bytes = new ByteArrayContent(fileBytes);
                    content.Add(bytes, "File", item.FileName);
                }
                var returnApi = ConnectToService(_modelApi.Url, "/api/TransactionDescription/ImportFile", ModelEnumRequestType.PATCH, bodyFile: content);
                if (returnApi is HttpResponseMessage)
                    return TreatReturn((HttpResponseMessage)returnApi);
                else
                    return returnApi;
            }
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            byte[] CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}
