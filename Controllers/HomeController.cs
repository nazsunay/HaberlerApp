using HaberlerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HaberlerApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var haberler = new List<Haber>();
            using StreamReader reader = new StreamReader("App_Data/haberler.txt");
            var haberlerTxt = reader.ReadToEnd();
            if(!string.IsNullOrEmpty(haberlerTxt)) {
                var haberListesi = haberlerTxt.Split('\n');
                foreach (var haberSatir in haberListesi)
                {
                    var haber = haberSatir.Split('|');
                    haberler.Add(
                        new Haber
                        {
                            Baslik = haber[0], Slug = haber[1]
                        }
                    );
                }
            }
            return View(haberler);
        }
    
        public IActionResult Detay(string slug)
        {
            using StreamReader reader = new StreamReader($"App_Data/{slug}.txt");

            ViewData["Content"] = reader.ReadToEnd();

            return View();
        }
    }
}
