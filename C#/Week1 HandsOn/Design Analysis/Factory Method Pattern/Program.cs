using System;

namespace FactoryMethodDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Factory Method Pattern Demo ===\n");

            // Test all document types
            TestDocument(new WordDocumentFactory(), "Word");
            TestDocument(new PdfDocumentFactory(), "PDF");
            TestDocument(new ExcelDocumentFactory(), "Excel");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void TestDocument(DocumentFactory factory, string type)
        {
            Console.WriteLine($"--- {type} Document ---");
            Document doc = factory.CreateDocument();
            doc.Open();
            doc.Save();
            doc.Close();
            Console.WriteLine();
        }
    }
}