namespace Internet
{
    public class ConsoleMessages
    {
        public static void RightPassword(string _name)
        {
            Console.WriteLine();
            Console.WriteLine("Providing access to the user {0}.", _name);
        }

        public static void WrongPassword(string _name)
        {
            Console.WriteLine();
            Console.WriteLine("Denying access to a user {0}.", _name);
            Console.WriteLine("Incorrect password.");
        }

        public static void NoTraffic()
        {
            Console.WriteLine();
            Console.WriteLine("To use the traffic you need to choose a tariff model.");
        }

        public static void NoAccess(string _name)
        {
            Console.WriteLine();
            Console.WriteLine("Denying access to a user {0}.", _name);
            Console.WriteLine("First, enter the password.");
        }

        public static void WrongPayment()
        {
            Console.WriteLine();
            Console.WriteLine("Amount of recharge must be greater than zero.");
        }

    }
}