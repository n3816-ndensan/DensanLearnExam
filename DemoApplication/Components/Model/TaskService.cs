using DemoApplication.Components.Model;

public class TaskService
{
    public List<TaskItem> TaskList { get; private set; } = new List<TaskItem>();

    public TaskService()
    {
        // 初期データの登録
        TaskList.Add(new TaskItem
        {
            Title = "タスク1",
            DueDate = DateTime.Today,
            Status = TaskState.完了,
            Description = "タスク1の内容"
        });
        TaskList.Add(new TaskItem
        {
            Title = "タスク2",
            DueDate = DateTime.Today.AddDays(2),
            Status = TaskState.仕掛中,
            Description = "タスク2の内容"
        });
        TaskList.Add(new TaskItem
        {
            Title = "タスク3",
            DueDate = DateTime.Today.AddDays(-2),
            Status = TaskState.未着手,
            Description = "タスク3の内容"
        });
    }

    public Task<List<TaskItem>> GetTasksAsync()
    {
        // 非同期でタスクリストを取得
        return Task.FromResult(TaskList);
    }

    public Task AddTaskAsync(TaskItem task)
    {
        TaskList.Add(task);
        return Task.CompletedTask;
    }
}