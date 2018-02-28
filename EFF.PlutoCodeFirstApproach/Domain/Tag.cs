using System.Collections;
using System.Collections.Generic;

namespace EFF.PlutoCodeFirstApproach.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Course> Courses { get; set; }
    }
}