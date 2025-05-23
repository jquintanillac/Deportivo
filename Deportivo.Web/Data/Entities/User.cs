﻿using Deportivo.Common.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Deportivo.Web.Data.Entities
{
	public class User : IdentityUser
	{
		[Display(Name = "Document")]
		[MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
		[Required(ErrorMessage = "The field {0} is mandatory.")]
		public string Document { get; set; }

		[Display(Name = "First Name")]
		[MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
		[Required(ErrorMessage = "The field {0} is mandatory.")]
		public string FirstName { get; set; }

		[Display(Name = "Last Name")]
		[MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
		[Required(ErrorMessage = "The field {0} is mandatory.")]
		public string LastName { get; set; }

		[MaxLength(300, ErrorMessage = "The {0} field can not have more than {1} characters.")]
		public string Address { get; set; }

		[Display(Name = "Picture")]
		public string? PicturePath { get; set; }

		[Display(Name = "User Type")]
		public UserType UserType { get; set; }

		[Display(Name = "User")]
		public string FullName => $"{FirstName} {LastName}";

		[Display(Name = "User")]
		public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";


	}
}
