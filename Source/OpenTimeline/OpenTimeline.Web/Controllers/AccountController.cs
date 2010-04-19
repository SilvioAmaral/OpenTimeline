using System.Linq;
using System.Web.Mvc;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly ITimelineRepository _timelineRepository;

        public AccountController(IRepository<Account> accountRepository, ITimelineRepository timelineRepository)
        {
            _accountRepository = accountRepository;
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
            var viewModel = new MemberTimelineViewModel();
            var timelines = _timelineRepository.FindByAccount(accountId);

            foreach (var timeline in timelines)
            {
                viewModel.Timelines.Add(new SelectListItem()
                                            {
                                                Text = timeline.Name,
                                                Value = timeline.Id.ToString()
                                            });
            }

            Account account = _accountRepository.FindById(accountId);

            Member m = account.Members.FirstOrDefault(x => x.Timeline.Id.Value == timelineId);
            viewModel.TimelineName = m.Timeline.Name;
            foreach (var memberEvent in m.MemberEvents)
            {
                viewModel.Events.Add(new MemberTimelineViewModel.EventViewModel
                                         {
                                             EventName = memberEvent.Event.Name,
                                             Date = memberEvent.Date
                                         });
            }
            return View(viewModel);
        }
    }
}