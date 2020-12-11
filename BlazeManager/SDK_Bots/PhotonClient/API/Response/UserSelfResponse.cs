using System;
using System.Collections.Generic;

namespace PhotonClient.API.Response
{
	public class UserSelfResponse : UserResponse
	{
		public List<PastDisplayName> pastDisplayNames { get; set; }

		public bool hasEmail { get; set; }

		public string obfuscatedEmail { get; set; }

		public bool emailVerified { get; set; }

		public bool hasBirthday { get; set; }
		
		public bool unsubscribe { get; set; }

		public List<string> friends { get; set; }

		public string blueprints { get; set; }
		
		public string currentAvatarBlueprint { get; set; }

		public List<string> events { get; set; }

		public string currentAvatar { get; set; }

		public string currentAvatarAssetUrl { get; set; }

		public int acceptedTOSVersion { get; set; }

		public string steamDetails { get; set; }

		public bool hasLoggedInFromClient { get; set; }
	}
}
