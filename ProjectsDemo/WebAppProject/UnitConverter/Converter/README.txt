Bạn được yêu cầu xây dựng một ứng dụng web đơn giản có thể chuyển đổi giữa các đơn vị đo lường khác nhau. 
Nó có thể chuyển đổi các đơn vị chiều dài, trọng lượng, thể tích, diện tích, nhiệt độ, v.v. Người dùng có thể nhập
 giá trị và chọn đơn vị để chuyển đổi từ và sang. Sau đó, ứng dụng sẽ hiển thị giá trị đã chuyển đổi.

# YÊU CẦU
- Xây dựng một trang web đơn giản có các phần khác nhau cho các đơn vị đo lường khác nhau. Người dùng có thể nhập 
giá trị để chuyển đổi, chọn đơn vị để chuyển đổi từ và sang, và xem giá trị đã chuyển đổi.

-> Người dùng có thể nhập giá trị để chuyển đổi.
-> Người dùng có thể chọn đơn vị để chuyển đổi.
-> Người dùng có thể xem giá trị đã chuyển đổi.
-> Người dùng có thể chuyển đổi giữa các đơn vị đo lường khác nhau như chiều dài, trọng lượng, nhiệt độ, v.v. 
(thông tin chi tiết bên dưới).
-> Bạn có thể bao gồm các đơn vị đo lường sau để chuyển đổi giữa chúng:

=> Chiều dài: milimét, xentimét, mét, kilômét, inch, foot, yard, dặm.
=> Trọng lượng: miligam, gam, kilôgam, ounce, pound.
=> Nhiệt độ: độ C, độ F, độ Kelvin.
=> Nó hoạt động như thế nào
=> Bạn không cần sử dụng bất kỳ cơ sở dữ liệu nào cho dự án này. Sẽ có một trang web đơn giản gửi biểu mẫu 
đến máy chủ và lấy lại giá trị đã chuyển đổi và hiển thị trên trang web.

Bộ chuyển đổi đơn vị
Bạn có thể có 3 trang web cho mỗi loại chuyển đổi đơn vị (chiều dài, trọng lượng, nhiệt độ) 
với các biểu mẫu để nhập giá trị và chọn đơn vị để chuyển đổi "từ" và "sang". Gửi biểu mẫu sẽ gửi dữ liệu
 đến trang hiện tại (tức là target="_self") và hiển thị giá trị đã chuyển đổi. Bạn có thể thực hiện việc 
 này bằng ngôn ngữ lập trình phụ trợ theo lựa chọn của mình, tức là kiểm tra xem biểu mẫu đã được gửi chưa, 
 sau đó tính giá trị đã chuyển đổi và hiển thị trên trang web, nếu chưa được gửi thì hiển thị biểu mẫu.