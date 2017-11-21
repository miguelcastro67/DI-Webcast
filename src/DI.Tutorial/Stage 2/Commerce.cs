using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Tutorial.Stage2
{
    public class Commerce
    {
        public Commerce(IBillingProcessor billingProcessor, ICustomerProcessor customerProcessor, INotifier notifier)
        {
            _BillingProcessor = billingProcessor;
            _CustomerProcessor = customerProcessor;
            _Notifier = notifier;
        }

        IBillingProcessor _BillingProcessor;
        ICustomerProcessor _CustomerProcessor;
        INotifier _Notifier;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _CustomerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Notifier.SendReceipt(orderInfo);
        }
    }
}
