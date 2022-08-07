#pragma once

extern "C"
{
	// __declspec(dllexport) IL2CPPDomain* __stdcall vrcloader_get_domain();
	__declspec(dllexport) void __stdcall VRC_CreateHook(LPVOID pTarget, LPVOID pDetour, LPVOID *ppOrig);
	__declspec(dllexport) void __stdcall VRC_RemoveHook(LPVOID pTarget);
	__declspec(dllexport) void __stdcall VRC_EnableHook(LPVOID pTarget);
	__declspec(dllexport) void __stdcall VRC_DisableHook(LPVOID pTarget);
	//__declspec(dllexport) size_t __stdcall vrcloader_get_net_mod_count();
	//__declspec(dllexport) const char* __stdcall vrcloader_get_net_mod(UINT index);
}