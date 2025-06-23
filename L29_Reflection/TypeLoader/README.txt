------------- REFLECTION -----------------


- Reflection là cơ chế cho phép ứng dụng .NET quan sát (inspect) và thao tác (modifiy) metadata của các loại (types), 
thành viên (members) như phương thức (methods), thuộc tính (properties), trường dữ liệu (fields), thuộc tính tùy chỉnh
 (custom attributes)… ngay tại thời điểm chạy (runtime).
  
 -> Reflection nằm trong namespace System.Reflection.
 -> Cho phép khởi tạo đối tượng, gọi phương thức, đọc/ghi giá trị thuộc tính… 
 mà không cần biết trước thông tin này ở thời điểm biên dịch.
# CÁC THÀNH PHẦN CHÍNH
-> Assembly: đại diện cho một tập hợp các loại đã được biên dịch (thư viện .dll hoặc .exe).
-> Module: một phần nhỏ hơn của Assembly, chứa các type.
-> Type (System.Type): đại diện cho một kiểu dữ liệu (class, interface, enum, struct).
-> MemberInfo: lớp cơ sở chung cho MethodInfo, PropertyInfo, FieldInfo, EventInfo…
-> MethodInfo: thông tin về phương thức (tên, tham số, return type), cho phép gọi phương thức.
-> PropertyInfo: thông tin về thuộc tính, cho phép get/set giá trị.
-> FieldInfo: thông tin về trường dữ liệu (field), cho phép đọc/ghi.
-> ConstructorInfo: thông tin về constructor, cho phép khởi tạo đối tượng.
-> Attribute: cho phép đọc các custom attribute gắn trên type/member.
