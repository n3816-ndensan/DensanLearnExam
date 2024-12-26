using DemoApplication.Components.Model;
using DemoApplication.Components.Entities;
using Microsoft.AspNetCore.Components;

namespace DemoApplication.Components.Pages;

public partial class Home : ComponentBase
{
    protected List<EmployeeItem> EmployeeList = new List<EmployeeItem>();

    [Inject]
    protected EmployeeService? EmployeeService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (EmployeeService != null)
        {
            EmployeeList = await EmployeeService.GetTasksAsync();
        }

        EmployeeList.Sort();
    }

    protected async Task NavigateToEmployeeFormAsync()
    {
        if (NavigationManager != null)
        {
            await Task.Yield();
            NavigationManager.NavigateTo("/employeeForm");
        }
    }
}