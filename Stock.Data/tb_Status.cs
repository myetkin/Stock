using System.Collections.Generic;

namespace Stock.Data
{
    public class tb_Status
    {
        public tb_Status()
        {
            tb_Product = new HashSet<tb_Product>();
        }

        public int StatusRef { get; set; }
        public string Status { get; set; }

        public virtual ICollection<tb_Product> tb_Product { get; set; }
    }
}
