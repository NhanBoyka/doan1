using doan1.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace doan1.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var item = _shoppingCart.GetShoppingCartItems();

            return View(item.Count);
        }
    }
}
