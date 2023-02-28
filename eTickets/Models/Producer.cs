using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eTickets.Models
{
	public class Producer
	{
		[Key]
		public int Id { get; set; }
		[Display(Name = "Profile")]
		public string ProfilePictureUrl { get; set; }
		[Display(Name = "Name")]
		public string FullName { get; set; }
		[Display(Name = "Bio")]
		public string Bio { get; set; }

		// Relationships
		public List<Movie> Movies { get; set; }
	}
}
