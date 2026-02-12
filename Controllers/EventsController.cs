using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.Services;

namespace EventManagement.Controllers {

    [ApiController]
    [Route("api/events")]

    public class EventsController : ControllerBase {

        private readonly IEventService _eventService;
        
        public EventsController() {
            _eventService = new EventService();
        }


        [HttpGet]
        public ActionResult <List<Event>> GetEvents() {
            return Ok(_eventService.GetEvents());
        }

        [HttpGet("id:guid")]
        public ActionResult <List<Event>> GetEvent(Guid id) {
            var _event = _eventService.GetEvent(id);
            if (_event == null) return NotFound();
            return Ok(_event);

        }

        [HttpPost]
        public ActionResult <Event> CreateEvent(Event input) {
            var newEvent = _eventService.CreateEvent(input);
            return CreatedAtAction(nameof(CreateEvent), newEvent.Id, newEvent); 
        }
    }

}
