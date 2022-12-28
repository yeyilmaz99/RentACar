using System;
namespace Entities.DTOs
{
	public class UserDetailDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public bool Status { get; set; }
		public int FindeksPoint { get; set; }

	}
}

