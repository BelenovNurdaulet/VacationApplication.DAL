namespace VacationApplication.DAL.Models;

public class VacationApplicationResponse
{
    public int Id { get; set; }
    public int CreateBy { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ApplicationTypeId { get; set; }
}