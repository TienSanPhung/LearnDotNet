
=>> một số lưu ý về interface
-> các dùng: ta nên chia nhỏ các interface sao cho nó có các chức năng tương tự hay cùng loại để đảm bảo tính linh hoạt
mà nó cung cấp

=> lý thuyết
- interface được coi là 1 bản hợp đồng hay một tiêu chuẩn có chứa các phương thức và thuộc tính mà 1 lớp cần hỗ trợ
- inteface cung cấp tính trừu tượng phân tách giữa đối tượng cụ thể và cách chúng thực thi logic
tất cả các lớp triển khai interface đều có chung cách tương tác với thế giới bên ngoài
=> nghĩa là ta sẽ sử dụng các chức năng định nghĩa trong interface ở chỗ cần và cung cấp cho nơi sử dụng đó một đối tượng 
cụ thể có triển khai các logic cụ thể mà interface yêu cầu, điều này làm cho nơi sử dụng không cần quan tâm đến logic
mà chỉ cần sử dụng chức năng -> có thể thay đổi đối tượng khác có logic triển khai khác -> không bị phụ thuộc
-> do nơi sử dụng không biết nơi triển khai thực hiện logic gì nên nó khó hình dung -> đó chính là tính trừu tượng

- làm việc với interface thay vì lớp cụ thể giúp dễ dang thay đổi lớp triển khai => giảm sự phụ thuộc
- khác biệt giữa abstract class: abstract class tạo ra với mục đích trở thành một lớp cha trong cây kế thừa, 
giống như việc phân loại, nhiều lớp có nhều đặc điểm, hành vi gống nhau nên có thể xếp chúng nó vào làm một loại,
nhưng vì các đặc điểm đó nó khác nhau về mặt giá trị, hay các hành vi đó khác nhau về mặt logic nên lớp cha tạo ra để
bao phủ chúng cũng chỉ định nghĩa nên đặc điểm và hành vi chung của chúng -> đây là tính trừu tượng
-> và đặc biệt vì là lớp => nó một lớp con chỉ có thể kế thừa từ một lớp cha => không thể linh hoạt về mặt sử dụng nhiều
tiêu chuẩn, mà chỉ gom nhóm lại được các đối tượng. Điều này rất hữu ích khi các lớp con cần chia sẻ một phần logic 
chung nhưng cũng có thể tùy chỉnh một phần khác.
- interface thì ngược lại

==> nhỡ quên thì: Tính trừu tượng là quá trình ẩn đi các chi tiết triển khai bên trong của một đối tượng, 
chỉ hiển thị những gì cần thiết ra bên ngoài. Nói cách khác, người dùng chỉ cần biết có thể thực hiện những gì (what), 
còn việc thực hiện ra sao thì không cần quan tâm (how).
=> tập trung vào những khía cạnh quan trọng của đối tượng, đồng thời ẩn đi các chi tiết không cần thiết
