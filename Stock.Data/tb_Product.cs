namespace Stock.Data
{
    public class tb_Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code {get;set;}
        public int StatusRef { get; set; }
        public bool IsDeleted { get; set; }

        public virtual tb_Status StatusRefNavigation { get; set; }
    }
}
