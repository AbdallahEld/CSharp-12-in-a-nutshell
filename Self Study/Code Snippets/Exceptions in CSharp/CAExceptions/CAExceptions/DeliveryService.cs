using System;
using System.Collections.Generic;
using System.Text;

namespace CAExceptions
{
    public class DeliveryService
    {
        private readonly static Random random = new Random();
        public void Start(Delivery delivery)
        {
            try
            {
                Process(delivery);
                Ship(delivery);
                Transit(delivery);
                Deliver(delivery);
            }
            catch (AccidentException ex)
            {
                throw;
                //Console.WriteLine($"Exception happened due to: {ex.Message}");
                //delivery.DeliveryStatus = DeliveryStatus.UNKOWN;
            }
            catch (InvalidAddressException ex)
            {
                throw;
                //Console.WriteLine($"Exception happened due to: {ex.Message}");
                //delivery.DeliveryStatus = DeliveryStatus.UNKOWN;
            }
            catch (Exception ex)
            {
                throw;
                //Console.WriteLine($"Exception happened due to: {ex.Message}");
                //delivery.DeliveryStatus = DeliveryStatus.UNKOWN;
            }
            finally
            {
                Console.WriteLine("End");
            }
        }

        private void Process(Delivery delivery)
        {
            FakeIt("Processing");
            if(random.Next(1,5) == 1)
            {
                throw new InvalidOperationException("unable to process the item");
            }
            delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
        }
        private void Ship (Delivery delivery)
        {
            FakeIt("Shipping");
            if(random.Next(1,5) == 1)
            {
                throw new InvalidOperationException("Parcel is damaged during the loading process");
            }
            delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
        }
        private void Transit (Delivery delivery)
        {
            FakeIt("On Its way");
            if(random.Next(1, 5) == 1)
            {
                throw new AccidentException("Highway 101", "Accident happened on the way");
            }
            delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
        }
        private void Deliver (Delivery delivery)
        {
            FakeIt("Delivering");
            if (random.Next(1, 5) == 1)
            {
                throw new InvalidAddressException($"{delivery.Address}: is invalid");
            }
            delivery.DeliveryStatus = DeliveryStatus.DELIVERDED;
        }
        private void FakeIt(string title)
        {
            Console.Write(title);
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            System.Threading.Thread.Sleep(300);
            Console.Write(".");
            Console.WriteLine("");
        }
    }
}
