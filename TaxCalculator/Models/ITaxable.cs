using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculator.Models
{
    /// <summary>
    /// ITaxable is an interface that products can use to handle taxes applied to a product.
    /// </summary>
    interface ITaxable
    {
        bool IsImported { get; set; }
        bool HasSalesTax { get; set; }
        double TaxPercent { get; set; }

        /// <summary>
        /// CalculateTaxPercent is a method that will get the percentage value of a product's tax.
        /// </summary>
        /// 
        /// <returns>Returns the value of the tax percent</returns>
        double CalculateTaxPercent();
    }
}
