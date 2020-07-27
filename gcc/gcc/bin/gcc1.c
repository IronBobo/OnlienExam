#include <stdio.h>
#include <sys\stat.h>
#include <stdlib.h>
#include <string.h>
#include <dir.h>
#include <windows.h>
#include <conio.h>
#include <process.h>
#include <winreg.h>

int main(int argc, char *argv[])
{
    char path[256]="PATH=";
    char instpath[256];
    char *env[]={path,NULL};
    long l=256;
    int h;
    FILE *f;
	 h=RegQueryValue(HKEY_CLASSES_ROOT,"gccbinpath",instpath,&l);
	 if (h!=ERROR_SUCCESS) {
		 printf("gcc has not been installed properly %x\n",h);
		 return 1;
	 }
	 strcat(path,instpath);
	 strcat(instpath,"\\g++.exe");
    argv[0]=instpath;
    if(!(f=fopen(instpath,"r"))) {
	    printf("Could not execute gcc using %s this means that gcc has probably been moved or deleted, please reinstall it.\n",instpath);
       return 1;
    }    
    fclose(f);
    printf("running %s with env:%s\n",instpath,env[0]);
    t= CreateProcess(instpath,argv[0],NULL,NULL,TRUE,0,env,NULL,
    t=GetExitCodeProcess(h,&exitcode);
    return exitcode;
}




