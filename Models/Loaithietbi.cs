using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Loaithietbi {
    [Key]
    public int idLoaithietbi {get; set; }
    public string tenloaithietbi {get; set; }
}