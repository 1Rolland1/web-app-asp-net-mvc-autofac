using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WebAppAspNetMvcAutofac.DataModel;
using WebAppAspNetMvcAutofac.Services.Abstractions;

namespace WebAppAspNetMvcAutofac.Controllers
{
    public class GroupsController : Controller
    {
        private IGroupService _groupService;
        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var groups = _groupService.GetEntities();

            return View(groups);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var group = _groupService.Create();
            return View(group);
        }

        [HttpPost]
        public ActionResult Create(Group model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _groupService.Create(model);

            return RedirectPermanent("/Groups/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _groupService.Delete(id);

            return RedirectPermanent("/Groups/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var group = _groupService.Edit(id);

            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(Group model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _groupService.Edit(model);

            return RedirectPermanent("/Groups/Index");
        }

       
    }
}