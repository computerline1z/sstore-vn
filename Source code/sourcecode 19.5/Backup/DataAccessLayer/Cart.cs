using System.Collections.Generic;
using BusinessObjects;

namespace DataAccessLayer
{
    public class Cart
    {
        private List<CartInfo> listCart = new List<CartInfo>();
        private int index;//chi so dong trong listCart

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public List<CartInfo> ListCart
        {
            get { return listCart; }
            set { listCart = value; }
        }
        /// <summary>
        /// them mot record vao gio hang ListCart(CartInfo)
        /// </summary>
        /// <param name="cardinfo"></param>
        public void AddItemToCart(CartInfo cardinfo)
        {
            int count = listCart.Count;
            cardinfo.STT = count + 1;
            listCart.Add(cardinfo);
        }
        /// <summary>
        /// cap nhat dong thu _index trong ListCart(CartInfo)
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="cart"></param>
        public void UpdateCart(int _index, CartInfo cart)
        {
            listCart[_index] = cart;
        }
        
        /// <summary>
        /// tim 1 record trong gio hang da co theo productID
        /// </summary>
        /// <param name="list_cart"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        public CartInfo FindRecordInCart(List<CartInfo> list_cart, string productID)
        {
            for (int i = 0; i < list_cart.Count; i++)
            {
                CartInfo cart = list_cart[i];
                if (cart.ProductID == productID)
                {
                    index = i;
                    return cart;
                }
            }
            return null;
        }
        /// <summary>
        /// remove 1 record from your cart by i index
        /// </summary>
        /// <param name="i"></param>
        public void removeFromYourCart(int i)
        {
            listCart.RemoveAt(i);
        }
    }
}
