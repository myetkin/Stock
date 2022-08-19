using System.Collections.Generic;

namespace Stock.Data
{
    public class tb_Variant
    {
        public tb_Variant()
        {
            tb_Product = new HashSet<tb_Product>();
        }
        public int  Id {get;set;}
        public string Name {get;set;}
        public string Code { get; set; }

        public virtual tb_Status StatusRefNavigation { get; set; }
        public virtual ICollection<tb_Product> tb_Product { get; set; }
    }
}
