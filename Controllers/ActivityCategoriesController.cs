using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
//using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ZenithSocietyA2.Models;
using ZenithSocietyA2.Data;

namespace ZenithSocietyA2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ActivityCategoriesController : Controller
    {
        private ApplicationDbContext db;
        
        // Brayden 2017-12-14 - Adding localization

        private readonly IStringLocalizer<ActivityCategoriesController> _localizer;

        public ActivityCategoriesController(ApplicationDbContext context, IStringLocalizer<ActivityCategoriesController> localizer)
        {
            db = context;
            _localizer = localizer;
       //     _localizer = (IStringLocalizer<ActivityCategoriesController>)_localizer.WithCulture(new CultureInfo("fr-FR"));
            
            

        }
        
        
        // GET: ActivityCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.ActivityCategories.ToListAsync());
        }

        // GET: ActivityCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActivityCategory activityCategory = await db.ActivityCategories.FindAsync(id);
            if (activityCategory == null)
            {
                return NotFound();
            }
            return View(activityCategory);
        }

        // GET: ActivityCategories/Create
        public ActionResult Create()
        {
            ViewData["title"] = _localizer["Create Activity Category"];
            
            Console.WriteLine($"title: {ViewData["title"]}");
            Console.WriteLine($"create: {_localizer.GetString("Create")}");
            
            ViewBag.description = _localizer["Enter a description for a new activity category"];
            ViewBag.inputLabel = _localizer["Activity Description"];
            ViewBag.create = _localizer["Create"];
            ViewBag.back = _localizer["Back to List"];
            
            return View();
        }

        // POST: ActivityCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("ActivityCategoryId,ActivityDescription,CreationDate")] ActivityCategory activityCategory)
        {
            activityCategory.CreationDate = DateTime.Now;
            if (ModelState.IsValid)
            { 
                db.ActivityCategories.Add(activityCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(activityCategory);
        }

        // GET: ActivityCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActivityCategory activityCategory = await db.ActivityCategories.FindAsync(id);
            if (activityCategory == null)
            {
                return NotFound();
            }
            return View(activityCategory);
        }

        // POST: ActivityCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind("ActivityCategoryId,ActivityDescription,CreationDate")] ActivityCategory activityCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activityCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(activityCategory);
        }

        // GET: ActivityCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ActivityCategory activityCategory = await db.ActivityCategories.FindAsync(id);
            if (activityCategory == null)
            {
                return NotFound();
            }
            return View(activityCategory);
        }

        // POST: ActivityCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ActivityCategory activityCategory = await db.ActivityCategories.FindAsync(id);
            db.ActivityCategories.Remove(activityCategory);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
