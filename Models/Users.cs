using System.ComponentModel.DataAnnotations;
public class Users
{
    [Key]
    public int UserID { get; set; }
    [Required(ErrorMessage = "Tên người dùng là bắt buộc.")]
    public string Username  { get; set; }
    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string UserEmail { get; set; }
     [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    public string UserPassWord { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int IsActive { get; set; } = 1;
    public int UserRule { get; set; } = 1;
}
