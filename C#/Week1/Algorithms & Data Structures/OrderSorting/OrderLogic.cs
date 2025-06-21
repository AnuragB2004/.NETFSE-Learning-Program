namespace OrderSorting
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalPrice { get; set; }

        public Order(int id, string name, decimal price)
        {
            OrderId = id;
            CustomerName = name;
            TotalPrice = price;
        }

        public override string ToString()
        {
            return $"Order {OrderId}: {CustomerName} - ${TotalPrice}";
        }
    }

    public class OrderSorter
    {
        // Bubble Sort: O(n²)
        public static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            int swaps = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (orders[j].TotalPrice > orders[j + 1].TotalPrice)
                    {
                        // Swap
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Bubble Sort completed with {swaps} swaps");
        }

        // Quick Sort: O(n log n)
        public static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(orders, low, high);
                QuickSort(orders, low, pi - 1);
                QuickSort(orders, pi + 1, high);
            }
        }

        private static int Partition(Order[] orders, int low, int high)
        {
            decimal pivot = orders[high].TotalPrice;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (orders[j].TotalPrice <= pivot)
                {
                    i++;
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            Order temp2 = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = temp2;

            return i + 1;
        }
    }
}
