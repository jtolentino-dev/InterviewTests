﻿namespace GraduationTracker.Dal.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }
        public int Credits { get; }
     }
}
