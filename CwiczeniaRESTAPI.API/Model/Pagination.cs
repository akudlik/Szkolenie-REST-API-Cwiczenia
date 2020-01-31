using System.ComponentModel.DataAnnotations;

namespace CwiczeniaRESTAPI.API.Model
{
    public class Pagination
    {
        [Required]
        [Range(1, 100)] 
        public int PageSize { get; set; } = 100;

        [Required] 
        public int PageNumber { get; set; } = 0;
    }
}