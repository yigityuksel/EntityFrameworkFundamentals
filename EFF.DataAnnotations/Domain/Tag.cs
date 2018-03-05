using System.Collections.Generic;

namespace EFF.DataAnnotations.Domain
{
    public class Tag
    {
        public Tag()
        {
            Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Course> Courses  { get; set; }
    }
}