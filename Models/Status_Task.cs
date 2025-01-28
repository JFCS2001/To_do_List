namespace To_do_List.Models
{
    public class Status_Task
    {
        public int Id_Status_Task { get; set; }
        public string Name_Status_Task { get; set; }

    public ICollection<Task> Tasks { get; set; }
    }
}
