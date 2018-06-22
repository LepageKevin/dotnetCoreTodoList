using todoList.Models;

namespace todoList.Data
{
    public class TaskItem
    {
        public int ID { get; set; }

        public StateType State { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }
        
        public ApplicationUser User { get; set; }

        public enum StateType
        {
            Idea,
            Todo,
            InProgress,
            Finish
        }
    }
}