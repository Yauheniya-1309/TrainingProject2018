namespace My3Common.Controllers
{
    public class Event : IEvent
    {
        public string Date { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}