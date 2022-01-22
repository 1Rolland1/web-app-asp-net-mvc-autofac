using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class DisciplinesController : Controller
    {
        private IDisciplineService _disciplineService;
        public DisciplinesController(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var disciplines = _disciplineService.GetEntities();

            return View(disciplines);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var discipline = _disciplineService.Create();
            return View(discipline);
        }

        [HttpPost]
        public ActionResult Create(Discipline model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _disciplineService.Create(model);

            return RedirectPermanent("/Disciplines/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _disciplineService.Delete(id);

            return RedirectPermanent("/Disciplines/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var discipline = _disciplineService.Edit(id);

            return View(discipline);
        }

        [HttpPost]
        public ActionResult Edit(Discipline model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _disciplineService.Edit(model);

            return RedirectPermanent("/Disciplines/Index");
        }

       
    }
}