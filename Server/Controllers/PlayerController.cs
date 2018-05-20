using System.Data.Entity.Migrations;
using CitizenFX.Core;
using IgiCore.Models.Player;

namespace IgiCore.Server.Controllers
{
    public static class PlayerController
	{
		public static async void Connecting([FromSource] Player player, string playerName, CallbackDelegate kickReason)
		{
			Server.Log("CONNECTING");

			var user = await UserController.GetOrCreate(player);

			Server.Log("USER");

			user.Name = player.Name;

			Server.Db.Users.AddOrUpdate(user);
			await Server.Db.SaveChangesAsync();

			var session = await SessionController.Create(player, user);

			Server.Log($"[CONNECT] [{session.Id}] Player \"{user.Name}\" connected from {session.IpAddress}");
		}

		public static async void Dropped([FromSource] Player player, string disconnectMessage, CallbackDelegate kickReason)
		{
			var user = await UserController.GetOrCreate(player);

			var session = await SessionController.End(user, disconnectMessage);

			Server.Log($"[DISCONNECT] [{session.Id}] Player \"{user.Name}\" disconnected: {disconnectMessage}");
		}
	}
}
