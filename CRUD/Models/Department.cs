namespace CRUD.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerNAme { get; set; }

        public virtual List<Employee>? Employees { get; set; }
    }
}
