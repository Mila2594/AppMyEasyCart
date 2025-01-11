using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEasyCart.Models
{
    public class WishlistService
    {
        private static WishlistService _instance;
        public static WishlistService Instance => _instance ??= new WishlistService();

        private readonly ObservableCollection<ItemWishList> _wishList = new ObservableCollection<ItemWishList>();

        public ObservableCollection<ItemWishList> WishList => _wishList;

        public void AddToWishList(Product product)
        {
            if (!IsInWishList(product))
            {
                _wishList.Add(new ItemWishList(product));
            }
        }

        public void RemoveFromWishList(Product product)
        {
            var item = _wishList.FirstOrDefault(x => x.Product.Id == product.Id);
            if (item != null)
            {
                _wishList.Remove(item);
            }
        }

        public bool IsInWishList(Product product)
        {
            return _wishList.Any(x => x.Product.Id == product.Id);
        }
    }
}
