using System.Text;

namespace NLinQ;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var students = StudenFactory.CreateStudentIstance();
        // Lọc ra những sinh viên có Score >= 8.0.
        var studentScoreQ1 = from st in students
            where st.Score >= 8 select st;
        PrintStudent(studentScoreQ1);
        var studentScoreM1 = students.Where(s => s.Score >= 8);
        PrintStudent(studentScoreM1);
        
        //    Sắp xếp kết quả theo Score giảm dần, nếu bằng điểm thì theo Name tăng dần.
        var studentScoreQ2 = from st in students
            orderby st.Score descending, st.Name ascending select st;
        PrintStudent(studentScoreQ2);
        var studentScoreM2 = students.OrderByDescending(s => s.Score).ThenBy(s => s.Name);
        PrintStudent(studentScoreM2);
        //    Lấy 5 bản ghi đầu tiên (top 5).
        var studentScoreQ3 = (from st in students
             select st).Take(5);
        PrintStudent(studentScoreQ3);
        var studentScoreM3 = students.Take(5);
        PrintStudent(studentScoreM3);
        
    }

    public static void PrintStudent(IEnumerable<Student> students)
    {
        Console.WriteLine("-------Student List-------");
        foreach (var student in students)
        {
            Console.WriteLine($"id: {student.Id}, name: {student.Name}, score: {student.Score}");
        }
    }
}