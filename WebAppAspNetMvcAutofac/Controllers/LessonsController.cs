using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class LessonsController : Controller
    {
        private ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var lessons = _lessonService.GetEntities();

            return View(lessons);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var lesson = _lessonService.Create();
            return View(lesson);
        }

        [HttpPost]
        public ActionResult Create(Lesson model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _lessonService.Create(model);

            return RedirectPermanent("/Lessons/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _lessonService.Delete(id);

            return RedirectPermanent("/Lessons/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var lesson = _lessonService.Edit(id);

            return View(lesson);
        }

        [HttpPost]
        public ActionResult Edit(Lesson model)
        {            
            if (!ModelState.IsValid)
                return View(model);

            _lessonService.Edit(model);

            return RedirectPermanent("/Lessons/Index");
        }
              
        

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var lesson = _lessonService.Edit(id);

            return View(lesson);
        }
        
    }
}