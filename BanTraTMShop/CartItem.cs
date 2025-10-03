using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BanTraTMShop
{
    public class CartItem
    {
        public int maTra { get; set; }
        public string tenTra { get; set; }
        public decimal giaBan { get; set; }
        public int soLuong { get; set; }
        public string anh { get; set; }
        public decimal tongTien { get; set; }
    }
}