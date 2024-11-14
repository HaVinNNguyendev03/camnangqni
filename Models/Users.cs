using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
    public string UserInfo { get; set; }
    public int? idmadonvi { get; set; } 
    public int? idthietbi {get; set; }
    [ForeignKey("idmadonvi")]
    public virtual int Madonvi { get; set; }
    
}
