using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    /// <summary>
    /// BaseProduct is a class that has some basic Properties, such as a Name of the 
    /// Product, Quantity of Product, Price of the Product as well.It implements the
    /// ITaxable inferface.
    /// </summary>
    public class BaseProduct : ITaxable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsImported { get; set; }
        public bool HasSalesTax { get; set; }
        public double TaxPercent { get; set; }
        public int Quantity { get; set; }

        /// <summary>
        /// The BaseProduct constructor used to create a BaseProduct object.  It calls the 
        /// CalculateTaxPercent method for the TaxPercent property and automatically sets
        /// the Quantity of the product to 1.
        /// </summary>
        /// 
        /// <param name="name">Name of the BaseProduct</param>
        /// <param name="price">Price of the BaseProduct</param>
        /// <param name="hasSalesTax">Boolean for if the BaseProduct has a sales tax</param>
        /// <param name="isImported">Boolean for if the BaseProduct is imported</param>
        public BaseProduct(string name, double price, bool hasSalesTax, bool isImported)
        {
            this.Name = name;
            this.Price = price;
            this.HasSalesTax = hasSalesTax;
            this.IsImported = isImported;
            this.TaxPercent = CalculateTaxPercent();
            this.Quantity = 1;
        }

        /// <summary>
        /// CalculateTaxPercent checks the Properties of IsImported and HasSalesTax to
        /// determine the percent of Sales Tax applied to the product.It's from the 
        /// ITaxable interface.
        /// </summary>
        /// 
        /// <returns>Returns the value of the calculated tax percentage</returns>
        public double CalculateTaxPercent()
        {
            double taxPercent = 0;
            if (IsImported)
            {
                taxPercent += .05;
            }
            if (HasSalesTax)
            {
                taxPercent += .1;
            }
            return taxPercent;
        }

        /// <summary>
        /// TaxedAmount will get the value of the total sales tax.  In addition,
        /// it will round up the sales tax value to the nearest 0.05.
        /// </summary>
        /// 
        /// <returns>Returns the value of the sales tax with any applicable rounding</returns>
        public double TaxedAmount()
        {
            double result = (Price * TaxPercent);
            double modDifference = ((Price * (TaxPercent * 100)) % 5) - 5;
            if (modDifference != 0 && modDifference > -5)
            {
                result += Math.Abs(modDifference)/100;
            }
            return Math.Round(result, 2);
        }

        /// <summary>
        /// Get the values of the sales tax with the price of the
        /// product multiplied by the number of the same products.
        /// </summary>
        /// 
        /// <returns> Returns the value of the total price after the tax, quantity.</returns>
        public double TotalPrice()
        {
            return Quantity * (TaxedAmount() + Price);
        }

        /// <summary>
        /// PrintProduct will print the details of the product to the console.
        /// </summary>
        /// 
        /// <param name="isOutput">Boolean value to see if it will be printing
        /// the input values or output values</param>
        /// <returns>Returns a string that displays the record of the product</returns>
        public string PrintProduct(bool isOutput)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Quantity + " ");
            if (IsImported)
            {
                sb.Append("imported ");
            }
            sb.Append(Name + ": ");
            if(isOutput)
            {
                sb.Append(TotalPrice().ToString("F"));
            }
            else
            {
                sb.Append(Price.ToString("F"));
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
