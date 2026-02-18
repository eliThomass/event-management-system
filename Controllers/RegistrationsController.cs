using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.Services;

namespace EventManagement.Controllers {

    [ApiController]
    [Route("api/registrations")]

    public class RegistrationsController : ControllerBase {

        private readonly IRegistrationService _registrationService;

        public RegistrationsController() {
            _registrationService = new RegistrationService();
        }

        [HttpPost]
        public ActionResult <Registration> CreateRegistration(Registration input) {
            var newReg = _registrationService.CreateRegistration(input);
            return CreatedAtAction(nameof(CreateRegistration), newReg.Id, newReg);
        }
    }

}
