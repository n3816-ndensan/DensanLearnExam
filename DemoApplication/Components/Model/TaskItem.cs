using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Components.Model
{
    public class TaskItem
    {
        [Required(ErrorMessage = "題名は必須です。")]
        public string Title { get; set; } = String.Empty;

        [Required(ErrorMessage = "期日は必須です。")]
        public DateTime DueDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "状態は必須です。")]
        public TaskState Status { get; set; } = TaskState.未着手;

        public string Description { get; set; } = String.Empty;
    }

    public enum TaskState
    {
        未着手 = 0,
        仕掛中 = 1,
        完了 = 2,
        無視 = 9
    }
}