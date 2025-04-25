namespace StaticSample;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(AccessCounter.GetInstance().Inc());
        }
        
        Person person = new Person(){Id = 999,Name = "San"};
        person.Print();
        
        
       //  var c1 = new C(){Y=111};
       //  var c2 = new C(){Y=122};
       //  // biến Y không phà là biến static, do đó nó gắn liền với đối tượng c1, c2
       //  // nghĩa là mỗi đối tượng c1 sẽ có một biến Y riêng, được cấp phát bộ nhớ cùng với c1
       //  // và c2 sẽ có một biến Y riêng, được cấp phát bộ nhớ cùng với c2
       //  Console.WriteLine(c1.Y);
       //  Console.WriteLine(c2.Y);
       //  // khi thay đổi giá trị biến Y của c2 thì chỉ biến Y trong c2 thay đổi => tách biệt 
       //  c2.Y = 333;
       //  Console.WriteLine(c2.Y);
       //  // biến X là biến static, nó gắn liền với lớp C, do đó nó chỉ có một biến X duy nhất
       //  // nghĩa là tất cả các đối tượng c1, c2 đều dùng chung một biến X(có thể thay thế bằng phương thức)
       //  Console.WriteLine(C.X);
       //  // khi thay đổi giá trị biến X của c2 thì biến X trong c1 cũng thay đổi => không tách biệt
       // // c2.X = 222; sẽ lỗi, vì X gắn với kiểu lớp C, chứ không phải với đối tượng c1,c2(là trường hợp(thể hiện) của C)
       //  C.X = 222;
       //  Console.WriteLine(C.X);
       //  
       //  D();
       //  // vì nó gắn với lớp C, mà lớp C  được coi là một kiểu dữ liệu, nó tồn tại suốt vòng đời chương trình
       //  // do đó mà sử dụng nó thì không cần phải khởi tạo,
       //  // do nó đã được tạo cùng với lớp C(được tạo lúc chạy chương trình)
       //  Console.WriteLine(C.X);
        
    }

    public static void D()
    {
        C.X = 444;
    }
}