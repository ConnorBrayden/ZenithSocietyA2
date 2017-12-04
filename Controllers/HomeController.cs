using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithSocietyA2.Data;
using ZenithSocietyA2.Models;

namespace ZenithSocietyA2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        
        
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        
        public IActionResult Index()
        {
            
            int dayOffest = (int)DateTime.Now.DayOfWeek;
            if (dayOffest == 0) dayOffest = 6;
            else dayOffest--;



            DateTime mondayDate = DateTime.Now.AddDays(-dayOffest);
            DateTime sundayDate = mondayDate.AddDays(6);

            var events = dbContext.Events
                .Where(x => x.ToDate.CompareTo(mondayDate) >= 0 
                            && x.FromDate.CompareTo(sundayDate) <= 0 
                            && x.IsActive)
                .OrderBy(x => x.FromDate)
                .Include(x => x.ActivityCategory).ToList();

            
            return View(events);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
