﻿using GraduationTracker.Dal.Enums;

namespace GraduationTracker.Dal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public Course[] Courses { get; set; }
        public Standing Standing { get; set; } = Standing.None;
    }
}
