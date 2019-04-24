using GraduationTracker.Dal;
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
        //In addition, he/she will only get a credit for that course in that requirement of his/her mark on that course is greater than the minimum mark for that requirement.
        //In this case, what is the final "credits" value used for? What happens if the student didn't take that course? Does he get a "0" for that?

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
                        if (studentCourse.Mark > requirement.MinimumMark)
                        {
                            credits += requirement.Credits;
                        }
                    }
                    else
                    {
                        // What happens if the Student didn't take the course?
                    }
                }
            }

            average = average / student.Courses.Length;
            return GetStandingByAverageMark(average);
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
