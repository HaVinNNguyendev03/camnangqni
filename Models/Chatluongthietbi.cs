using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Chatluongthietbi {
    [Key]
    public int idChatluongthietbi {get; set; }
    public string tenchatluongthietbi {get; set; }
}