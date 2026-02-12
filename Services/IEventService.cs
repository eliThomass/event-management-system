using EventManagement.Models;

namespace EventManagement.Services {

    public interface IEventService {
        List<Event> GetEvents();
        Event? GetEvent(Guid id);
        Event CreateEvent(Event input);
    }

}
