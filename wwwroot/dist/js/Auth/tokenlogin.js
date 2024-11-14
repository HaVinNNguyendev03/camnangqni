document.querySelector('.img__btn').addEventListener('click', function () {
    document.querySelector('.cont').classList.toggle('s--signup');
});
//const apiBaseUrl = $('meta[name="api-base-url"]').attr('content');
const apiBaseUrl = window.location.origin;
$(document).ready(function () {
    // Lắng nghe sự kiện submit của form đăng nhập
    $("#loginForm").on("submit", function (event) {
        event.preventDefault(); // Ngăn chặn hành động mặc định của form

        // Lấy giá trị từ các trường input
        const email = $("#email").val();
        const password = $("#password").val();

        // Gửi yêu cầu POST đến API đăng nhập
        $.ajax({
            url: `${apiBaseUrl}/auth/login`, // Đường dẫn đến API
            type: 'POST', // Phương thức HTTP
            contentType: 'application/x-www-form-urlencoded', // Định dạng dữ liệu gửi đi
            data: `email=${encodeURIComponent(email)}&password=${encodeURIComponent(password)}`, // Dữ liệu gửi đi
            success: function (data) {
                const tokenrequest = document.cookie.split(';').some((item) => item.trim().startsWith('jwtToken='))
                if (tokenrequest) {
                    // Nếu cookie tồn tại, chuyển hướng đến trang khác
                    $("#message").text("Đăng nhập thành công!"); // Hiển thị thông báo thành công
                    window.location.href = `${apiBaseUrl}`; // Chuyển hướng đến URL
                } else {
                    // Nếu cookie không tồn tại, log ra thông điệp
                    console.log("Cookie 'jwtToken' không tồn tại.");
                }
            },
            error: function (xhr) {
                // Nếu có lỗi xảy ra, hiển thị thông báo lỗi
                $("#message").text("Đăng nhập thất bại: " + xhr.responseText);
            }
        });
    });
});

