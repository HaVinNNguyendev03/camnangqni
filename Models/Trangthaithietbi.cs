using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Trangthaithietbi {
    [Key]
    public int idTrangthaithietbi {get; set; }
    public string tentrangthai {get; set; }
}