// See https://aka.ms/new-console-template for more information
namespace _4._3
{
    class Program
    {
        string[] books = { "book1", "book2", "book3", "book4", "book5" };
        string book_name;
        private Object myLock = new Object();
        public static void Main(String[] args)
        {
            Program p1 = new Program();
            void book_check()
            {

                lock (p1.myLock)
                {
                    Console.WriteLine("Enter book name :");
                    p1.book_name = Console.ReadLine();
                    bool result = p1.books.Contains(p1.book_name);
                    if (result == true) Console.WriteLine("the book is available");
                    else Console.WriteLine("book not available");
                }
            }
            void book_available()
            {
                lock (p1.myLock)
                {
                    for (int i = 0; i < p1.books.Length; i++)
                    {
                        Console.WriteLine("Thread 2 : book list : " + p1.books[i]);
                    }
                }
            }
            void book_new_list()
            {
                lock (p1.myLock)
                {
                    for (int i = 0; i < p1.books.Length; i++)
                    {
                        if (p1.book_name.Contains(p1.books[i])) continue;
                        Console.WriteLine("Thread 3 : after lending : " + p1.books[i]);
                    }
                }
            }
            Thread thread = new Thread(book_check);
            Thread thread1 = new Thread(book_available);
            Thread thread2 = new Thread(book_new_list);
            thread.Start();
            thread1.Start();
            thread2.Start();
            thread.Join();
            thread1.Join();
            thread2.Join();
        }
    }
}

