using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace EFF.PlutoCodeFirstApproach.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseLevel Level { get; set; }
        public float FullPrice { get; set; }
        public Author Author { get; set; }//called navigation property
        public IList<Tag> Tags { get; set; }//many to many relation created.(same have at tag class)
    }
}