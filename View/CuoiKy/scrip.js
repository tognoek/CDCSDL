const messages = [
    "Bạn muốn biết bạn nên nghỉ việc hay không ư?",
    "Có lẽ bạn nên suy nghĩ kỹ trước khi quyết định.",
    "Hãy xem xét các yếu tố tài chính của bạn.",
    "Nghỉ việc có thể là một bước đi đúng đắn.",
    "Nhưng đừng quên cân nhắc các cơ hội khác.",
    "Thử nói chuyện với sếp của bạn trước đã."
];
let currentIndex = 0;
function changeText() {
    const element = document.getElementById("tognoek");
    element.textContent = messages[currentIndex];
    currentIndex = (currentIndex + 1) % messages.length;
}

setInterval(changeText, 3000);