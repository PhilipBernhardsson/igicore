﻿using System.Data.Entity;
using IgiCore.Models.Appearance;
using IgiCore.Models.Groups;
using IgiCore.Models.Player;
using IgiCore.SDK.Server.Storage.Contexts;

namespace IgiCore.Server.Storage
{
	public class StorageContext : EFContext
	{
		public DbSet<Session> Sessions { get; set; }

		public DbSet<User> Users { get; set; }

		public DbSet<Character> Characters { get; set; }

		public DbSet<Group> Groups { get; set; }

		public DbSet<GroupMember> GroupMembers { get; set; }

		public DbSet<GroupRole> GroupRoles { get; set; }

		public DbSet<Style> Styles { get; set; }

		public StorageContext()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<StorageContext, Migrations.Configuration>());

			//this.Database.Log = m => new Logger().Debug(m); // ;Logging=true
		}
	}
}