namespace Domain;
public class Student : IEquatable<Student>
{
    private readonly string _name;
    private readonly string _surname;
    private readonly string _patronymic;
    private readonly string _studyGroup;
    private readonly string _practiceCourse;
    
    public Student(string name, string surname, string patronymic, string studyGroup, string practiceCourse)
    {
        _name = name ?? throw new ArgumentNullException(nameof(name));
        _surname = surname ?? throw new ArgumentNullException(nameof(surname));
        _patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
        _studyGroup = studyGroup ?? throw new ArgumentNullException(nameof(studyGroup));
        _practiceCourse = practiceCourse ?? throw new ArgumentNullException(nameof(practiceCourse));
    }

    public void PrintFullData()
    {
        Console.WriteLine($"Name: {_name}\nSurname: {_surname}\nPatronymic: {_patronymic}\nStudy Group: {_studyGroup}\nPractice course: {_practiceCourse}\n");
    }

    public string GetName => _name;

    public string GetSurname => _surname;

    public string GetPatronymic => _patronymic;

    public string GetStudyGroup => _studyGroup;

    public string GetPracticecourse => _practiceCourse;

    public int GetCourseFromGroup => _studyGroup[4] - '0';
    
    public bool Equals(
        Student? obj)
    {
        if (obj == null) { return false; }

        return _surname.Equals(obj._surname) &&
               _name.Equals(obj._name) &&
               _patronymic.Equals(obj._patronymic) &&
               _studyGroup.Equals(obj._studyGroup) &&
               _practiceCourse.Equals(obj._practiceCourse);
    }
    
    public override bool Equals(
        object? obj)
    {
        if (obj == null) { return false; }

        if (obj is Student student)
        {
            return _surname.Equals(student._surname) && 
                   _name.Equals(student._name) &&
                   _patronymic.Equals(student._patronymic) &&
                   _studyGroup.Equals(student._studyGroup) &&
                   _practiceCourse.Equals(student._practiceCourse);
        }

        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(_surname, _name, _patronymic, _studyGroup, _practiceCourse);
    }
    
}