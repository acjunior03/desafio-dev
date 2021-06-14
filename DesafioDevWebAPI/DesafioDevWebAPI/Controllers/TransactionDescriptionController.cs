using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioDevWebAPI.Controllers
{
    public class TransactionDescriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
