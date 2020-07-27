#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <dir.h>
#include <windows.h>
#include <winreg.h>

void shortcut(char *gccpath,int to) {
	char command[800];
        sprintf(command,"shortcut \"%s\\jfe.exe\" %d \"%s\"",gccpath,to,gccpath);
	system(command);
}
void Error(void) 
{ 
    TCHAR szBuf[80]; 
    LPVOID lpMsgBuf;
    DWORD dw = GetLastError(); 

    FormatMessage(
        FORMAT_MESSAGE_ALLOCATE_BUFFER | 
        FORMAT_MESSAGE_FROM_SYSTEM,
        NULL,
        dw,
        MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
        (LPTSTR) &lpMsgBuf,
        0, NULL );

    printf("Failed with error %d: %s", 
         dw, lpMsgBuf); 
 
//    MessageBox(NULL, szBuf, "Error", MB_OK); 

    LocalFree(lpMsgBuf);

}

int main(int argc,char *argv[]) {
        char cwd[256],winpath[256],gccbin[300];
	char command[800];
	char shortpath[256];
	
   chdir("gcc");
   chdir("bin");
	getcwd(cwd,256);
   strcpy(gccbin,cwd);
   if(GetShortPathName(gccbin,shortpath,256))
     strcpy(gccbin,shortpath);
   else
     Error();
   printf("Installing to %s\n",gccbin);
	GetWindowsDirectory(winpath,256);
   shortcut(gccbin,1);
   shortcut(gccbin,2);
   shortcut(gccbin,3); 
	if(RegSetValue(HKEY_CLASSES_ROOT,"gccbinpath",REG_SZ,gccbin,strlen(gccbin)))
		puts("Failed to set registry entry");
	sprintf(command,"copy \"%s\\gcc.exe\" \"%s\" > NUL",gccbin,winpath);
	system(command);
	return 0;
}
