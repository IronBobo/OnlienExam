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
    char path[256]="";
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
	 strcat(path,"\\g++.exe");
    argv[0]=path;
    if(!(f=fopen(path,"r"))) {
	    printf("Could not execute gcc using %s this means that gcc has probably been moved or deleted, please reinstall it.\n",path);
       return 1;
    }    
    fclose(f);
//    printf("running %s with path:%s %d\n",instpath,env[0],argc);
    return spawnv(_P_WAIT,path,argv); //,env);
}




