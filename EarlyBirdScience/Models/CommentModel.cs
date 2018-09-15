using System.ComponentModel.DataAnnotations;

namespace EarlyBirdScience.Models
{
    public class CommentModel
    {
        private const int MIN_COMMENT_LENGTH = 1;
        private const int MAX_COMMENT_LENGTH = 1024;

        [Key]
        [ScaffoldColumn(false)]
        public int CommentId { get; set; }

        public bool Removed { get; set; } = false;

        [Required(ErrorMessage = "A comment is required")]
        [StringLength(MAX_COMMENT_LENGTH)]
        public string Content { get; set; } = "";

        public DateModel DateModel { get; set; } = new DateModel();
    }
}
