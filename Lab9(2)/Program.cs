using System;
using System.Collections;
using System.Collections.Generic;

class Document : IComparable<Document>
{
    public string Title { get; set; }
    public int PageCount { get; set; }

    public int CompareTo(Document other)
    {
        return this.PageCount.CompareTo(other.PageCount);
    }

    public override string ToString()
    {
        return $"{Title} ({PageCount} стор.)";
    }
}

class DocumentCollection : IEnumerable<Document>
{
    internal List<Document> documents = new List<Document>();

    public void AddDocument(Document document)
    {
        documents.Add(document);
    }

    public IEnumerator<Document> GetEnumerator()
    {
        documents.Sort();
        return documents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main()
    {
        DocumentCollection documentCollection = new DocumentCollection();

        while (true)
        {
            Console.WriteLine("Введіть інформацію про документ (або 'exit' для завершення):");

            Console.Write("Назва документа: ");
            string title = Console.ReadLine();

            if (title.ToLower() == "exit")
                break;

            Console.Write("Кількість сторінок: ");
            if (!int.TryParse(Console.ReadLine(), out int pageCount))
            {
                Console.WriteLine("Некоректне введення кількості сторінок. Спробуйте ще раз.");
                continue;
            }

            Document document = new Document { Title = title, PageCount = pageCount };
            documentCollection.AddDocument(document);
        }

        Console.WriteLine("\nСписок документів за кількістю сторінок:");
        foreach (Document document in documentCollection)
        {
            Console.WriteLine(document);
        }
    }
}
