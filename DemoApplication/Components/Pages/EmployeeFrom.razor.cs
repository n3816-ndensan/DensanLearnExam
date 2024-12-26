using DemoApplication.Components.Model;
using DemoApplication.Components.Entities;
using Microsoft.AspNetCore.Components;

namespace DemoApplication.Components.Pages;
public partial class EmployeeForm
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