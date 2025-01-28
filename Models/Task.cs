namespace To_do_List.Models
{
    public class Task
    {
        public int Id_Task { get; set; }
        public string Name_Task { get; set; }
        public string Description_Task { get; set; }
        public float Time { get; set; }
        public int Id_Status_Task { get; set; }
        public Status_Task Status_Task { get; set; }
    }
}
