using System.ComponentModel.DataAnnotations;

namespace FunShield.Models
{
    public class Session
    {
        [Required]
        public string SessionID { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required]
        [StringLength(1, ErrorMessage = "SessionType must be A, B, or C.")]
        public string SessionType { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(DayOfWeek))]
        [Range(1, 5, ErrorMessage = "DayOfWeek must be between Monday and Friday.")]
        public DayOfWeek? DayOfWeek { get; set; }

        [Required]
        [RegularExpression("^(English|Spanish)$", ErrorMessage = "Language must be either 'English' or 'Spanish'.")]
        public string Language { get; set; } = string.Empty;

        [Required]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        public void GenerateSessionID()
        {
            SessionID = $"{SessionType}{DayOfWeek}{Language}";
        }
    }
}