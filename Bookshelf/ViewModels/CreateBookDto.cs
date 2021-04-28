using System.ComponentModel.DataAnnotations;

namespace Bookshelf.ViewModels
{
    public class CreateBookDto : IRequestDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}