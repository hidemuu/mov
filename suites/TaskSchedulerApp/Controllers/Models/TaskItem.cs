namespace TaskSchedulerApp.Controllers.Models
{
    public class TaskItem
    {
        public string TaskName { get; set; } = string.Empty; // 工程
        public string Team { get; set; } = string.Empty; // 担当チーム
        public string Assignee { get; set; } = string.Empty; // 担当者
        public int Period { get; set; } = 0; // 期間
        public int ExpectedPeriod { get; set; } = 0; // 目安期間
        public string Status { get; set; } = string.Empty; // 進捗
        public Dictionary<string, int> WeeklyEffort { get; set; } = new Dictionary<string, int>(); // 各週の工数
    }
}
