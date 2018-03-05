using System.Collections.Generic;

namespace Vidzy.FluentAPI.Domain
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public ICollection<Video> Videos { get; set; }
    }
}