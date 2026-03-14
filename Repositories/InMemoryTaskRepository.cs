using TaskTracker.Models;

namespace TaskTracker.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<BaseTask> _tasks = new();

        public IEnumerable<BaseTask> GetAll()
        {
            return _tasks;
        }

        public BaseTask? GetById(Guid id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(BaseTask task)
        {
            _tasks.Add(task);
        }

        public void Update(BaseTask task)
        {
            // In-memory list automatically updated since reference type
        }
    }
}