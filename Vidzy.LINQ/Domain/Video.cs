using System;
using System.Collections.Generic;

namespace Vidzy.LINQ.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public virtual Genre Genre { get; set; }/*lazy loading enabled*/
        public virtual byte GenreId { get; set; }/*lazy loading enabled*/
        public Classification Classification { get; set; }
        public ICollection<Tag> Tags { get; private set; }

        public Video()
        {
            Tags = new HashSet<Tag>();
        }
    }
}