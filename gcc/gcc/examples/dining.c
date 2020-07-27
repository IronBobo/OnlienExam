//
// Dining Philosophers
// Written for 59.305 1999
// By Martin Johnson
//
// m - Eating     T - Thinking      H - Hungry
//
#include <stddef.h>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>

#define semaphore HANDLE

void wait(semaphore h) {     // wait for a semaphore
	WaitForSingleObject( h, MAXLONG);
}

void signal(semaphore h) {   // signal a semaphore
	ReleaseSemaphore(h,1,NULL);
}

semaphore create(int v) {    // create a semaphore with value v
	return CreateSemaphore(NULL,(long)v, MAXLONG, NULL);
}

#define N 5                  /* Number of Philosophers */
#define LEFT(n) (n+N-1)%N    /* Macros to give left */
#define RIGHT(n) (n+1)%N     /* and right around the table */

char p[N];                   /* status of the philosophers */
semaphore s[N];              /* semaphore for each philosopher */
semaphore mutex;             /* semaphore for mutual exclusion */

void pr() {                  /* print current status */
  int i;                     /* H=Hungry T=Thinking */
  for(i=0;i<N;i++) {         /* m=Eating .=Not Started Yet */
    putchar(p[i]);
  }
  puts("");
}

void setp(int no,char c) {   /* Change status of philosopher 'no' */
  p[no]=c;                   /* to 'c' */
  pr();
}

void test(int no) {          /* can philosopher 'no' eat */
  if ((p[no] == 'H') && (p[LEFT(no)] != 'm') && (p[RIGHT(no)] != 'm'))  {
    setp(no,'m');
    signal(s[no]);           /* if so then eat */
  }
}

void take_forks(int no) {    /* get both forks */
  wait(mutex);               /* only one at a time here please */
  setp(no,'H');              /* I am Hungry */
  test(no);                  /* can I eat? */
  signal(mutex);
  wait(s[no]);               /* wait until I can */
}

void put_forks(int no) {     /* put the forks down */
  wait(mutex);               /* only one at a time here */
  setp(no,'T');              /* let me think */
  test(LEFT(no));            /* see if my neighbours can now eat */
  test(RIGHT(no));
  signal(mutex);
}

void * philosopher(int no) { 
  printf("Starting philosopher %d\n", no);
  while(1) {
    Sleep(rand()%100);       /* wait a random time */
    take_forks(no);          /* get the forks */
    Sleep(rand()%100);       /* wait again */
    put_forks(no);           /* put forks down */
  }
  return NULL;
}

int main() {
  HANDLE th[N];
  int i;
  DWORD id;

  mutex=create(1);           /* initialise the semaphores */
  for(i=0;i<N;i++) {
    p[i]='.';                /* and the status */
    s[i]=create(0);
  }
  for(i=0;i<N;i++) {         /* create all the philosopher threads */
   th[i]=CreateThread(NULL,0,(LPTHREAD_START_ROUTINE)philosopher,
   	(int *)i,0,&id);

  }
  Sleep(10000000);            /* sleep for a LONG time */
  return 0;
}
















