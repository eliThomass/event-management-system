using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;

namespace EventManagement.Controllers {

    [ApiController]
    [Route("api/events")]

    public class EventsController : ControllerBase {
        // Our database of events
        private static List<Event> Events = new List<Event> {
            new Event 
            { 
                Id = Guid.NewGuid(),
                Title = "Tech Conference 2026",
                Description = "A conference about modern software development.",
                StartDateTime = new DateTime(2026, 3, 10, 9, 0, 0),
                EndDateTime = new DateTime(2026, 3, 10, 17, 0, 0),
                Location = "Seattle, WA",
                Capacity = 250,
            }
        };

        // Our Api routes

        [HttpGet]
        public ActionResult <List<Event>> GetEvents() {
            return Ok(Events);
        }

        [HttpGet("id:guid")]
        public ActionResult <List<Event>> GetEvent(Guid id) {
            var _event = Events.FirstOrDefault(s => s.Id == id);
            
            if (_event == null) return NotFound();

            return Ok(_event);
        }

        [HttpPost]
        public ActionResult <Event> CreateEvent(Event input) {
            var newEvent = new Event {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Description = input.Description,
                StartDateTime = input.StartDateTime,
                EndDateTime = input.EndDateTime,
                Capacity = input.Capacity
            };

            Events.Add(newEvent);
            return CreatedAtAction(nameof(GetEvent), new { id = newEvent.Id }, newEvent);
        }
    }

}
