namespace backend.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool Posted { get; set; } = false;
    }
}
