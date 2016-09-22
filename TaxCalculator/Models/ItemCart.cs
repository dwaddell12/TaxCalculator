using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    /// <summary>
    /// ItemCart has a name and a cart of Products in it, as represented by
    /// the List of BaseProducts.
    /// </summary>
    public class ItemCart
    {
        public string Name { get; set; }
        public List<BaseProduct> Products { get; set; }
        
        /// <summary>
        /// The ItemCart constructor used to create an ItemCart object.
        /// </summary>
        /// 
        /// <param name="name">The name of the ItemCart</param>
        public ItemCart(string name)
        {
            this.Name = name;
        }
        
        /// <summary>
        /// CalculateTaxes assess the entire amount of the sales tax for all
        /// BaseProduct objects in the ItemCart.
        /// </summary>
        /// 
        /// <returns>Returns the value of all the sales taxes added together.</returns>
        public double CalculateTaxes()
        {
            double allTaxes = 0;
            foreach (BaseProduct product in Products)
            {
                allTaxes += product.TaxedAmount();
            }
            return allTaxes;
        }

        /// <summary>
        /// CalculateTotal gets the entire amount of the sales tax and price
        /// of all the BaseProduct objects in the ItemCart and combines them.
        /// </summary>
        /// 
        /// <returns>Returns the value of all the sales taxes and product prices added
        /// together.</returns>
        public double CalculateTotal()
        {
            double allTotals = 0;
            foreach (BaseProduct product in Products)
            {
                allTotals += product.TotalPrice();
            }
            return allTotals;
        }
        /// <summary>
        /// PrintCart will take a boolean value to see if it will be printing
        /// the input values or output values.Then it'll cycle through the 
        /// products and print each item on a line.
        /// </summary>
        /// 
        /// <param name="isOutput"></param>
        /// <returns>Returns a string that displays the record of the product.</returns>
        public string PrintCart(bool isOutput)
        {
            StringBuilder sb = new StringBuilder();
            if (isOutput)
            {
                sb.AppendLine(Name + "'s Output:");
            }
            else
            {
                sb.AppendLine(Name + "'s Input:");
            }
            foreach (BaseProduct product in Products)
            {
                sb.Append(product.PrintProduct(isOutput));
            }
            if (isOutput)
            {
                sb.AppendLine("Sales Taxes: " + CalculateTaxes().ToString("F"));
                sb.AppendLine("Total: " + CalculateTotal().ToString("F"));
            }
            return sb.ToString();
        }
    }
}