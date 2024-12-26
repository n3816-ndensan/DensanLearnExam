using DemoApplication.Components.Model;
using Microsoft.AspNetCore.Components;

public class EmployeeFormModel : ComponentBase
{
    protected EmployeeItem newEmployee = new EmployeeItem();

    [Inject]
    protected EmployeeService? EmployeeService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected async Task HandleValidSubmitAsync()
    {
        if (EmployeeService != null && NavigationManager != null)
        {
            await EmployeeService.AddTaskAsync(newEmployee);
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