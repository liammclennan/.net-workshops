using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTax
{
    public class Sale
    {
        private List<SaleLine> saleLines;
        private decimal totalTax;
        private decimal totalValue;

        /// <summary>
        /// Adds a line to the sale.
        /// </summary>
        /// <param name="inputLine">The line to add.</param>
        /// <returns>True for success, False for failure.  Failures are usually caused via incorrect formatting of the input</returns>
        public bool Add(string inputLine)
        {
            SaleLine saleLine;

            saleLine = InputParser.ProcessInput(inputLine);
            saleLines.Add(saleLine);
            totalTax += saleLine.Tax;
            totalValue += saleLine.LineValue;
            return true;
        }

        /// <summary>
        /// The total Tax amount for the sale
        /// </summary>
        public decimal Tax
        {
            get { return totalTax; }
        }

        /// <summary>
        /// The total value of the sale (including Tax)
        /// </summary>
        public decimal TotalValue
        {
            get { return totalValue; }
        }

        /// <summary>
        /// Converts the sale to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (SaleLine line in saleLines)
            {
                if (output.Length > 0)
                    output.Append("\n");
                output.Append(line.ToString());
            }
            //Now add footer information
            output.Append("\n");
            output.AppendFormat("Sales Taxes: {0:#,##0.00}", Tax);
            output.Append("\n");
            output.AppendFormat("Total: {0:#,##0.00}", TotalValue);
            return output.ToString();
        }
    }
}
