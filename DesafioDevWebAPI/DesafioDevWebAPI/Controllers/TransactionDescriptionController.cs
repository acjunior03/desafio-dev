using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceApplication.Interfaces;
using ServiceApplication.Models;
using System.Collections.Generic;
using System.IO;

namespace DesafioDevWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionDescriptionController : Controller
    {
        public IServiceApplicationTransactionDescription _service { get; set; }
        public TransactionDescriptionController(IServiceApplicationTransactionDescription service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpPatch("ImportFile"), DisableRequestSizeLimit]
        public IActionResult ImportFile(List<IFormFile> file)
        {
            List<byte[]> listArchiveBytes = new List<byte[]>();
            foreach (var item in file)
            {
                listArchiveBytes.Add(ConvertToBytes(item));
            }
            var result = _service.ImportFileCNAB(listArchiveBytes);
            if (result is BaseResult)
                return Ok(result);
            else
                return BadRequest(result);
        }
        private byte[] ConvertToBytes(IFormFile image)
        {
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            byte[] CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }
    }
}
