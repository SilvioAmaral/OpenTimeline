using System.Linq;
using System.Web.Mvc;
using OpenTimeline.Core.AutoMapping;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly ITimelineRepository _timelineRepository;
        private readonly IModelMapper _mapper;

        public AccountController(IRepository<Account> accountRepository, ITimelineRepository timelineRepository, IModelMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _timelineRepository = timelineRepository;
        }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyTimeline(int timelineId, int accountId)
        {
            Account account = _accountRepository.FindById(accountId);

            Member m = account.Members.FirstOrDefault(x => x.Timeline.Id.Value == timelineId);
            var viewModel = _mapper.Map<Member, MemberTimelineViewModel>(m);
            //viewModel.TimelineName = m.Timeline.Name;
            //viewModel.Events = _mapper.MapAll<MemberEvent, MemberTimelineViewModel.EventViewModel>(m.MemberEvents);
            //foreach (var memberEvent in m.MemberEvents)
            //{
            //    viewModel.Events.Add(new MemberTimelineViewModel.EventViewModel
            //                             {
            //                                 EventName = memberEvent.Event.Name,
            //                                 Date = memberEvent.Date
            //                             });
            //}

            var timelines = _timelineRepository.FindByAccount(accountId);
            viewModel.Timelines = _mapper.MapAll<Timeline, SelectListItem>(timelines);
            //foreach (var timeline in timelines)
            //{
            //    viewModel.Timelines.Add(new SelectListItem()
            //                                {
            //                                    Text = timeline.Name,
            //                                    Value = timeline.Id.ToString()
            //                                });
            //}

            return View(viewModel);
        }
    }
}