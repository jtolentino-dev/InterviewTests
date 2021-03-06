﻿using GraduationTracker.Dal;
using GraduationTracker.Dal.Enums;
using GraduationTracker.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
        //Please verify my understanding of the requirements:
        //In order for a student to get a Diploma, he/she should get a combined average mark of 80 or above in all of the courses in all of the requirements of the diploma.
        //In addition, he/she will only get a credit for that course in that requirement of his/her mark on that course is GREATER THAN OR EQUAL TO (verify!) the minimum mark for that requirement.
        //Assumption: student also doesn't graduate if he/she doesn't meet the required credits.

        public Tuple<bool, Standing> HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            var average = 0;

            var requirements = Repository.GetRequirements(diploma.Requirements);

            foreach (Requirement requirement in requirements)
            {
                foreach (int courseId in requirement.Courses)
                {
                    Course studentCourse = student.Courses.Where(c => c.Id == courseId).FirstOrDefault();

                    if (studentCourse != null)
                    {
                        average += studentCourse.Mark;
                        //changed condition to greater than or equal
                        if (studentCourse.Mark >= requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }
                }
            }

            //Added credits check
            if (credits >= diploma.Credits)
            {
                average = average / student.Courses.Length;
                return GetStandingByAverageMark(average);
            }
            else
            {
                return new Tuple<bool, Standing>(false, Standing.None);
            }
        }

        private static Tuple<bool, Standing> GetStandingByAverageMark(int average)
        {
            Tuple<bool, Standing> standing = null;

            switch (average)
            {
                case int ave when (ave < 50):
                    standing = new Tuple<bool, Standing>(false, Standing.Remedial);
                    break;
                case int ave when (ave < 80):
                    standing = new Tuple<bool, Standing>(true, Standing.Average);
                    break;
                case int ave when (ave < 95):
                    standing = new Tuple<bool, Standing>(true, Standing.MagnaCumLaude);
                    break;
                default:
                    standing = new Tuple<bool, Standing>(true, Standing.SumaCumLaude);
                    break;
            }

            return standing;
        }
    }
}
