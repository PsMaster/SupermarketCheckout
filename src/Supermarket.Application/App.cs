using Supermarket.Core.Interfaces;

namespace CartCalculator
{
    public class App
    {
        private readonly ICheckout _checkout;

        public App(ICheckout checkout)
        {
            _checkout = checkout;
        }
        public void Run()
        {
            Console.WriteLine("Welcome to checkout service, please scan an item.");
            Console.WriteLine("Input product A, B, C or D to scan, total price will be displayed after input.");
            Console.WriteLine("Type 'checkout' to end checkout process.");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.Equals(input, "exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                switch (input)
                {
                    case "A":
                        {
                            _checkout.Scan("A");
                            Console.WriteLine(_checkout.GetTotalPrice());
                            break;
                        }
                    case "B":
                        {
                            _checkout.Scan("B");
                            Console.WriteLine(_checkout.GetTotalPrice());
                            break;
                        }
                    case "C":
                        {
                            _checkout.Scan("C");
                            Console.WriteLine(_checkout.GetTotalPrice());
                            break;
                        }
                    case "D":
                        {
                            _checkout.Scan("D");
                            Console.WriteLine(_checkout.GetTotalPrice());
                            break;
                        }
                    case "checkout":
                        {
                            _checkout.Checkout();
                            Console.WriteLine("Thank you for shopping.");
                            Console.WriteLine("Scan an item");
                            break;
                        }
                }
            }
        }
    }
}
