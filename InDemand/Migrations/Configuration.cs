namespace InDemand.Migrations
{
	using InDemand.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<InDemand.Models.PostingDBContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(InDemand.Models.PostingDBContext context)
		{
			context.Postings.AddOrUpdate(
				new Posting
				{
					Id = Guid.NewGuid(),
					IsProvider = true,
					Location = "City A",
					Title = "Lumberjack",
					Description = "I cut trees.",
					Tags = "axe cut tree"
				},
				new Posting
				{
					Id = Guid.NewGuid(),
					IsProvider = false,
					Location = "City A",
					Title = "Lumberjack Manager",
					Description = "I need trees to be cut.",
					Tags = "cut tree"
				},
				new Posting
				{
					Id = Guid.NewGuid(),
					IsProvider = true,
					Location = "City B",
					Title = "Counsel",
					Description = "I provide legal counselling.",
					Tags = "legal counsel"
				},
				new Posting
				{
					Id = Guid.NewGuid(),
					IsProvider = false,
					Location = "City B",
					Title = "Mistress in distress",
					Description = "I require legal counsel on a private matter.",
					Tags = "legal counsel"
				},
				new Posting
				{
					Id = Guid.NewGuid(),
					IsProvider = true,
					Location = "City A",
					Title = "Artist",
					Description = "I create!",
					Tags = "draw paint picture"
				});
		}
	}
}
