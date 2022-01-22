using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class TeachersController : Controller
    {
        private ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teachers = _teacherService.GetEntities().ToList();

            return View(teachers);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var teacher = _teacherService.Create();
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Create(Teacher model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _teacherService.Create(model);

            return RedirectPermanent("/Teachers/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _teacherService.Delete(id);

            return RedirectPermanent("/Teachers/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var teacher = _teacherService.Edit(id);

            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _teacherService.Edit(model);

            return RedirectPermanent("/Teachers/Index");
        }

        [HttpGet]
        public ActionResult GetImage(int id)
        {
            var image = _teacherService.GetImage(id, Server);

            return File(new MemoryStream(image.Data), image.ContentType);
        }

    }
}