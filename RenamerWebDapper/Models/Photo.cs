using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenamerWebDapper.Models
{
    internal class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string? Folder { get; set; }

        [StringLength(250, MinimumLength = 3)]
        public string? Description { get; set; } = string.Empty;

        [StringLength(250, MinimumLength = 3)]
        public string? Image { get; set; } = string.Empty;

    }
}
