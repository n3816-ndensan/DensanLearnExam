using DemoApplication.Components.Model;
using Microsoft.AspNetCore.Components;

public class TaskFormModel : ComponentBase
{
    protected TaskItem newTask = new TaskItem();

    [Inject]
    protected TaskService? TaskService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected async Task HandleValidSubmitAsync()
    {
        if (TaskService != null && NavigationManager != null)
        {
            await TaskService.AddTaskAsync(newTask);
            NavigationManager.NavigateTo("/");
        }
    }

    protected async Task NavigateToHomeAsync()
    {
        if (NavigationManager != null)
        {
            await Task.Yield();
            NavigationManager.NavigateTo("/");
        }
    }
}