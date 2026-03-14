using System;

namespace TaskTracker.Models
{
    public abstract class BaseTask
    {
        public Guid Id { get; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; }
        public bool IsCompleted { get; private set; }

        // Delegate
        public delegate void TaskCompletedHandler(BaseTask task);

        // Event
        public event TaskCompletedHandler? OnTaskCompleted;

        protected BaseTask(string title)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Title = title;
            IsCompleted = false;
        }

        public void CompleteTask()
        {
            if (!IsCompleted)
            {
                IsCompleted = true;
                OnTaskCompleted?.Invoke(this);
            }
        }
    }
}