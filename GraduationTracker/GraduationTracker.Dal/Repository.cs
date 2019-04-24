using GraduationTracker.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduationTracker.Dal
{
    public class Repository
    {
        public static Student GetStudent(int id)
        {
            return MockDataContext.GetStudents().Where(s => s.Id == id).FirstOrDefault();
        }

        public static Diploma GetDiploma(int id)
        {
            return MockDataContext.GetDiplomas().Where(d => d.Id == id).FirstOrDefault();
        }

        public static Requirement GetRequirement(int id)
        {
            return MockDataContext.GetRequirements().Where(r => r.Id == id).FirstOrDefault();
        }

        public static List<Requirement> GetRequirements(int[] id)
        {
            return MockDataContext.GetRequirements().Where(r => id.Contains(r.Id)).ToList();
        }
    }
}
