#include <stdio.h>  
#include <string.h>  
// calendar.c  written by martin for 59.102 July 1999
// verson 1.1 multiple columns 

int leapyear(int year) 
{  
    // is year a leap year?
    // the rule for leap years is that a year is a leap year if it
    // is divisible by four but not by 100 or it is divisible by 400
    if(((year%4==0) && (year%100!=0)) || (year%400==0)) 
        return 1;
    else
        return 0;
}
int daysinmonth(int year, int month)
{
    // Thirty days hath September, April, June, and November;
    // All the rest have thirty-one
    // Excepting February alone: Which hath but twenty-eight, in fine,
    // Till leap year gives it twenty-nine.
    int monthlengths[]={31,28,31,30,31,30,31,31,30,31,30,31};
    if ((month==1) && leapyear(year)) return 29;
    else return monthlengths[month];
}
int printmonth(char s[8][32],int year, int month, int firstday)
{
    // print a complete month into the string s
    // firstday gives the number for the first day of the month (0 is sunday)
    char *monthnames[]={"January","February"," March"," April","  May"," June"," July","August","September","October","November","December"};
    int i;
    sprintf(s[0],"         %-8s      ",monthnames[month]); // print month name
    sprintf(s[1],"  Su Mo Tu We Th Fr Sa ");               // print day heading
    for(i=2;i<8;i++)
        strcpy(s[i],"                       ");               // blank week
    for(i=0;i<daysinmonth(year,month);i++)
    {
        sprintf(s[(i+firstday)/7+2]+(i+firstday)%7*3+2,"%2d",i+1); // print day no
        s[(i+firstday)/7+2][(i+firstday)%7*3+4]=' '; // remove string termimator
    }
    return (firstday+i)%7; 
} 
int main(int argc,char *argv[]) {
    int i,j,k;
    int day;
    int year=1999;
    char months[3][8][32]; // array to store three months

	 if(argc==2)
	 	sscanf(argv[1],"%d",&year);
	 else {
      printf("What year would you like a calendar for? ");
      scanf("%d",&year);
    }
    // work out what day of the week the first day of the year is
    // add no of leap years to 365*(year-1)
    day=((year-1)*365+(year-1)/4+(year-1)/400-(year-1)/100+1)%7;
    // print title
    printf("\n                           Calendar for %d\n\n",year);
    for(j=0;j<4;j++)
    {         // print 4 rows of months
        for(i=0;i<3;i++)         // print months into the array
            day=printmonth(months[i],year,i+j*3,day);
        for(i=0;i<8;i++)
        {       // print all 8 rows
            for(k=0;k<3;k++)       // of three months from the array
                printf(months[k][i]);
            puts("");                // return at end of line
        }
    }
    return 0; // success
}
