using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace System.Net
{
    public class IL2WebClient : IL2Base
    {
        public IL2WebClient(IntPtr ptr) : base(ptr) => base.ptr = ptr;
		public IL2WebClient() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public IntPtr DownloadData(string address)
		{
			ClearWebClientState();
			IntPtr result;
			try
			{
				IL2WebRequest webRequest;
				result = DownloadDataInternal(address, out webRequest);
			}
			finally
			{
				CompleteWebClientState();
			}
			return result;
		}

		private IntPtr DownloadDataInternal(string address, out IL2WebRequest request)
		{
			request = null;
			IntPtr result;
			try
			{
				IntPtr uri = GetUri(address);
				request = GetWebRequest(uri);
				result = DownloadBits(request);
			}
			catch (Exception ex)
			{
				AbortRequest(request);
				throw ex;
			}
			return result;
		}

		private void ClearWebClientState()
		{
			Instance_Class.GetMethod(nameof(ClearWebClientState)).Invoke(ptr);
		}

		private void CompleteWebClientState()
		{
			Instance_Class.GetMethod(nameof(CompleteWebClientState)).Invoke(ptr);
		}

		// More: , Stream writeStream, CompletionDelegate completionDelegate, AsyncOperation asyncOp
		private IntPtr DownloadBits(IL2WebRequest request)
		{
			return Instance_Class.GetMethod(nameof(DownloadBits)).Invoke(ptr, new IntPtr[] { request.ptr, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, }).ptr;
		}

		private IL2WebRequest GetWebRequest(IntPtr address)
		{
			return Instance_Class.GetMethod(nameof(GetWebRequest)).Invoke(ptr, new IntPtr[] { address })?.GetValue<IL2WebRequest>();
		}

		private IntPtr GetUri(string path)
		{
			return Instance_Class.GetMethod(nameof(GetUri), x => x.GetParameters()[0].Name == "path").Invoke(ptr, new IntPtr[] { new IL2String(path).ptr }).ptr;
		}

		private static void AbortRequest(IL2WebRequest request)
		{
			IntPtr ptr = IntPtr.Zero;
			if (request != null)
				ptr = request.ptr;

			Instance_Class.GetMethod(nameof(AbortRequest)).Invoke(new IntPtr[] { ptr });
		}

		public static IL2Class Instance_Class = Assembler.list["System"].GetClass("WebClient", "System.Net");
    }
}
