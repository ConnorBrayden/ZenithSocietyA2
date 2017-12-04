using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZenithSocietyA2.Data;
using ZenithSocietyA2.Models;
using ZenithSocietyA2.Data;
using Microsoft.AspNetCore.Authorization;


namespace ZenithSocietyA2.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsapiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsapiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Events?startDate=2017-01-01
        [HttpGet]
        public IEnumerable<Event> GetEvents([FromQuery] string startDate)
        {

            DateTime start       = new DateTime();
            List<DateTime> dates = null;
            bool tryStart        = false;

            if (String.IsNullOrEmpty(startDate))
            {
                return _context.Events;
            }
            
            tryStart = DateTime.TryParse(startDate, out start);


            dates = tryStart ? GetDaysOfCurrentWeekFromStart(start) : GetDaysOfCurrentWeek();

            List<Event> apiEvents = new List<Event>();
            var allEvents = _context.Events;
            var events    = _context.Events.Include(e => e.ActivityCategory).Where(e => e.IsActive == true).ToList();

            // Sort the events by date time
            events.Sort((x, y) => x.FromDate.CompareTo(y.FromDate));

            List<Event> eventsToReturn = new List<Event>();

            //List<DateandEventsModel> datesEvents = new List<DateandEventsModel>();
            
            foreach (var d in dates)
            {
                Event currentModel = new Event();
                
                var dayOfWeek = (d.ToString("D", new CultureInfo("EN-US")));
            
                
                //currentModel.Events = new List<Event>();
                foreach (var e in events)
                {
                    if (e.FromDate.Date == d.Date)
                    {
                       eventsToReturn.Add(new Event {
                            EnteredByUsername = e.EnteredByUsername,
                            ToDate = e.ToDate,
                            EventId = e.EventId,
                            CreationDate = e.CreationDate,
                            IsActive = e.IsActive,
                            ActivityCategoryId = e.ActivityCategoryId,
                            FromDate = e.FromDate,
                            
                            ActivityCategory = _context.ActivityCategories.Find(e.ActivityCategoryId)
                            
                        });
                    }
                }
                //eventsToReturn.Add(currentModel);
            }

            return eventsToReturn;
            
            
            //foreach (var e in allEvents)
            //{
            //    apiEvents.Add(new ApiEventModel
            //    {
            //        Username = e.Username,
            //        EndDateTime = e.EndDateTime,
            //        EventId = e.EventId,
            //        CreationDate = e.CreationDate,
            //        IsActive = e.IsActive,
            //        StartDateTime = e.StartDateTime,
            //        ActivityCategory = _context.ActivityCategories.Find(e.ActivityCategoryId).ActivityDescription
            //    });
            //}
            //return apiEvents;
            
        }

        public static List<DateTime> GetDaysOfCurrentWeek()
        {
            DateTime startOfWeek = DateTime.Today.AddDays(
                ((int)(CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek + 1)) -
                 (int)DateTime.Today.DayOfWeek);

            var result = Enumerable
              .Range(0, 7)
              .Select(i => startOfWeek
                 .AddDays(i)).ToList<DateTime>();
            return result;
            
        }

        public static List<DateTime> GetDaysOfCurrentWeekFromStart(DateTime start)
        {
            return Enumerable.Range(0,7).Select(i => start.AddDays(i)).ToList<DateTime>();
        }

        // GET: api/Eventsapi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Studentsapi/5
        [HttpPut("{id}")]    
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutEvent([FromRoute] int id, [FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.EventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Studentsapi
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostEvent([FromBody] Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Events.Add(@event);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Studentsapi/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @event = await _context.Events.SingleOrDefaultAsync(m => m.EventId == id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();

            return Ok(@event);
        }

        private bool StudentExists(int id)
        {
            return _context.Events.Any(e => e.EventId == id);
        }
    }
}