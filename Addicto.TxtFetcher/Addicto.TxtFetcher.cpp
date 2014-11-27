// Addicto.TxtFetcher.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "Addicto.TxtFetcher.h"
#include <objbase.h>
#include <strsafe.h>

SIZE_T BufferLength = 1000;

VOID EnsureCurrentWindowInputIsAttached() {
	HWND curWnd = GetForegroundWindow();

	if (curWnd != NULL) {
		DWORD curThreadId = GetWindowThreadProcessId(curWnd, NULL);
		DWORD appThreadId = GetCurrentThreadId();

		HANDLE curThreadHandle = OpenThread(THREAD_ALL_ACCESS, false, curThreadId);
		HANDLE appThreadHandle = OpenThread(THREAD_ALL_ACCESS, false, appThreadId);

		if (curThreadHandle != INVALID_HANDLE_VALUE && appThreadHandle != INVALID_HANDLE_VALUE) {
			DWORD curProcessId = GetProcessIdOfThread(curThreadHandle);
			DWORD appProcessId = GetProcessIdOfThread(appThreadHandle);

			if (curProcessId != appProcessId) {
				AttachThreadInput(curThreadId, appThreadId, TRUE);
			}
		}

		if (curThreadHandle != INVALID_HANDLE_VALUE) {
			CloseHandle(curThreadHandle);
		}
		if (appThreadHandle != INVALID_HANDLE_VALUE) {
			CloseHandle(appThreadHandle);
		}
	}
}

VOID SendCopyCommandToCurrentWindow() {
	// We're sending two keys CONTROL and 'C'. Since keydown and keyup are two
	// seperate messages, we multiply that number by two.
	int key_count = 4;

	INPUT* input = new INPUT[key_count];
	for (int i = 0; i < key_count; i++)
	{
		input[i].ki.dwFlags = 0;
		input[i].type = INPUT_KEYBOARD;
	}

	input[0].ki.wVk = VK_CONTROL;
	input[0].ki.wScan = MapVirtualKey(VK_CONTROL, MAPVK_VK_TO_VSC);
	input[1].ki.wVk = 0x43; // Virtual key code for 'C'
	input[1].ki.wScan = MapVirtualKey(0x43, MAPVK_VK_TO_VSC);
	input[2].ki.dwFlags = KEYEVENTF_KEYUP;
	input[2].ki.wVk = input[0].ki.wVk;
	input[2].ki.wScan = input[0].ki.wScan;
	input[3].ki.dwFlags = KEYEVENTF_KEYUP;
	input[3].ki.wVk = input[1].ki.wVk;
	input[3].ki.wScan = input[1].ki.wScan;

	if (!SendInput(key_count, (LPINPUT)input, sizeof(INPUT)))
	{
		//TODO: error handling
	}
}

ADDICTOTXTFETCHER_API LPWSTR FetchSelectedText()
{
	LPWSTR result = (LPWSTR)CoTaskMemAlloc((BufferLength + 1) * sizeof(WCHAR));
	result[0] = '\0';

	EnsureCurrentWindowInputIsAttached();
	SendCopyCommandToCurrentWindow();

	Sleep(500);

	if (OpenClipboard(NULL))
	{
		HGLOBAL hglb = GetClipboardData(CF_UNICODETEXT);

		if (hglb != NULL)
		{
			LPWSTR clipboardData = (LPWSTR)GlobalLock(hglb);

			if (clipboardData != NULL) {
				wcscpy_s(result, BufferLength, clipboardData);
			}

			GlobalUnlock(hglb);
		}

		CloseClipboard();
	}
	else
	{
		//TODO: error handling
	}

	return result;
}