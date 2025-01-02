using Microsoft.AspNetCore.Mvc;
using static TravelPlannerApp.Pages.Itinerary;

namespace TravelPlannerApp.Controllers.Apis
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItineraryController : ControllerBase
    {
        private static List<DayPlan> _plans = new List<DayPlan>();

        [HttpGet]
        public IActionResult GetPlans()
        {
            return Ok(_plans);
        }

        [HttpPost]
        public IActionResult SavePlans([FromBody] List<DayPlan> plans)
        {
            _plans = plans;
            return Ok();
        }
    }
}