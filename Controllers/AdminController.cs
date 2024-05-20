using HaberlerApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaberlerApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Haber model)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Hata"] = "Eksik alan var. Tüm alanları doldurun.";
                return View();
            }

            using StreamReader reader = new StreamReader("App_Data/haberler.txt");
            var haberlerTxt = reader.ReadToEnd();
            reader.Close();

            if(!string.IsNullOrEmpty(haberlerTxt))
            {
                haberlerTxt += "\n";
            }

            using StreamWriter writer = new StreamWriter("App_Data/haberler.txt");
            writer.Write($"{haberlerTxt}{model.Baslik}|{model.Slug}");
            writer.Close();

            using StreamWriter detayWriter = new StreamWriter($"App_Data/{model.Slug}.txt");
            detayWriter.Write($"<h1>{model.Baslik}</h1>{model.Detay}");


            return View("Basarili");
        }
    }
}
