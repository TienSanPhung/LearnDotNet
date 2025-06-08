# Bạn được yêu cầu xây dựng một blog cá nhân nơi bạn có thể viết và xuất bản bài viết.
 Blog sẽ có hai phần: phần khách và phần quản trị.

Phần dành cho khách — Danh sách các trang mà bất kỳ ai cũng có thể truy cập:

Trang chủ: Trang này sẽ hiển thị danh sách các bài viết đã đăng trên blog.
Trang bài viết: Trang này sẽ hiển thị nội dung của bài viết cùng với ngày xuất bản.
Phần quản trị — là những trang mà chỉ bạn mới có thể truy cập để đăng, chỉnh sửa hoặc xóa bài viết.

-> Bảng điều khiển: Trang này sẽ hiển thị danh sách các bài viết đã đăng trên blog cùng với tùy chọn thêm bài viết mới, 
chỉnh sửa bài viết hiện có hoặc xóa bài viết.
-> Trang Thêm Bài Viết: Trang này sẽ chứa một biểu mẫu để thêm bài viết mới. Biểu mẫu sẽ có các trường như tiêu đề, 
nội dung và ngày xuất bản.
-> Trang chỉnh sửa bài viết: Trang này sẽ chứa một biểu mẫu để chỉnh sửa bài viết hiện có. Biểu mẫu sẽ có các 
trường như tiêu đề, nội dung và ngày xuất bản.
-> Sau đây là các bản mẫu để bạn có thể hình dung về các trang khác nhau của blog.

# Cách thực hiện
Sau đây là một số hướng dẫn giúp bạn triển khai blog cá nhân:

* Kho
Để đơn giản hóa mọi thứ, bạn có thể sử dụng hệ thống tệp để lưu trữ các bài viết. 
Mỗi bài viết sẽ được lưu trữ dưới dạng tệp riêng trong một thư mục. Tệp sẽ chứa tiêu đề,
 nội dung và ngày xuất bản của bài viết. Bạn có thể sử dụng định dạng JSON hoặc Markdown để lưu trữ các bài viết.

* Phần sau
Bạn có thể sử dụng bất kỳ ngôn ngữ lập trình nào để xây dựng phần phụ trợ của blog. Bạn không cần phải biến nó 
thành API cho dự án này, chúng tôi có các dự án khác cho mục đích đó. Bạn có thể có các trang hiển thị HTML 
trực tiếp từ máy chủ và các biểu mẫu gửi dữ liệu đến máy chủ.

* Giao diện
Đối với frontend, bạn có thể sử dụng HTML và CSS (hiện tại không cần JavaScript). Bạn có thể sử dụng 
bất kỳ công cụ tạo mẫu nào để hiển thị các bài viết trên frontend.

* Xác thực
Bạn có thể triển khai xác thực cơ bản cho phần quản trị. Bạn có thể sử dụng xác thực cơ bản HTTP 
chuẩn hoặc chỉ cần mã hóa cứng tên người dùng và mật khẩu trong mã ngay bây giờ và tạo một trang 
đăng nhập đơn giản sẽ tạo phiên cho quản trị viên.