using System;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var q1 = LibraryData.Books.Where(b => b.IsAvailable);

            var q2 = LibraryData.Books.Select(b => b.Title);
            var q3 = LibraryData.Books.Where(b => b.Genre == "Programming");
            var q4 = LibraryData.Books.OrderBy(b => b.Title);
            var q5 = LibraryData.Books.Where(b => b.Price > 30);
            var q6 = LibraryData.Books.Select(b => b.Genre).Distinct();
            var q7 = LibraryData.Books.GroupBy(b => b.Genre).Select(g => new { g.Key, Count = g.Count() });
            var q8 = LibraryData.Books.Where(b => b.PublishedYear > 2010);
            var q9 = LibraryData.Books.Take(5);
            var q10 = LibraryData.Books.Any(b => b.Price > 50);
            var q11 = LibraryData.Books.Join(LibraryData.Authors, b => b.AuthorId, a => a.Id, (b, a) => new { b.Title, a.Name, b.Genre });
            var q12 = LibraryData.Books.GroupBy(b => b.Genre).Select(g => new { g.Key, Avg = g.Average(b => (double)b.Price) });
            var q13 = LibraryData.Books.OrderByDescending(b => b.Price).FirstOrDefault();
            var q14 = LibraryData.Books.GroupBy(b => (b.PublishedYear / 10) * 10).Select(g => new { Decade = g.Key, Books = g.ToList() });
            var q15 = LibraryData.Loans.Where(l => l.ReturnDate == null).Join(LibraryData.Members, l => l.MemberId, m => m.Id, (l, m) => m).Distinct();
            var q16 = LibraryData.Loans.GroupBy(l => l.BookId).Where(g => g.Count() > 1).Join(LibraryData.Books, g => g.Key, b => b.Id, (g, b) => new { b.Title, Count = g.Count() });
            var q17 = LibraryData.Loans.Where(l => l.DueDate < DateTime.Now && l.ReturnDate == null).Join(LibraryData.Books, l => l.BookId, b => b.Id, (l, b) => b);
            var q18 = LibraryData.Books.GroupBy(b => b.AuthorId).Join(LibraryData.Authors, g => g.Key, a => a.Id, (g, a) => new { a.Name, Count = g.Count() }).OrderByDescending(x => x.Count);
            var q19 = LibraryData.Books.GroupBy(b => b.Price < 20 ? "Cheap" : b.Price <= 40 ? "Medium" : "Expensive").Select(g => new { Range = g.Key, Count = g.Count() });
//========================================================================================================================================================================================================

            //      امثله ع الاوت بوت

            foreach (var b in q1)
            {
                Console.WriteLine(b.Title);
            }


            foreach (var x in q11)
            {
                Console.WriteLine($"{x.Title} - {x.Name} - {x.Genre}");
            }
           

        }
    }
}

