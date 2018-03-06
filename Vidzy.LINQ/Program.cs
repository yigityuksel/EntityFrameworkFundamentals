using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vidzy.LINQ.Context;
using Vidzy.LINQ.Domain;

namespace Vidzy.LINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new VidzyContext();

            //var list1 = context.Videos.Where(v => v.Genre.Name.Equals("Action")).OrderBy(v => v.Name);

            //foreach (var video in list1)
            //    Console.WriteLine(video.Name);

            //Console.WriteLine("-----------------------------------------------");

            //var list2 = context.Videos
            //    .Where(v => v.Classification == Classification.Gold && v.Genre.Name.Equals("Drama"))
            //    .OrderByDescending(v => v.ReleaseDate);

            //foreach (var video in list2)
            //    Console.WriteLine(video.Name);

            //Console.WriteLine("-----------------------------------------------");

            //var list3 = context.Videos.Select(v => new
            //{
            //    MovieName = v.Name,
            //    Genre = v.Genre.Name
            //});

            //foreach (var video in list3)
            //    Console.WriteLine(video.MovieName);

            //Console.WriteLine("-----------------------------------------------");

            //var list4 = context.Videos.GroupBy(v => v.Classification).Select(v => new
            //{
            //    ClassName = "Classification : " + v.Key,
            //    MovieList = v.OrderBy(a => a.Name).ToList()
            //});

            //foreach (var classfi in list4)
            //{
            //    Console.WriteLine($@"{classfi.ClassName}");
            //    foreach (var video in classfi.MovieList)
            //    {
            //        Console.WriteLine($@"{video.Name}");
            //    }
            //}

            //Console.WriteLine("-----------------------------------------------");

            //var list5 = context.Videos.GroupBy(v => v.Classification).Select(v => new
            //{
            //    KeyName = v.Key,
            //    Count = v.Count()
            //}).OrderBy(a => a.KeyName.ToString());

            //foreach (var video in list5)
            //    Console.WriteLine($@"{video.KeyName}" + "(" + $@"{video.Count}" + @")");

            //Console.WriteLine("-----------------------------------------------");

            //var list6 = context.Genres.GroupJoin(context.Videos, g => g.Id, v => v.GenreId, (genre, videos) => new
            //{
            //    ClassName = genre.Name,
            //    Count = videos.Count(),
            //}).OrderByDescending(a => a.Count);

            //foreach (var video in list6)
            //    Console.WriteLine($@"{video.ClassName}" + "(" + $@"{video.Count}" + @")");

            Console.WriteLine("-----------------------------------------------");

            var videos = context.Videos.ToList();

            Console.WriteLine();
            Console.WriteLine("LAZY LOADING");
            foreach (var v in videos)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);

            // Eager loading
            var videosWithGenres = context.Videos.Include(v => v.Genre).ToList();

            Console.WriteLine();
            Console.WriteLine("EAGER LOADING");
            foreach (var v in videosWithGenres)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);

            // Explicit loading

            // NOTE: At this point, genres are already loaded into the context,
            // so the following line is not going to make a difference. If you 
            // want to see expicit loading in action, comment out the eager loading 
            // part as well as the foreach block in the lazy loading.
            context.Genres.Load();

            Console.WriteLine();
            Console.WriteLine("EXPLICIT LOADING");
            foreach (var v in videos)
                Console.WriteLine("{0} ({1})", v.Name, v.Genre.Name);


        }
    }
}
