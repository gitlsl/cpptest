#pragma once

#include <Windows.h>

struct AAA
{
	int a;
	char b;
	DWORD c;
	wchar_t* qq;
};

void Send(AAA* a);