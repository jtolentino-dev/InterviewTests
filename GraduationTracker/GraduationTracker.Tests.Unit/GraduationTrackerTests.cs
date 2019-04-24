using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using GraduationTracker.Dal.Models;
using GraduationTracker.Dal.Enums;
using System.Collections;

namespace GraduationTracker.Tests.Unit
{
    [TestClass]
    public class GraduationTrackerTests
    {
        [TestMethod]
        public void TestHasCredits()
        {
            var tracker = new GraduationTracker();
            Diploma diploma = GetDiplomaTestData();
            Student[] students = GetStudentTestData();

            var graduated = new List<Student>();

            foreach (var student in students)
            {
                if (tracker.HasGraduated(diploma, student).Item1)
                {
                    graduated.Add(student);
                }

            }
            var expectedGraduated = new int[] { 1, 2, 3 };
            CollectionAssert.AreEquivalent(
                graduated.Select(g => g.Id).ToArray(),
                expectedGraduated);
        }

        private static Student[] GetStudentTestData()
        {
            return new[]
                        {
                new Student
                {
                    Id = 1,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=95 },
                        new Course{Id = 2, Name = "Science", Mark=95 },
                        new Course{Id = 3, Name = "Literature", Mark=95 },
                        new Course{Id = 4, Name = "Physical Education", Mark=95 }
                    }
                },
                new Student
                {
                    Id = 2,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=80 },
                        new Course{Id = 2, Name = "Science", Mark=80 },
                        new Course{Id = 3, Name = "Literature", Mark=80 },
                        new Course{Id = 4, Name = "Physical Education", Mark=80 }
                    }
                },
                new Student
                {
                    Id = 3,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=50 },
                        new Course{Id = 2, Name = "Science", Mark=50 },
                        new Course{Id = 3, Name = "Literature", Mark=50 },
                        new Course{Id = 4, Name = "Physical Education", Mark=50 }
                    }
                },
                new Student
                {
                    Id = 4,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=40 },
                        new Course{Id = 2, Name = "Science", Mark=40 },
                        new Course{Id = 3, Name = "Literature", Mark=40 },
                        new Course{Id = 4, Name = "Physical Education", Mark=40 }
                    }
                },
                new Student
                {
                    Id = 5,
                    Courses = new Course[]
                    {
                        new Course{Id = 1, Name = "Math", Mark=0 },
                        new Course{Id = 2, Name = "Science", Mark=0 },
                        new Course{Id = 3, Name = "Literature", Mark=99 },
                        new Course{Id = 4, Name = "Physical Education", Mark=99 }
                    }
                },
                new Student
                {
                    Id = 6,
                    Courses = new Course[]
                    {
                        new Course{Id = 2, Name = "Science", Mark=0 },
                        new Course{Id = 3, Name = "Literature", Mark=99 },
                        new Course{Id = 4, Name = "Physical Education", Mark=99 }
                    }
                }
            };
        }

        private static Diploma GetDiplomaTestData()
        {
            return new Diploma
            {
                Id = 1,
                Credits = 4,
                Requirements = new int[] { 100, 102, 103, 104 }
            };
        }
    }
}
