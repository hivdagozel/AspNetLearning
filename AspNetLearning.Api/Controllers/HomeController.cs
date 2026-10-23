using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["Mesaj"] =
            "Bu yazı Controller'dan ViewData ile gönderildi.";

        ViewBag.Aciklama =
            "Bu yazı Controller'dan ViewBag ile gönderildi.";

        ViewData["OrtakVeri"] =
            "Bu değer ViewData ile kaydedildi.";

        return View();
    }

    public IActionResult TempDataOlustur()
    {
        TempData["Bildirim"] = "İşlem başarıyla tamamlandı.";

        return RedirectToAction("TempDataGoster");
    }

    public IActionResult TempDataGoster()
    {
        return View();
    }
}