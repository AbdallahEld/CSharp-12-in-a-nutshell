namespace CAExceptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            var delivery = new Delivery { Id = 1, CustomerName = "Remando", Address = "123 Street", DeliveryStatus = DeliveryStatus.UNKOWN };
            var service = new DeliveryService();
            try
            {
                service.Start(delivery);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            service.Start(delivery);
            Console.WriteLine(delivery);
        }
    }
}
