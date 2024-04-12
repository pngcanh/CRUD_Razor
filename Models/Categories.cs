using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Categories
{
    [Key]
    [Display(Name = "ID")]

    public int CategoryID { set; get; }

    [DisplayName("Tên thể loại")]
    [Required(ErrorMessage = "Tên thể loại không được bỏ trống!")]
    [Column(TypeName = "nvarchar")]
    [StringLength(255)]
    public string CategoryName { set; get; }

}