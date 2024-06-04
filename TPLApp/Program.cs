using System.Diagnostics;
using System.Drawing;

namespace TPLApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string picturesPath = @"D:\CodeAcademy\images";
            var files=Directory.GetFiles(picturesPath);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();  
            Parallel.ForEach(files, file =>
            {
                Console.WriteLine($"Current Thread {Thread.CurrentThread.ManagedThreadId}");
                Image image = new Bitmap(file);
                var thumbnail=image.GetThumbnailImage(50,50,()=>false,IntPtr.Zero);
                thumbnail.Save(Path.Combine(picturesPath, "Thumbnail", Path.GetFileName(file)));
            });
            stopwatch.Stop();
           
            Console.WriteLine($"Paralel Islem bitdi :{stopwatch.ElapsedMilliseconds}");

            stopwatch.Restart();

            stopwatch.Start();
            foreach (var item in files)
            {
                Console.WriteLine($"Current Thread {Thread.CurrentThread.ManagedThreadId}");
                Image image = new Bitmap(item);
                var thumbnail = image.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                thumbnail.Save(Path.Combine(picturesPath, "Thumbnail2", Path.GetFileName(item)));
            }
            stopwatch.Stop();

            Console.WriteLine($"Adi Islem bitdi :{stopwatch.ElapsedMilliseconds}");
        }
    }
}