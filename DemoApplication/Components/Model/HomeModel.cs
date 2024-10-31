using DemoApplication.Components.Model;
using Microsoft.AspNetCore.Components;

public class HomeModel :ComponentBase
{
    protected List<TaskItem> TaskList = new List<TaskItem>();

    [Inject]
    protected TaskService? TaskService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (TaskService != null)
        {
            TaskList = await TaskService.GetTasksAsync();
        }

        // 状態の小さい順、期限の近い順にソート
        TaskList.Sort((x, y) =>
        {
            // 状態で比較（小さい順）
            int statusComparison = x.Status.CompareTo(y.Status);

            // 状態が同じ場合は期日で比較（近い順）
            if (statusComparison == 0)
            {
                return x.DueDate.CompareTo(y.DueDate);
            }

            return statusComparison;
        });
    }

    protected async Task NavigateToTaskFormAsync()
    {
        if (NavigationManager != null)
        {
            await Task.Yield();
        NavigationManager.NavigateTo("/taskform");
        }
    }
}