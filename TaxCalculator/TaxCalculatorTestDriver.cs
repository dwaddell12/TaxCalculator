using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.Models;

namespace TaxCalculator
{
    /// <summary>
    /// TaxCalculatorTestDriver runs a simulation of the TaxCalculator program.
    /// It will create sample data and run the program against that data.
    /// </summary>
    public class TaxCalculatorTestDriver
    {
        private List<ItemCart> carts;
        private const string CART_A = "Cart A",
                             CART_B = "Cart B",
                             CART_C = "Cart C";
        /// <summary>
        /// Run controls the flow of the program, starting with the creation of
        /// the sample data and ending with the printed output values of the 
        /// program.
        /// </summary>
        public void Run()
        {
            carts = CreateCarts();
            Console.WriteLine("INPUT");
            foreach(ItemCart cart in carts)
            {
                Console.WriteLine(cart.PrintCart(false));
            }
            Console.WriteLine("OUTPUT");
            foreach(ItemCart cart in carts)
            {
                Console.WriteLine(cart.PrintCart(true));
            }
            Console.ReadLine();
        }

        /// <summary>
        /// CreateCarts instantiates three cart objects, then calls the 
        /// AddProductsToCart for each instantiated cart.
        /// </summary>
        /// 
        /// <returns>Returns the List of ItemCart objects instantiated in this method.</returns>
        private List<ItemCart> CreateCarts()
        {
            ItemCart cartA = new ItemCart(CART_A);
            ItemCart cartB = new ItemCart(CART_B);
            ItemCart cartC = new ItemCart(CART_C);

            cartA.Products = AddProductsToCart(cartA);
            cartB.Products = AddProductsToCart(cartB);
            cartC.Products = AddProductsToCart(cartC);

            return new List<ItemCart>() { cartA, cartB, cartC };
        }
        /// <summary>
        /// AddProductsToCart takes a cart object and, depending on the name of
        /// the cart, will populate it with a specific List of BaseProduct objects.
        /// </summary>
        /// 
        /// <param name="cart">The ItemCart object that will have products added to it</param>
        /// <returns>Returns the full list of products for the cart.</returns>
        private List<BaseProduct> AddProductsToCart(ItemCart cart)
        {
            List<BaseProduct> products;
            BaseProduct productA, productB, productC, productD;

            switch (cart.Name)
            {
                case CART_A:
                    productA = new BaseProduct("book", 12.49, false, false);
                    productB = new BaseProduct("music CD", 14.99, true, false);
                    productC = new BaseProduct("chocolate bar", .85, false, false);
                    products = new List<BaseProduct>() { productA, productB, productC };
                    break;
                case CART_B:
                    productA = new BaseProduct("box of chocolates", 10, false, true);
                    productB = new BaseProduct("bottle of perfume", 47.5, true, true);
                    products = new List<BaseProduct>() { productA, productB };
                    break;
                case CART_C:
                    productA = new BaseProduct("bottle of perfume", 27.99, true, true);
                    productB = new BaseProduct("bottle of perfume", 18.99, true, false);
                    productC = new BaseProduct("packet of headache pills", 9.75, false, false);
                    productD = new BaseProduct("box of chocolates", 11.25, false, true);
                    products = new List<BaseProduct>() { productA, productB, productC, productD };
                    break;
                default:
                    products = new List<BaseProduct>();
                    break;
            }
            return products;
        }
    }
}
