namespace CRUD.DTOs
{
    public class DepartmentWithEmployeesDTO
    {
        public int Id { get; set; }
        public string DepName { get; set; }
        public List<EmployeeDTO> EmpsName { get; set; } = new List<EmployeeDTO>();
    }
}
