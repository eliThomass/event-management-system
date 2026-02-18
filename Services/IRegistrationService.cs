using EventManagement.Models;

namespace EventManagement.Services {
    public class RegistrationService : IRegistrationService {
        private static List<Registration> Registrations = new List<Registration> {};

        public Registration CreateRegistration(Registration input) {
            var newReg = new Registration {
                Id = Guid.NewGuid(),
                EventId = input.EventId,
                UserId = input.UserId,
                RegisteredAt = input.RegisteredAt,
                Status = input.Status,
            };
            Registrations.Add(newReg);
            return newReg;
        }
    }
}
