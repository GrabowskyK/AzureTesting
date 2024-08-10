using Microsoft.AspNetCore.Mvc;

namespace AzureTesting.Controllers
{
    public class EventController : ControllerBase
    {
        private readonly IEventController eventController;
        private readonly ILogger<EventController> logger;

        public EventController(IEventController eventController, ILogger<EventController> logger)
        {
            this.eventController = eventController;
            this.logger = logger;
        }
    }
}
