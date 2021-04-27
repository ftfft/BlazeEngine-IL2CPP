using BE4v.SDK.CPP2IL;
using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
	public abstract class BaseRaycaster : UIBehaviour
	{
		public BaseRaycaster(IntPtr ptr) : base(ptr) => base.ptr = ptr;
		/*
		public abstract void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList);

		public abstract Camera eventCamera { get; }

		public virtual int priority
		{
			get
			{
			}
		}

		public virtual int sortOrderPriority
		{
			get
			{
			}
		}

		public virtual int renderOrderPriority
		{
			get
			{
			}
		}

		public override string ToString()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
		*/
		public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("BaseRaycaster", "UnityEngine.EventSystems");
	}
}
