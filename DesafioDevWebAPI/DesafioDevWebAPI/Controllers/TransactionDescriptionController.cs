using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDevWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDescriptionController : Controller
    {
        public IServiceTransactionDescription _service { get; set; }
        public TransactionDescriptionController(IServiceTransactionDescription service)
        {
            _service = service;
        }
        [HttpPatch("ImportFile"), DisableRequestSizeLimit]
        public IActionResult ImportFile(List<IFormFile> file)
        {
            List<byte[]> listArchiveBytes = new List<byte[]>();
            foreach (var item in file)
            {
                listArchiveBytes.Add(ConvertToBytes(item));
            }
            var result = _service.ImportFileCNAB(listArchiveBytes);
            return Ok(result);
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            byte[] CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}
