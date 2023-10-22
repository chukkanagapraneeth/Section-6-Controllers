using Microsoft.AspNetCore.Mvc;
using ControllersProj.Models;

namespace ControllersProj.Controllers
{
    [Controller]
    public class TestController : Controller
    {
        [Route("method1")]
        [Route("/")]
        public ContentResult method1()
        {
            return Content("This is plain text as content result", "text/plain");
        }

        [Route("user/{mobileno:Regex(^\\d{{10}}$)}")]
        public string mobno()
        {
            return "revievced mobono"; 
        }

        [Route("html")]
        public ContentResult Html()
        {
            return Content("<h1>This is a header<h1>", "text/html");
        }

        [Route("json")]
        public JsonResult jon()
        {
            PersonModel person = new PersonModel()
            {
                Age = 28,
                Id = Guid.NewGuid(),
                Name = "NPC",
                city = "Hyderabad"
            };

            //return new JsonResult(person);
            return Json(person);
        }

        [Route("file")]
        public VirtualFileResult file()
        {
            //return new VirtualFileResult("/Vitals.PNG", "image/png");
            return File("/Vitals.PNG", "image/png");
        }

        [Route("phyfile")]
        public PhysicalFileResult file1()
        {
            //return new PhysicalFileResult(@"D:\HCL HEALTH REPORTS\NAGA PRANEETH CHUKKA.pdf", "application/pdf");
            return PhysicalFile(@"D:\HCL HEALTH REPORTS\NAGA PRANEETH CHUKKA.pdf", "application/pdf");
        }

        [Route("bytefile")]
        public ActionResult file2()
        {
            byte[] arr = System.IO.File.ReadAllBytes(@"D:\HCL HEALTH REPORTS\NAGA PRANEETH CHUKKA.pdf");
            //return new FileContentResult(arr, "application/pdf");
            return File(arr, "application/pdf");
        }

        [Route("redirect1")]
        public IActionResult redirect1()
        {
            return new RedirectToActionResult("redirect2", "Test", new { });
        }

        [Route("redirect2")]
        public IActionResult redirect2()
        {
            //return Content("Yooo redirected");
            return new RedirectToActionResult("redirect1", "Test", new { }); //Redirected Too Many Times LOL
        }

    }
}
