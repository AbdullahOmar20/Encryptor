using Microsoft.AspNetCore.Mvc;
using ServicesContracts;
using SoftwareSecurityProject.Models;
using SoftwareSecurityProject.ServicesContract;
using System.Diagnostics;

namespace SoftwareSecurityProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICeaserAlgorithm _ceaser;
        private readonly IModernAlgorithm _modern;
        private readonly IViginereAlgorithm _viginere;
        public HomeController(ILogger<HomeController> logger, IModernAlgorithm modern,ICeaserAlgorithm ceaser,IViginereAlgorithm viginere)
        {
            _logger = logger;
            _modern = modern;
            _ceaser = ceaser;
            _viginere = viginere;
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult Index(string Algorithm, string type, string entrydata)
        {
            string result=" ";
            if(type=="Encryption")
            {
                if(Algorithm == "Ceaser") 
                {
                     result = _ceaser.Encrypt(entrydata, 11);
                }
                if(Algorithm =="Viginere")
                {
                    result = _viginere.Encrypt(entrydata, "Iteam");
                }
                if (Algorithm == "Affine")
                {
                    result = _modern.Encryption(entrydata);
                }

            }
            else if (type == "Decryption")
            {
                if (Algorithm == "Ceaser")
                {
                    result = _ceaser.Decrypt(entrydata, 11);
                }
                if (Algorithm == "Viginere")
                {
                    result = _viginere.Decrypt(entrydata, "Iteam");
                }
                if (Algorithm == "Affine")
                {
                    result = _modern.Decryption(entrydata);
                }
            }

            ViewBag.result = result;
            return View();
        }
    }
}
