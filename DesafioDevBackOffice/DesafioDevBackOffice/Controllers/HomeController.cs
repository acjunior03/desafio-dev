using Business.Models;
using Business.Services.Interfaces;
using DesafioDevBackOffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDevBackOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IServiceTransactionDescription _service { get; set; }
        public HomeController(ILogger<HomeController> logger, IServiceTransactionDescription service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Import()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> ImportFilesAsync(ModelFiles files)
        {
            ViewBag.MessageType = "danger";

            if (files.Archive == null)
            {
                ViewBag.MessageType = "warning";
                ViewBag.Message = "Selecione arquivo para importar.";
            }
            else if (files.Archive.Any(x => !x.FileName.ToLower().Contains(".txt")))
                ViewBag.Message = "Permitido somente tipo de arquivo <b>.txt</b>.";
            else
            {
                try
                {
                    ViewBag.MessageType = "success";

                    var returnArchive = _service.ImportFileCNABAsync(files);
                    if (returnArchive is BaseErrorModel)
                    {
                        ViewBag.MessageType = "danger";
                        ViewBag.Message = $"Ocorreu um erro ao importar o arquivo: <i>{((BaseErrorModel)returnArchive).GenericMessage}</i>";
                        return View("Import");
                    }
                    else
                    {
                        ViewBag.Message = $"Arquivos importados com êxito.";
                        return View("Import",JsonConvert.DeserializeObject<List<ModelGroupByStore>>(((BaseResult)returnArchive).Result.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.MessageType = "danger";
                    ViewBag.Message = $"Ocorreu um erro desconhecido: <i>{ex.Message}</i>.";
                }
            }

            return View("Import");
        }
    }
}
