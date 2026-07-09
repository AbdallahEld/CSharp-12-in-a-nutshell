namespace CAExceptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            var delivery = new Delivery { Id = 1, CustomerName = "Remando", Address = "123 Street", DeliveryStatus = DeliveryStatus.UNKOWN };
            var service = new DeliveryService();
            service.Start(delivery);
            Console.WriteLine(delivery);
        }
    }
}
