using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;

namespace OpenTimeline.Web.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IRepository<Timeline> _timelineRepository;

        public HomeController(IRepository<Timeline> timelineRepository)
        {
            _timelineRepository = timelineRepository;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC! count:" + _timelineRepository.FindAll().Count().ToString();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
