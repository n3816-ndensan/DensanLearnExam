using DemoApplication.Components.Model;
using Microsoft.AspNetCore.Components;

public class HomeModel :ComponentBase
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