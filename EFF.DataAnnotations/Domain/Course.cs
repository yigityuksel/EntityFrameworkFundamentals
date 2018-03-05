﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.DataAnnotations.Domain
{
    public class Course
    {
        public Course()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Description { get; set; }
        public int Level { get; set; }
        public float FullPrice { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual Author Author { get; set; }

        //[ForeignKey(nameof(AuthorId))] -------- either this or Author's
        public int AuthorId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
