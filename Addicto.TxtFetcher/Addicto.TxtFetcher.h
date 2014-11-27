// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the ADDICTOTXTFETCHER_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// ADDICTOTXTFETCHER_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef ADDICTOTXTFETCHER_EXPORTS
#define ADDICTOTXTFETCHER_API __declspec(dllexport)
#else
#define ADDICTOTXTFETCHER_API __declspec(dllimport)
#endif

#include <Windows.h>

//returns text that is selected in the currently focused window
extern "C" ADDICTOTXTFETCHER_API LPWSTR FetchSelectedText();
