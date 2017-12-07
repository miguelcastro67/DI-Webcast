using System;
using System.Linq;

namespace DI.Tutorial.Stage3
{
    public class BillingProcessor : IBillingProcessor
    {
        public BillingProcessor(ILogger logger)
        {
            _Logger = logger;
        }

        ILogger _Logger;

        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine(string.Format("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price));
            _Logger.Log("Finished processing payment.");
        }
    }

    public interface IBillingProcessor
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
