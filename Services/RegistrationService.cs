using EventManagement.Models;

namespace EventManagement.Services {
    public interface IRegistrationService {
        Registration CreateRegistration(Registration input);
    }
}
