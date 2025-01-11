using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public class ItemWishList
    {
        public Product Product { get; set; }
        public bool  EnCarrito { get; set; }

        public ItemWishList(Product product, bool enCarrito = false)
        {
            Product = product;
            EnCarrito = enCarrito;
        }
    }
}
