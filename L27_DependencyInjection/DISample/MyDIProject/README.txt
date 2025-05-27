--------------------- Denpendency injection ----------------
# KHÁI NIỆM
LÀ MỘT KỸ THUẬT "TIÊM" (inject) CÁC PHỤ THUỘC(object mà class khác cần dùng) TỪ BÊN NGOÀI VÀO MỘT CLASS
THAY VÌ ĐỂ CLASS ĐÓ TỰ TẠO PHỤ THUỘC(dependency)

# MỤC ĐÍCH
- tránh phụ thuộc vào một đối tượng cụ thể
mà phụ thuộc vào interface nhằm tạo ra sự lỏng lẻo trong việc sử dụng đối tượng
-> không phụ thuộc vào chi tiết cụ thế (đặc trưng của interface)
-> dễ dang thay đổi, cập nhật và triển khai tính năng mới và triển khai unit test

# CÁC THÀNH PHẦN CỦA DI
nguyên lý hoạt động:
-> đăng ký các đối tượng, hàm khởi tạo object vào ServiceCollection
-> build một ServiceProvider từ ServiceCollection đó
-> ServiecProvider sẽ dựa vào các hàm khởi tạo có trong ServiceCollection để lấy ra các
object mà ta cần.

thành phần:
- ServiceCollection: chứa các hàm khởi tạo các class sẽ tiêm
- ServiceProvider: chịu trách nhiệm lựa chọn và khởi tạo các class mà ta cần
- Contructor Injection: một cách nữa để sử dụng dependency -> ta có thể xin cấp phát các object khác thông
qua contructor của đối tượng -> .net sẽ tự động tạo ra các object cần thiết đó.

sử dụng: 
-> có 3 phương thức thêm các interface và implementation của nó theo các chu kỳ vòng đời của object
-> AddTransient: tạo mới mỗi khi được yêu cầu
-> AddSingleton: 1 phiên bản duy  nhất cho toàn bộ ứng dụng
-> AddScoped: 1 phiên bản duy nhất trong một phạm vi