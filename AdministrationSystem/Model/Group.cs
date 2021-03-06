﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrationSystem
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [HideColumn]
        public ICollection<Student> Students { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
