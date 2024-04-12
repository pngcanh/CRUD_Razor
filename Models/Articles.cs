using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Articles
{

    [Key]
    public int ArticleID { set; get; }

    [Required(ErrorMessage = "không được bỏ trống tiêu đề")]
    [Column(TypeName = "nvarchar")]
    [StringLength(maximumLength: 250, MinimumLength = 20)]
    [Display(Name = "Tiêu đề bài viết")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống nội dung bài viết")]
    [Column(TypeName = "ntext")]
    [Display(Name = "Nội dung bài viết")]
    public string Content { get; set; }

    [Required(ErrorMessage = "Không được bỏ trống ngày tạo")]
    [Column(TypeName = "smalldatetime")]
    [Display(Name = "Ngày tạo")]

    public DateTime Created { get; set; }

    [Display(Name = "Tác giả")]

    public int AuID { get; set; }
    [ForeignKey("AuID")] // tuy chinh ten FK 

    public Authors AuthorID { set; get; }//create FK in Articles  => PK in Authors


    public int CateID { get; set; }
    [Display(Name = "Thể loại")]
    [ForeignKey("CateID")]

    public Categories CategoryID { set; get; } // create FK in Articles => PK in Categories
}