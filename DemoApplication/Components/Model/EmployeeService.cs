using DemoApplication.Components.Entities;

namespace DemoApplication.Components.Model;

public class EmployeeService
{
    public List<EmployeeItem> EmployeeList { get; private set; } = new List<EmployeeItem>();

    public EmployeeService()
    {
        // 初期データの登録
        EmployeeList.Add(new EmployeeItem
        {
            Name = "佐藤 太郎",
            HireDate = DateTime.Today,
            EmploymentType = EmploymentTypes.正社員,
            Remarks = "ビジネスソリューション１部\nプロジェクトマネージャー\nリーダー"
        });
        EmployeeList.Add(new EmployeeItem
        {
            Name = "鈴木 次郎",
            HireDate = DateTime.Today.AddDays(1),
            EmploymentType = EmploymentTypes.嘱託,
            Remarks = "公共ソリューション３部\n部長"
        });
        EmployeeList.Add(new EmployeeItem
        {
            Name = "高橋 三郎",
            HireDate = DateTime.Today.AddDays(-1),
            EmploymentType = EmploymentTypes.嘱託,
            Remarks = "～2025/02/28"
        });
        EmployeeList.Add(new EmployeeItem
        {
            Name = "田中 四郎",
            HireDate = DateTime.Today.AddDays(2),
            EmploymentType = EmploymentTypes.協力会社,
            Remarks = "テクノソリューションズ（株）"
        });
        EmployeeList.Add(new EmployeeItem
        {
            Name = "伊藤 五郎",
            HireDate = DateTime.Today.AddDays(-2),
            EmploymentType = EmploymentTypes.協力会社,
            Remarks = "アーキテクトシステムズ（株）"
        });
    }

    public Task<List<EmployeeItem>> GetTasksAsync()
    {
        // 非同期でタスクリストを取得
        return Task.FromResult(EmployeeList);
    }

    public Task AddTaskAsync(EmployeeItem task)
    {
        EmployeeList.Add(task);
        return Task.CompletedTask;
    }
}