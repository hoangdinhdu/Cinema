using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Cart
    {

        public Movie Movie { get; set; }
        public int Quantity { get; set; }

        //public Cart(Product product, int quantity)
        //{
        //    Product = product;
        //    Quantity = quantity;
        //}

        //public string GetItemId()
        //{
        //    return Product.ProductID;
        //}
    }
    public class cartHandle
    {
        List<Cart> items = new List<Cart>();
        public IEnumerable<Cart> Items
        {
            get { return items; }
        }

        public void Add(Movie _pro, int _quantity = 1)
        {
            var item = items.FirstOrDefault(s => s.Movie.MovieID == _pro.MovieID);
            if (item == null)
            {
                items.Add(new Cart
                {
                    Movie = _pro,
                    Quantity = _quantity

                });
            }
            else
            {
                item.Quantity += _quantity;
            }
        }

        public void Update_Quantity(string id, int _quantity)
        {
            var item = items.Find(s => s.Movie.MovieID == id);
            if (item != null)
            {
                item.Quantity = _quantity;
            }
        }
        public void SetItemQuantity(string id, int quantity)
        {
            var item = items.Find(s => s.Movie.MovieID == id);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public double Total_money()
        {
            var total = items.Sum(s => s.Movie.MovieMoney * s.Quantity);
            return (double)total;
        }
        public int Total_Quantity()
        {
            return items.Sum(s => s.Quantity);
        }

        public void RemoveCart(string id)
        {
            items.RemoveAll(s => s.Movie.MovieID == id);
        }

    }



}
    
