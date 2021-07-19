using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using UnityEngine.UI;
using System.CodeDom;
using Transmtn.DTO.Notifications;

public class QuickMenuSocialElement : MonoBehaviour
{
    public QuickMenuSocialElement(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public enum IconType
	{
		None = -1,
		GenericNotification,
		Blocked,
		Muted,
		VoteToKick,
		Friend,
		FriendRequest,
		Invite,
		InviteWithPhoto,
		InviteResponse,
		InviteResponseWithPhoto,
		RequestInvite,
		RequestInviteWithPhoto,
		RequestInviteResponse,
		RequestInviteResponseWithPhoto
	}

	public enum ElementType
	{
		Empty,
		Notification,
		User
	}

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().First(x => x.BaseType == MonoBehaviour.Instance_Class && x.GetField(Notification.Instance_Class) != null);
}
