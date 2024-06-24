using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 character long.")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "The content must be 8 characters long.")]
        [MaxLength(100, ErrorMessage = "The content must not be above 100 characters long.")]
        public string Content { get; set; } = string.Empty;
    }
}