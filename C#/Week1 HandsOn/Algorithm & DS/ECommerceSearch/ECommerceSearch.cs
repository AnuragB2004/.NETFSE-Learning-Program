namespace ECommerceSearch
{
    public class SearchableProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public SearchableProduct(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    public class SearchEngine
    {
        private SearchableProduct[] products;
        private SearchableProduct[] sortedProducts;

        public SearchEngine(SearchableProduct[] products)
        {
            this.products = products;
            this.sortedProducts = products.OrderBy(p => p.ProductName).ToArray();
        }

        public SearchableProduct LinearSearch(string productName)
        {
            int comparisons = 0;
            foreach (var product in products)
            {
                comparisons++;
                if (product.ProductName.Equals(productName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Linear Search: Found after {comparisons} comparisons");
                    return product;
                }
            }
            Console.WriteLine($"Linear Search: Not found after {comparisons} comparisons");
            return null;
        }

        public SearchableProduct BinarySearch(string productName)
        {
            int left = 0, right = sortedProducts.Length - 1;
            int comparisons = 0;

            while (left <= right)
            {
                comparisons++;
                int mid = left + (right - left) / 2;
                int comparison = string.Compare(sortedProducts[mid].ProductName, productName, StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                {
                    Console.WriteLine($"Binary Search: Found after {comparisons} comparisons");
                    return sortedProducts[mid];
                }
                else if (comparison < 0)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            Console.WriteLine($"Binary Search: Not found after {comparisons} comparisons");
            return null;
        }
    }
}
