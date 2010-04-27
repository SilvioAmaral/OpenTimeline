using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTimeline.Core.AutoMapping;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly ITimelineRepository _timelineRepository;
        private readonly IRepository<Event> _eventRepository;
        private readonly IModelMapper _mapper;

        public EventController(ITimelineRepository timelineRepository, IModelMapper mapper, IRepository<Event> eventRepository)
        {
            _timelineRepository = timelineRepository;
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        //
        // GET: /Event/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var timelines = _timelineRepository.FindByAccount(1);
            Timeline timeline = timelines.FirstOrDefault();
            var eventViewModels = timeline.Events.Select(@event => new EventForm.EventViewModel
                                                                       {
                                                                           Name = @event.Name,
                                                                           Id = @event.Id ?? 0
                                                                       });
            var eventForm = new EventForm
                                {
                                    Timelines = _mapper.MapAll<Timeline, SelectListItem>(timelines),
                                    Events = eventViewModels
                                };
            return View(eventForm);
        }

        [HttpPost]
        public ActionResult Create(EventForm eventForm)
        {
            if (Request.IsAjaxRequest())
            {
                var @event = new Event()
                                 {
                                     Description = eventForm.Description,
                                     Name = eventForm.Name
                                 };
                Timeline timeline = _timelineRepository.FindById(eventForm.TimelineId);
                timeline.AddEvent(@event);
                _timelineRepository.Save(timeline);
                var eventViewModels = timeline.Events.Select(evt => new EventForm.EventViewModel
                {
                    Id = evt.Id ?? 0,
                    Name = evt.Name
                });
                return PartialView("EventList", eventViewModels);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            if (Request.IsAjaxRequest())
            {
                Event eventToDelete = _eventRepository.FindById(id);
                //Timeline timeline = eventToDelete.Timeline;
                //timeline.Events.Remove(eventToDelete);
                //eventToDelete.Timeline = null;
                _eventRepository.Delete(eventToDelete);
                //Timeline timeline = _timelineRepository.FindById(1);                
                //var eventViewModels = timeline.Events.Select(evt => new EventForm.EventViewModel
                //{
                //    Id = evt.Id ?? 0,
                //    Name = evt.Name
                //});
                //return PartialView("EventList", eventViewModels);
                return null;
            } 
            return null;
        }
    }
}
