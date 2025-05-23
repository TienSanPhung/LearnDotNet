using System.Text;

namespace ReadAndWriteFile.Bai4;

public class ReadWriteByFileSeek
{
    readonly string path;
    public byte[] buffer = new byte[1024] ;
    public ReadWriteByFileSeek(string _path)
    {
        this.path = _path;
    }
    public void ReadAndWrite()
    {
        buffer = Encoding.UTF8.GetBytes("Hắn vừa đi vừa chửi . Bao giờ cũng thế, cứ rượu xong là hắn chửi . Bắt đầu chửi trời . Có hề gì ? Trời\ncó của riêng nhà nào ? Rồi hắn chửi đời . Thế cũng chẳng sao: đời là tất cả nhưng chẳng là ai . Tức mình\nhắn chửi ngay tất cả làng Vũ-đại . Nhưng cả làng Vũ-đại ai cũng nhủ, \"Chắc nó trừ mình ra!\" Không ai\nlên tiếng cả . Tức thật! Ồ! Thế này thì tức thật! Tức chết đi được mất! Ðã thế, hắn phải chửi cha đứa nào\nkhông chửi nhau với hắn. Nhưng cũng không ai ra điều . Mẹ kiếp! Thế thì có phí rượu không? Thế thì có\nkhổ hắn không? Không biết đứa chết mẹ nào đẻ ra thân hắn cho hắn khổ đến nông nỗi này ? A ha! Phải\nđấy, hắn cứ thế mà chửi, hắn cứ chửi đứa chết mẹ nào lại đẻ ra thân hắn, đẻ ra cái thằng Chí Phèo! Hắn\nnghiến răng vào mà chửi cái đứa đã đẻ ra Chí Phèo . Nhưng mà biết đứa nào đã đẻ ra Chí Phèo ? Có trời\nmà biết ! Hắn không biết, cả làng Vũ-đại cũng không ai biết...");
        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            fileStream.Write(buffer,0,520);
        }

        using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            file.Seek(200, SeekOrigin.Begin);
            file.Read(buffer,0,520);
            Console.WriteLine($"---------------------------Bài 4 --------------------");
            Console.WriteLine($"đã đọc {buffer.Length} byte từ file:");
            Console.WriteLine(Encoding.UTF8.GetString(buffer));
        }
    }
}