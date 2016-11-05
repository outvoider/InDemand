using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InDemand.Models
{
	public class Posting
	{
		public Guid Id { get; set; }
		[Required]
		public bool IsProvider { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 3)]
		[RegularExpression(@"^[a-zA-Z''-'\s]+$")]
		public string Location { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 3)]
		[RegularExpression(@"^[a-zA-Z''-'\s]+$")]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		[StringLength(200, MinimumLength = 3)]
		[RegularExpression(@"^[a-zA-Z''-'\s]+$")]
		public string Tags { get; set; }
	}

	public class PostingDBContext : DbContext
	{
		public DbSet<Posting> Postings { get; set; }
	}
}