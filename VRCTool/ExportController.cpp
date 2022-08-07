#include "Exports.h"
#include "include\MinHook.h"

void VRC_EnableHook(LPVOID pTarget)
{
    MH_EnableHook(pTarget);
}

void VRC_DisableHook(LPVOID pTarget)
{
    MH_DisableHook(pTarget);
}

void VRC_CreateHook(LPVOID pTarget, LPVOID pDetour, LPVOID *ppOrig)
{
#if (DEBUG)
	switch (MH_CreateHook(pTarget, pDetour, ppOrig)) {
    case MH_UNKNOWN:
        ConsoleUtils::Log("Patch: Unknown");
        break;
    case MH_OK:
        ConsoleUtils::Log("Patch: OK");
        MH_EnableHook(pTarget);
        break;
    case MH_ERROR_ALREADY_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY INITIALIZED");
        break;
    case MH_ERROR_NOT_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> NOT INITIALIZED");
        break;
    case MH_ERROR_ALREADY_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY CREATED");
        break;
    case MH_ERROR_NOT_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> NOT CREATED");
        break;
    case MH_ERROR_ENABLED:
        ConsoleUtils::Log("Patch: ERROR -> ENABLED");
        break;
    case MH_ERROR_DISABLED:
        ConsoleUtils::Log("Patch: ERROR -> DISABLED");
        break;
    case MH_ERROR_NOT_EXECUTABLE:
        ConsoleUtils::Log("Patch: ERROR -> NOT EXECUTABLE");
        break;
    case MH_ERROR_UNSUPPORTED_FUNCTION:
        ConsoleUtils::Log("Patch: ERROR -> UNSUPPORTED FUNCTION");
        break;
    case MH_ERROR_MEMORY_ALLOC:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY ALLOC");
        break;
    case MH_ERROR_MEMORY_PROTECT:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY PROTECT");
        break;
    case MH_ERROR_MODULE_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> MODULE NOT FOUND");
        break;
    case MH_ERROR_FUNCTION_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> FUNCTION NOT FOUND");
        break;
    }
#else
    if (MH_CreateHook(pTarget, pDetour, ppOrig) == MH_OK)
        MH_EnableHook(pTarget);
#endif
}

void VRC_RemoveHook(LPVOID pTarget)
{
#if (DEBUG)
	switch (MH_RemoveHook(pTarget)) {
    case MH_UNKNOWN:
        ConsoleUtils::Log("Patch: Unknown");
        break;
    case MH_OK:
        ConsoleUtils::Log("Patch: OK");
        break;
    case MH_ERROR_ALREADY_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY INITIALIZED");
        break;
    case MH_ERROR_NOT_INITIALIZED:
        ConsoleUtils::Log("Patch: ERROR -> NOT INITIALIZED");
        break;
    case MH_ERROR_ALREADY_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> ALREADY CREATED");
        break;
    case MH_ERROR_NOT_CREATED:
        ConsoleUtils::Log("Patch: ERROR -> NOT CREATED");
        break;
    case MH_ERROR_ENABLED:
        ConsoleUtils::Log("Patch: ERROR -> ENABLED");
        break;
    case MH_ERROR_DISABLED:
        ConsoleUtils::Log("Patch: ERROR -> DISABLED");
        break;
    case MH_ERROR_NOT_EXECUTABLE:
        ConsoleUtils::Log("Patch: ERROR -> NOT EXECUTABLE");
        break;
    case MH_ERROR_UNSUPPORTED_FUNCTION:
        ConsoleUtils::Log("Patch: ERROR -> UNSUPPORTED FUNCTION");
        break;
    case MH_ERROR_MEMORY_ALLOC:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY ALLOC");
        break;
    case MH_ERROR_MEMORY_PROTECT:
        ConsoleUtils::Log("Patch: ERROR -> MEMORY PROTECT");
        break;
    case MH_ERROR_MODULE_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> MODULE NOT FOUND");
        break;
    case MH_ERROR_FUNCTION_NOT_FOUND:
        ConsoleUtils::Log("Patch: ERROR -> FUNCTION NOT FOUND");
        break;
    }
#else
    MH_RemoveHook(pTarget);
#endif
}