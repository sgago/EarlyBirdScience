using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EarlyBirdScience.Models
{
    public class PodcastModel
    {
        private const int MAX_TITLE_LENGTH = 30;
        private const int MAX_SUBTITLE_LENGTH = 140;

        [Key]
        [ScaffoldColumn(false)]
        public int PodcastId { get; set; }

        [DisplayName("Title")]
        [Required(ErrorMessage = "A podcast title is required")]
        [StringLength(MAX_TITLE_LENGTH)]
        public string Title { get; set; }

        [DisplayName("Subtitle")]
        [StringLength(MAX_SUBTITLE_LENGTH)]
        public string Subtitle { get; set; }

        [DisplayName("Published")]
        public bool Published { get; set; }

        [DisplayName("Comments Enabled")]
        public bool CommentsEnabled { get; set; }

        [ScaffoldColumn(false)]
        public string PodcastUrl { get; set; }

        DateModel DateModel { get; set; }

        ICollection<CommentModel> Comments { get; set; }
    }
}
