const messages = [
    "Dưới đây là kết quả của bạn.",
    "Dù kết quả có thế nào đi nữa.",
    "Bạn hãy nhớ luôn vui tươi.",
    "Và yêu đời nha bạn!!",
    "Tôi sẽ gửi Email về cho bạn.",
    "Bạn nhớ kiểm tra nha."
];
let currentIndex = 0;
function changeText() {
    const element = document.getElementById("tognoek");
    element.textContent = messages[currentIndex];
    currentIndex = (currentIndex + 1) % messages.length;
}

setInterval(changeText, 3000);