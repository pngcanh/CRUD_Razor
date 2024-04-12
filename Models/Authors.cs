using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Authors
{
    [Key]
    [Display(Name = "ID")]
    public int AuthorID { set; get; }

    [Display(Name = "Tên tác giả")]
    [Required(ErrorMessage = "{0} không được bỏ trống")]
    [Column(TypeName = "nvarchar")]
    [StringLength(255)]
    public string AuthorName { set; get; }

    [DisplayName("Địa chỉ Email")]
    [Column(TypeName = "nvarchar")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    [StringLength(255)]
    public string Email { set; get; }
}