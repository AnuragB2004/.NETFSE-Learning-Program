using System;

namespace FactoryMethodDemo
{
    // Abstract Document
    public abstract class Document
    {
        public abstract void Open();
        public abstract void Save();
        public abstract void Close();
    }

    // Concrete Documents
    public class WordDocument : Document
    {
        public override void Open() => Console.WriteLine("Opening Word document...");
        public override void Save() => Console.WriteLine("Saving Word document...");
        public override void Close() => Console.WriteLine("Closing Word document...");
    }

    public class PdfDocument : Document
    {
        public override void Open() => Console.WriteLine("Opening PDF document...");
        public override void Save() => Console.WriteLine("Saving PDF document...");
        public override void Close() => Console.WriteLine("Closing PDF document...");
    }

    public class ExcelDocument : Document
    {
        public override void Open() => Console.WriteLine("Opening Excel document...");
        public override void Save() => Console.WriteLine("Saving Excel document...");
        public override void Close() => Console.WriteLine("Closing Excel document...");
    }

    // Abstract Factory
    public abstract class DocumentFactory
    {
        public abstract Document CreateDocument();
    }

    // Concrete Factories
    public class WordDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument() => new WordDocument();
    }

    public class PdfDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument() => new PdfDocument();
    }

    public class ExcelDocumentFactory : DocumentFactory
    {
        public override Document CreateDocument() => new ExcelDocument();
    }
}