using Domain;

namespace Launcher.App
{
    class Program
    {
        static void Main()
        {
            var obj = new Student("Daniil", "Morozov", "Pavlovich", "M8О-213Б-21", "C#");
            
            obj.PrintFullData();

            var patronymic = obj.GetPatronymic;

            var getcoursefromgroup = obj.GetCourseFromGroup;

            var flag = patronymic.Equals(patronymic);

            var hashcode = obj.GetHashCode();
            
            Console.WriteLine($"{patronymic} {getcoursefromgroup} {flag} {hashcode}");
        }
    }
}