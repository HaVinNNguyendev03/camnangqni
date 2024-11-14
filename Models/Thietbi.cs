using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Thietbi {
    [Key]
    public int idthietbi { get; set; }
    public string tenthietbi {get; set; }
    public string thongtinthietbi {get; set; }
    public int idmadonvi { get; set; }
    public int UserID { get; set; }
    public int idTrangthaithietbi { get; set; }
    public int idChatluongthietbi { get; set; }
    public int idLoaithietbi { get; set; }
    [ForeignKey("idmadonvi")]
    public virtual Madonvi madonvi { get; set; }    
    [ForeignKey("UserID")]
    public virtual Users users { get; set; }
    [ForeignKey("idTrangthaithietbi")]
    public virtual Trangthaithietbi trangthaithietbi { get; set; }
    [ForeignKey("idChatluongthietbi")]
    public virtual Chatluongthietbi chatluongthietbi { get; set; }
    [ForeignKey("idLoaithietbi")]
    public virtual Loaithietbi loaithietbi { get; set; }
}