namespace ConsoleApp1
{
    public class PhotoBook
    {
        private static List<int> photoBooks = new List<int>();
        public PhotoBook()
        {
            photoBooks.Add(16);
        }
        public PhotoBook(int num)
        {
            photoBooks.Add(num);
        }

        public static int getNumberOfPages()
        {
            return photoBooks.Sum();
        }

        public static List<int> getPhotoAlbum()
        {
            return photoBooks;
        }


    }

    public class AddPhotoBook : PhotoBook
    {
        public AddPhotoBook() : base(64) { }
    }

    public class PhotoBookTest
    {
        static void Main(string[] args)
        {
            // task 1
            PhotoBook obj = new PhotoBook();
            Console.WriteLine(PhotoBook.getNumberOfPages());

            // task 2
            PhotoBook obj2 = new PhotoBook(32);
            Console.WriteLine(PhotoBook.getNumberOfPages());

            // task 3
            AddPhotoBook obj3 = new AddPhotoBook();
            Console.WriteLine(PhotoBook.getNumberOfPages());

            Console.WriteLine("Photo Album");
            List<int> list = PhotoBook.getPhotoAlbum();
            foreach (int i in list)
            {
                Console.WriteLine($"Album with pages: {i}");
            }
        }
    }
}