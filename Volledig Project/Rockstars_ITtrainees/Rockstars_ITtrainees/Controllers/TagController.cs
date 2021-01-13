using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ITtrainees.MVC.APITools;

namespace ITtrainees.MVC.Controllers
{
    public class TagController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = await TagOperations.GetAll();
            return View(model);
        }
        public async Task<IActionResult> Create(string tagName)
        {
            TagOperations.Create(tagName);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int tagId)
        {
            Console.WriteLine(tagId);
            TagOperations.Delete(tagId);
            return RedirectToAction("Index");
        }
    }
}
