namespace BlazorWasm.Controllers.TravelPlanner.Models
{
    public class DayPlan
    {
        public int Day { get; set; }

        public string Title { get; set; } = string.Empty;

        public List<string> Activities { get; set; } = new();
    }
}
