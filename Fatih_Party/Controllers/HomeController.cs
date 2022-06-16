using Fatih_Party.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Fatih_Party.Controllers
{
	public class HomeController : Controller
	{
		public static List<VisitorsModel> visitors = new List<VisitorsModel>();

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(VisitorsModel visitor)
		{
			visitors.Add(visitor);
			return RedirectToAction(nameof(Create));
		}

		public IActionResult Summary()
		{
			ViewBag.NumberofGuests = visitors.Count;
			ViewBag.NumberOfFamilyGuests = visitors.Where(v => v.IsFamily).Count();
			ViewBag.Youngest = visitors.Min(v => v.Age);
			ViewBag.Oldest = visitors.Max(v => v.Age);

			return View();
		}
	}
}
