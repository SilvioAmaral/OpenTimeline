using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTimeline.Core.Domain;
using OpenTimeline.Core.Repositories;
using OpenTimeline.Core.ViewModel;

namespace OpenTimeline.Web.Controllers
{
    public class MemberController : Controller
    {
        private readonly IRepository<Member> _memberRepository;

        public MemberController(IRepository<Member> memberRepository)
        {
            _memberRepository = memberRepository;
        }

        //
        // GET: /Member/

        public ActionResult Details(int? id)
        {
            var member = _memberRepository.FindById(id.Value);
            var vms = from x in member.MemberEvents
                      select new EventViewModel
                                 {
                                     Name = x.Event.Name,
                                     Date = x.Date,
                                     MemberName = x.Member.Account.Name
                                 };
            return View(vms);
        }

    }
}
