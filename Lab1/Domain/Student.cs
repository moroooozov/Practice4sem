namespace Domain;
public class Student:
    IEquatable<Student>,
    IEquatable<object>
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

    public string GetName()
    {
        return _name;
    }

    public string GetSurame()
    {
        return _surname;
    }
    
    public string GetPatronymic()
    {
        return _patronymic;
    }
    
    public string GetStudyGroup()
    {
        return _studyGroup;
    }
    
    public string GetPracticecourse()
    {
        return _practiceCourse;
    }

    public string GetCourseFromGroup()
    {
        return _studyGroup.Substring(4, 1);
    }

    public int IntValue
    {
        get;
    }
    
    public int StringValue
    {
        get;
    }

    public override string ToString()
    {
        return $"[ StringValue: {StringValue}, IntValue: {IntValue} ]";
    }
    
    public override int GetHashCode()
    {
        return StringValue.GetHashCode() * 23 + IntValue.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        Console.WriteLine("object.Equals called");
        
        if (obj == null)
        {
            return false;
        }

        if (obj is Student student)
        {
            return Equals(student);
        }
        if (obj is string @string)
        {
            return Equals(@string);
        }

        if (obj is int @int)
        {
            return Equals(@int);
        }

        return false;
    }

    public bool Equals(Student? obj)
    {
        if (obj == null)
        {
            return false;
        }
        
        return IntValue == obj.IntValue
               && StringValue.Equals(obj.StringValue);
    }

    bool IEquatable<object>.Equals(object? obj)
    {
        Console.WriteLine("IEquatable<object>.Equals called");
        
        if (obj == null)
        {
            return false;
        }

        if (obj is Student student)
        {
            return Equals(student);
        }
        if (obj is string @string)
        {
            return Equals(@string);
        }

        if (obj is int @int)
        {
            return Equals(@int);
        }

        return false;
    }
    
}