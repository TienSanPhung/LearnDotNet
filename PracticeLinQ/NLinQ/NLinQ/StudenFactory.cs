namespace NLinQ;

public class StudenFactory
{
    public static List<Student> CreateStudentIstance()
    {
        var students = new List<Student>
        {
            new Student{ Id = 1, Name = "Anh",   Score = 8.5 },
            new Student{ Id = 2, Name = "Bình",  Score = 7.2 },
            new Student{ Id = 3, Name = "Châu",  Score = 9.3 },
            new Student{ Id = 4, Name = "Diệp",  Score = 6.8 },
            new Student{ Id = 5, Name = "Hằng",  Score = 8.0 },
            new Student{ Id = 9, Name = "Én",  Score = 8.0 },
            new Student{ Id = 8, Name = "Trinh",  Score = 8.0 },
            new Student{ Id = 6, Name = "Khôi",  Score = 9.3 },
            new Student{ Id = 7, Name = "Lan",   Score = 7.7 },
        };
        return students;
    }
}