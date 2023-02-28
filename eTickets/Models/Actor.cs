using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace eTickets.Models
{
	public class Actor
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
		public List<Actor_Movie> Actors_Movies { get; set; }
	}
}
