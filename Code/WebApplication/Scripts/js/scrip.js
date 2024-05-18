const messages = [
    "Bạn muốn biết bạn nên nghỉ việc hay không ư?",
    "Có lẽ bạn nên suy nghĩ kỹ trước khi quyết định.",
    "Hãy xem xét các yếu tố tài chính của bạn.",
    "Nghỉ việc có thể là một bước đi đúng đắn.",
    "Nhưng đừng quên cân nhắc các cơ hội khác.",
    "Thử nói chuyện với sếp của bạn trước đã."
];

// Chỉ mục hiện tại của mảng
let currentIndex = 0;

// Hàm thay đổi nội dung của phần tử
function changeText() {
    // Lấy phần tử bằng id
    const element = document.getElementById("tognoek");
    // Thay đổi nội dung của phần tử
    element.textContent = messages[currentIndex];
    // Tăng chỉ mục và kiểm tra xem có vượt quá độ dài của mảng không
    currentIndex = (currentIndex + 1) % messages.length;
}

// Thiết lập thay đổi nội dung mỗi 2 giây
setInterval(changeText, 3000);