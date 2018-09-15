using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EarlyBirdScience.Models
{
    public class PostModel
    {
        private const int MAX_TITLE_LENGTH = 30;
        private const int MAX_SUBTITLE_LENGTH = 140;

        [Key]
        [ScaffoldColumn(false)]
        public int PostId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "A blog title is required")]
        [StringLength(MAX_TITLE_LENGTH)]
        public string Title { get; set; }

        [DisplayName("Subtitle")]
        [StringLength(MAX_SUBTITLE_LENGTH)]
        public string Subtitle { get; set; }

        [DisplayName("Published")]
        public bool Published { get; set; }

        [DisplayName("Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [DisplayName("Comments Enabled")]
        public bool CommentsEnabled { get; set; }

        [DisplayName("Blog Content")]
        public string Content { get; set; }

        public DateModel Date { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
