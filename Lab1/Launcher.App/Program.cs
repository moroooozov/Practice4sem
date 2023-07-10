using Domain;

namespace Launcher.App
{
    class Program
    {
        static void Main()
        {
            var obj = new Student("Daniil", "Morozov", "Pavlovich", "M8О-213Б-21", "C#");
            
            obj.PrintFullData();

            var course = obj.GetCourseFromGroup();

            var flag = course.Equals(course);
            
            Console.WriteLine($"{course} {flag}");
        }
    }
}