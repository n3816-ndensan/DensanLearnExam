using System.ComponentModel.DataAnnotations;

namespace DemoApplication.Components.Model
{
    public class EmployeeItem : IComparable<EmployeeItem>
    {
        [Required(ErrorMessage = "氏名は必須です。")]
        public string Name { get; set; } = String.Empty;

        [Required(ErrorMessage = "入社日は必須です。")]
        public DateTime HireDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "雇用形態は必須です。")]
        public EmploymentTypes EmploymentType { get; set; } = EmploymentTypes.正社員;
        
        public string Remarks { get; set; } = String.Empty;

        public int CompareTo(EmployeeItem? other)
        {
            if (other == null) return 1;

            // 雇用形態で比較（昇順）
            int EmployeeTypeComparison = this.EmploymentType.CompareTo(other.EmploymentType);

            // 雇用形態が同じ場合は入社日で比較（昇順）
            if (EmployeeTypeComparison == 0)
            {
                return this.HireDate.CompareTo(other.HireDate);
            }

            return EmployeeTypeComparison;
        }
    }

    public enum EmploymentTypes
    {
        正社員 = 0,
        嘱託 = 1,
        協力会社 = 3
    }
}