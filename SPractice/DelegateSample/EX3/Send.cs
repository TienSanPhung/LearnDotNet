namespace DelegateSample.EX3;

public class Send
{
    public static async Task SendPlugin(string data)
    {
        using var client = new HttpClient();
        // Giả lập gửi HTTP POST
        // tìm Uri khỉ ho cò gáy nào mà dùng nhé
        await client.PostAsync("https://httpbin.org/post", new StringContent(data));
        Console.WriteLine("[SEND] Đã gửi dữ liệu tới server");
    }
}