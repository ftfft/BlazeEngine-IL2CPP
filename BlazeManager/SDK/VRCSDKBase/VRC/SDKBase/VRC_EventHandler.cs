using System;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using System.Linq;

namespace VRC.SDKBase
{
	public class VRC_EventHandler : MonoBehaviour
	{
		public VRC_EventHandler(IntPtr ptr) : base(ptr) => this.ptr = ptr;

        public static bool BooleanOp(VrcBooleanOp Op, bool Current)
        {
            return Instance_Class.GetMethod(nameof(BooleanOp)).Invoke(new IntPtr[] { Op.MonoCast(), Current.MonoCast() }).unbox_Unmanaged<bool>();
        }


        public int NetworkID
        {
            get => Instance_Class.GetProperty(nameof(NetworkID)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<int>();
            set => Instance_Class.GetProperty(nameof(NetworkID)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }


        /*
		public static bool BooleanOp(VRC_EventHandler.VrcBooleanOp Op, bool Current)
		{
		}

		public int NetworkID
		{
			[Address(RVA = "0x18041E0C0", Offset = "0x41C6C0")]
			get
			{
			}
			[Address(RVA = "0x18052B0A0", Offset = "0x5296A0")]
			set
			{
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x00002838 File Offset: 0x00000A38
		private VRC_EventDispatcher Dispatcher
		{
			[Address(RVA = "0x182E84430", Offset = "0x2E82A30")]
			get
			{
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060002E1 RID: 737 RVA: 0x0000283C File Offset: 0x00000A3C
		// (set) Token: 0x060002E2 RID: 738 RVA: 0x00002840 File Offset: 0x00000A40
		public static VRC_EventHandler.GetNetworkIdDelegate GetInsitgatorId
		{
			[Address(RVA = "0x182E84570", Offset = "0x2E82B70")]
			get
			{
			}
			[Address(RVA = "0x182E845B0", Offset = "0x2E82BB0")]
			set
			{
			}
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x00002844 File Offset: 0x00000A44
		[Address(RVA = "0x182E82B50", Offset = "0x2E81150")]
		private void Awake()
		{
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x00002848 File Offset: 0x00000A48
		[Address(RVA = "0x182E841F0", Offset = "0x2E827F0")]
		public void VrcAnimationEvent(AnimationEvent aEvent)
		{
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x0000284C File Offset: 0x00000A4C
		[Address(RVA = "0x182E83250", Offset = "0x2E81850")]
		public static bool IsReceiverRequiredForEventType(VRC_EventHandler.VrcEventType eventType)
		{
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x00002850 File Offset: 0x00000A50
		[Address(RVA = "0x182E839F0", Offset = "0x2E81FF0")]
		public void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, [Optional] GameObject instagator, float fastForward = 0f)
		{
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00002854 File Offset: 0x00000A54
		[Address(RVA = "0x182E83020", Offset = "0x2E81620")]
		private void InternalTriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x00002858 File Offset: 0x00000A58
		[Address(RVA = "0x182E836A0", Offset = "0x2E81CA0")]
		public void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002E9 RID: 745 RVA: 0x0000285C File Offset: 0x00000A5C
		[Address(RVA = "0x182E834F0", Offset = "0x2E81AF0")]
		public void TriggerEvent(string eventName, VRC_EventHandler.VrcBroadcastType broadcast, [Optional] GameObject instagator, int instagatorId = 0)
		{
		}

		// Token: 0x060002EA RID: 746 RVA: 0x00002860 File Offset: 0x00000A60
		[Address(RVA = "0x182E83840", Offset = "0x2E81E40")]
		public void TriggerEvent(string eventName, VRC_EventHandler.VrcBroadcastType broadcast, GameObject instagator, int instagatorId, float fastForward)
		{
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00002864 File Offset: 0x00000A64
		[Address(RVA = "0x182E83350", Offset = "0x2E81950")]
		private void OnValidate()
		{
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00002868 File Offset: 0x00000A68
		[Address(RVA = "0x182E83260", Offset = "0x2E81860")]
		private void OnDestroy()
		{
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0000286C File Offset: 0x00000A6C
		[Address(RVA = "0x180458550", Offset = "0x456B50")]
		public long GetCombinedNetworkId()
		{
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00002870 File Offset: 0x00000A70
		[Address(RVA = "0x182E82FA0", Offset = "0x2E815A0")]
		public static bool HasEventTrigger(GameObject go)
		{
		}

		// Token: 0x060002EF RID: 751 RVA: 0x00002874 File Offset: 0x00000A74
		[Address(RVA = "0x18041E390", Offset = "0x41C990")]
		public bool IsReadyForEvents()
		{
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00002878 File Offset: 0x00000A78
		[Address(RVA = "0x182E82DC0", Offset = "0x2E813C0")]
		public void DeferEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, GameObject instagator, float fastForward)
		{
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x0000287C File Offset: 0x00000A7C
		[Address(RVA = "0x182E83490", Offset = "0x2E81A90")]
		private IEnumerator ProcessDeferredEvents()
		{
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00002880 File Offset: 0x00000A80
		[Address(RVA = "0x182E843B0", Offset = "0x2E829B0")]
		public VRC_EventHandler()
		{
		}

		// Token: 0x040003CC RID: 972
		[SerializeField]
		[FieldOffset(Offset = "0x18")]
		public List<VRC_EventHandler.VrcEvent> Events;

		// Token: 0x040003CD RID: 973
		[FieldOffset(Offset = "0x20")]
		private int <NetworkID>k__BackingField;

		// Token: 0x040003CE RID: 974
		[FieldOffset(Offset = "0x28")]
		private VRC_EventDispatcher _dispatcher;

		// Token: 0x040003CF RID: 975
		public static VRC_EventHandler.GetNetworkIdDelegate GetInstigatorId;

		// Token: 0x040003D0 RID: 976
		[FieldOffset(Offset = "0x8")]
		public static VRC_EventHandler.LogEventDelegate LogEvent;

		// Token: 0x040003D1 RID: 977
		[FieldOffset(Offset = "0x30")]
		public List<VRC_EventHandler.EventInfo> deferredEvents;

		// Token: 0x040003D2 RID: 978
		[FieldOffset(Offset = "0x38")]
		private Coroutine DeferredEventProcessor;
		*/

        public enum VrcEventType
		{
			MeshVisibility,
			AnimationFloat,
			AnimationBool,
			AnimationTrigger,
			AudioTrigger,
			PlayAnimation,
			SendMessage,
			SetParticlePlaying,
			TeleportPlayer,
			RunConsoleCommand,
			SetGameObjectActive,
			SetWebPanelURI,
			SetWebPanelVolume,
			SpawnObject,
			SendRPC,
			ActivateCustomTrigger,
			DestroyObject,
			SetLayer,
			SetMaterial,
			AddHealth,
			AddDamage,
			SetComponentActive,
			AnimationInt,
			AnimationIntAdd = 24,
			AnimationIntSubtract,
			AnimationIntMultiply,
			AnimationIntDivide,
			AddVelocity,
			SetVelocity,
			AddAngularVelocity,
			SetAngularVelocity,
			AddForce,
			SetUIText,
			CallUdonMethod
		}

		public enum VrcBroadcastType
		{
			Always,
			Master,
			Local,
			Owner,
			AlwaysUnbuffered,
			MasterUnbuffered,
			OwnerUnbuffered,
			AlwaysBufferOne,
			MasterBufferOne,
			OwnerBufferOne
		}

		public enum VrcTargetType
		{
			All,
			Others,
			Owner,
			Master,
			AllBuffered,
			OthersBuffered,
			Local,
			AllBufferOne,
			OthersBufferOne,
			TargetPlayer
		}

		public enum VrcBooleanOp
		{
			Unused = -1,
			False,
			True,
			Toggle
		}

		public class VrcEvent : IL2Base
		{
            public VrcEvent(IntPtr ptr) : base(ptr) => this.ptr = ptr;

			public VrcEvent() : base(IntPtr.Zero)
			{
				ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
				Instance_Class.GetConstructor().Invoke(ptr);
            }

            public string Name
            {
                get => Instance_Class.GetField(nameof(Name)).GetValue(ptr)?.unbox_ToString().ToString();
                set => Instance_Class.GetField(nameof(Name)).SetValue(ptr, new IL2String(value).ptr);
            }

            public VrcEventType EventType
            {
                get => Instance_Class.GetField(nameof(EventType)).GetValue(ptr).unbox_Unmanaged<VrcEventType>();
                set => Instance_Class.GetField(nameof(EventType)).SetValue(ptr, value.MonoCast());
            }

            public string ParameterString
            {
                get => Instance_Class.GetField(nameof(ParameterString)).GetValue(ptr)?.unbox_ToString().ToString();
                set => Instance_Class.GetField(nameof(ParameterString)).SetValue(ptr, new IL2String(value).ptr);
            }

            public VrcBooleanOp ParameterBoolOp
            {
                get => Instance_Class.GetField(nameof(ParameterBoolOp)).GetValue(ptr).unbox_Unmanaged<VrcBooleanOp>();
                set => Instance_Class.GetField(nameof(ParameterBoolOp)).SetValue(ptr, value.MonoCast());
            }
            
            public bool ParameterBool
            {
                get => Instance_Class.GetField(nameof(ParameterBool)).GetValue(ptr).unbox_Unmanaged<bool>();
                set => Instance_Class.GetField(nameof(ParameterBool)).SetValue(ptr, value.MonoCast());
            }
            
            public float ParameterFloat
            {
                get => Instance_Class.GetField(nameof(ParameterFloat)).GetValue(ptr).unbox_Unmanaged<float>();
                set => Instance_Class.GetField(nameof(ParameterFloat)).SetValue(ptr, value.MonoCast());
            }
            
            public int ParameterInt
            {
                get => Instance_Class.GetField(nameof(ParameterInt)).GetValue(ptr).unbox_Unmanaged<int>();
                set => Instance_Class.GetField(nameof(ParameterInt)).SetValue(ptr, value.MonoCast());
            }
            
            public GameObject ParameterObject
            {
                get => Instance_Class.GetField(nameof(ParameterObject)).GetValue(ptr).unbox<GameObject>();
                set => Instance_Class.GetField(nameof(ParameterObject)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
            }
			
            public GameObject[] ParameterObjects
			{
                get => Instance_Class.GetField(nameof(ParameterObjects)).GetValue(ptr)?.unbox_ToArray<GameObject>();
                set => Instance_Class.GetField(nameof(ParameterObjects)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.Select(x => x.ptr).ToArray().ArrayToIntPtr(GameObject.Instance_Class));
            }

            public byte[] ParameterBytes
			{
                get => Instance_Class.GetField(nameof(ParameterBytes)).GetValue(ptr)?.unbox_ToArray_Unmanaged<byte>();
				set
				{
					IntPtr result = IntPtr.Zero;
					if (value != null)
					{
						IntPtr[] ptrs = new IntPtr[value.Length];
						unsafe
						{
							for (int i = 0; i < value.Length; i++)
							{
								fixed (byte* pointer = &value[i])
								{
									ptrs[i] = new IntPtr(pointer);
								}
							}
						}
						result = ptrs.ArrayToIntPtr(BlazeTools.IL2SystemClass.Byte);
					}
					Instance_Class.GetField(nameof(ParameterBytes)).SetValue(ptr, result);
				}
			}

			public int? ParameterBytesVersion
			{
				get => Instance_Class.GetField(nameof(ParameterBytesVersion)).GetValue(ptr)?.unbox_Unmanaged<int>();
				set => Instance_Class.GetField(nameof(ParameterBytesVersion)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.Value.MonoCast());
			}

			public bool TakeOwnershipOfTarget
			{
				get => Instance_Class.GetField(nameof(TakeOwnershipOfTarget)).GetValue(ptr).unbox_Unmanaged<bool>();
				set => Instance_Class.GetField(nameof(TakeOwnershipOfTarget)).SetValue(ptr, value.MonoCast());
			}

            public static IL2Type Instance_Class = VRC_EventHandler.Instance_Class.GetNestedType("VrcEvent");
		}

		/*
		public class EventInfo
		{
			public EventInfo()
			{
			}

			public VRC_EventHandler.VrcEvent evt;

			public VRC_EventHandler.VrcBroadcastType broadcast;

			public GameObject instagator;

			public float fastForward;
		}
		*/
		public static new IL2Type Instance_Class = Assemblies.a["VRCSDKBase"].GetClass("VRC_EventHandler", "VRC.SDKBase");
	}
}
