using System;

namespace SalesTax
{
    public class SaleLine
    {

        #region Private Member Variables
        private string productName;
        private decimal price;
        private bool isImported;
        private int quantity;
        private decimal taxAmount;
        private decimal lineValue;
        #endregion

        #region Public Properties
        public string ProductName
        {
            get { return productName; }
        }

        public decimal Price
        {
            get { return price; }
        }

        public bool IsImported
        {
            get { return isImported; }
        }

        public int Quantity
        {
            get { return quantity; }
        }

        public decimal LineValue
        {
            get { return lineValue; }
        }

        public decimal Tax
        {
            get { return taxAmount; }
        }
        #endregion

        /// <summary>
        /// Default constructor is not publicly accesible
        /// </summary>
        private SaleLine()
        {
        }

        /// <summary>
        /// Public constructor for the sale line
        /// </summary>
        /// <param name="lineQuantity">Quantity on order</param>
        /// <param name="name">name of the product</param>
        /// <param name="unitPrice">price of a single item</param>
        /// <param name="itemIsImported">flag to indicate if the item is imported</param>
        public SaleLine(int lineQuantity, string name, decimal unitPrice, bool itemIsImported)
        {
            int taxRate;
            if (string.IsNullOrEmpty(name)) name = string.Empty;

            quantity = lineQuantity;
            productName = name;
            price = unitPrice;
            isImported = itemIsImported;
            lineValue = price * quantity;

            // calculate taxable amount
            // ideally should really have a product list and tax rules, but this'll have to do for the exercise.
            if (productName.Contains("book") || productName.Contains("tablet") || productName.Contains("chip"))
                taxRate = 0;  //No base tax applicable for books, medicals items or food
            else
                taxRate = 10; //10% base tax or general products
            if (isImported)
                taxRate = 5; //5% regardless for any imported items

            taxAmount = CalculateTax(lineValue,taxRate);
            //Add tax to line value
            lineValue += taxAmount;
            return;
        }

        /// <summary>
        /// Calculates the amount of tax for a value, rounded up to the nearest 5 cents
        /// </summary>
        /// <param name="value">The original value</param>
        /// <param name="taxRate">The tax rate to apply</param>
        /// <returns>The calculated tax on the original value</returns>
        public static decimal CalculateTax(decimal value, int taxRate)
        {
            double amount;
            double remainder;

            amount = (double)Math.Round((value * taxRate)/100,2);

            //Now round up to nearest 5 cents.
            remainder = amount % .05;
            if (remainder > 0)
                amount += .05 - remainder;
            return (decimal)amount;
        }

        /// <summary>
        /// Converts the sale line to a string
        /// </summary>
        /// <returns>The string representation of the sale line</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}: {2:#,###.00}", Quantity, ProductName, LineValue);
        }
    }
}
