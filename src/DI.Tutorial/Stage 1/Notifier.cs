using System;
using System.Linq;

namespace DI.Tutorial.Stage1
{
    public class Notifier
    {
        public void SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName));
        }
    }
}
