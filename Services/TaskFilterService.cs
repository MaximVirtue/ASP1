using System.Collections.Generic;
using System.Linq;
using TaskTracker.Models;

namespace TaskTracker.Services
{
    public static class TaskFilterService
    {
        public static List<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
        {
            return tasks
                .OfType<BugReportTask>()
                .Where(t => !t.IsCompleted && t.SeverityLevel == "High")
                .OrderByDescending(t => t.CreatedAt)
                .ToList();
        }

        public static int GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
        {
            return tasks
                .OfType<FeatureRequestTask>()
                .Where(t => !t.IsCompleted)
                .Sum(t => t.EstimatedHours);
        }
    }
}   