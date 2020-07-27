//
//  Massey University Screen Saver
//  Compile this using the makefile and copy massey.scr to your windows directory
//
#include <stdio.h>
#include <windows.h>
#include <GL/glut.h>
#include <math.h>
#include <stdlib.h>
#include <scrnsave.h>

struct colorIndexState {
   GLfloat amb[3];  /* ambient color / bottom of ramp */
   GLfloat diff[3]; /* diffuse color / middle of ramp */
   GLfloat spec[3]; /* specular color / top of ramp */
   GLfloat ratio;   /* ratio of diffuse to specular in ramp */
   GLint indexes[3];   /* where ramp was placed in palette */
};

#define NUM_COLORS (sizeof(colors) / sizeof(colors[0]))

struct colorIndexState colors[] = {
 { { 94.0F/255, 94.0F/255, 94.0F/255 },
 	{ 1.0F, 1.0F, 1.0F },
 	{ 1.0F, 1.0F, 1.0F }, 0.75F,
 	{ 0, 0, 0 },
 },
 { { 0.0F, 49.0/255, 94.0/255 },
 	{ 16.0/255, 143.0/255, 255.0/255},
 	{ 225/255.0F, 241/255.0F, 1.0F }, 0.75F,
 	{ 0, 0, 0 },
 	/*
 	 { { 36.0/255, 117.0/255, 153.0/255 },
 	{ 18.0/255, 30.0/255, 51.0/255},
 	{ 230.0/255, 230.0/255, 1.0F }, 0.75F,
 	{ 0, 0, 0 },
 	*/
 	

 }
};

/* Windows globals, defines, and prototypes */
HGLRC hRC = (HGLRC) 0;
HDC hDC = (HDC) 0;
HDC hdc1;
HPALETTE hPalette = (HPALETTE) 0;
int nWndSize = 300;
float step;
float explode=5;
int width=800,height=600;
GLfloat clearcolour;
const int steps=72;


UINT nTimerID = 101;

#define PI 3.1415926
#define REFSPEED 50 // screen refresh speed (ms)
void setupPixelFormat(HDC);

GLdouble radius;

GLvoid resize(GLsizei, GLsizei);
GLvoid initializeGL(GLsizei, GLsizei);
GLvoid drawScene(GLvoid);
void setupPalette(HDC hDC) {
   PIXELFORMATDESCRIPTOR pfd;
   LOGPALETTE* pPal;
   PALETTEENTRY *pe;
   int rampBase,pixelFormat,paletteSize,numRamps,rampSize,extra,diffSize,specSize;
   int i, r;

   pixelFormat=GetPixelFormat(hDC);
   DescribePixelFormat(hDC, pixelFormat, sizeof(PIXELFORMATDESCRIPTOR), &pfd);
   if (pfd.dwFlags & PFD_NEED_PALETTE ||
       pfd.iPixelType == PFD_TYPE_COLORINDEX) {
      paletteSize = 1 << pfd.cColorBits;
      if (paletteSize > 4096 || paletteSize==1) {
         paletteSize = 4096;
      }
   }
   else {
      return;
   }
   pPal = (LOGPALETTE*)
   malloc(sizeof(LOGPALETTE) + paletteSize * sizeof(PALETTEENTRY));
   pPal->palVersion = 0x300;
   pPal->palNumEntries = paletteSize;

   GetSystemPaletteEntries(hDC, 0, paletteSize, &pPal->palPalEntry[0]);
   numRamps = NUM_COLORS;
   rampSize = (paletteSize - 20) / numRamps;
   extra = (paletteSize - 20) - (numRamps * rampSize);

   for (r=0; r<numRamps; ++r) {
      rampBase = r * rampSize + 10;
      pe = &pPal->palPalEntry[rampBase];
      diffSize = (int) (rampSize * colors[r].ratio);
      specSize = rampSize - diffSize;

      for (i=0; i<rampSize; ++i) {
         GLfloat *c0, *c1;
         GLint a;

         if (i < diffSize) {
            c0 = colors[r].amb;
            c1 = colors[r].diff;
            a = (i * 255) / (diffSize - 1);
         }
         else {
            c0 = colors[r].diff;
            c1 = colors[r].spec;
            a = ((i - diffSize) * 255) / (specSize - 1);
         }

         pe[i].peRed = (BYTE) (a * (c1[0] - c0[0]) + 255 * c0[0]);
         pe[i].peGreen = (BYTE) (a * (c1[1] - c0[1]) + 255 * c0[1]);
         pe[i].peBlue = (BYTE) (a * (c1[2] - c0[2]) + 255 * c0[2]);
         pe[i].peFlags = PC_NOCOLLAPSE;
      }

      colors[r].indexes[0] = rampBase;
      colors[r].indexes[1] = rampBase + (diffSize-1);
      colors[r].indexes[2] = rampBase + (rampSize-1);
   }
   for (i=0; i<extra; ++i) {
      int index = numRamps*rampSize+10+i;
      clearcolour=(GLfloat)index;
      PALETTEENTRY *pe = &pPal->palPalEntry[index];

      pe->peRed = (BYTE) 0;
      pe->peGreen = (BYTE) 0;
      pe->peBlue = (BYTE) 0;
      pe->peFlags = PC_NOCOLLAPSE;
   }


   hPalette = CreatePalette(pPal);
   free(pPal);

   if (hPalette) {
      SelectPalette(hDC, hPalette, FALSE);
      RealizePalette(hDC);
   }
}
static void initLights( void ) {  // initializes light and material properties
   GLfloat white[] = {1.0, 1.0,1.0, 1.0};
   GLfloat black[] = {0.1, 0.1, 0.1, 1.0};
   GLfloat light_ambient[] = {1.0, 1.0, 1.0, 1.0};
   GLfloat light_diffuse[] = {1.0, 1.0, 1.0, 1.0};
   GLfloat light_specular[] = {1.0, 1.0, 1.0, 1.0};
   GLfloat light_position[] = {.7, .7, 1.25, 1.0};
   GLfloat mat_shininess[] = {30.0};

   glEnable(GL_LIGHTING);   // enables lighting
   glEnable(GL_LIGHT0);     // enables light source 0

   glLightModelfv(GL_LIGHT_MODEL_TWO_SIDE,(float[]){GL_FALSE});
   glLightfv(GL_LIGHT0, GL_AMBIENT,light_ambient);
   glLightfv(GL_LIGHT0, GL_DIFFUSE,light_diffuse);
   glLightfv(GL_LIGHT0, GL_SPECULAR,light_specular);
   glLightfv(GL_LIGHT0, GL_POSITION, light_position);
   glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, black); //mat_ambient);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, white); //mat_specular);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, mat_shininess);
}

int noclose=0;

LRESULT WINAPI ScreenSaverProc(HWND  hWnd,UINT  message, WPARAM  wParam, LPARAM  lParam) {
   static HWND hChild = NULL;
   HINSTANCE hInst = hMainInstance;
   WNDCLASS wc;
            RECT rect;
		DEVMODE dmScreenSettings;								// Device Mode

   int i,j,k;
   switch (message) {
      case WM_CREATE:
      /*
      noclose=1;
      memset(&dmScreenSettings,0,sizeof(dmScreenSettings));	// Makes Sure Memory's Cleared
		dmScreenSettings.dmSize=sizeof(dmScreenSettings);		// Size Of The Devmode Structure
		dmScreenSettings.dmPelsWidth	= 640;				// Selected Screen Width
		dmScreenSettings.dmPelsHeight	= 480;				// Selected Screen Height
		dmScreenSettings.dmBitsPerPel	= 16;					// Selected Bits Per Pixel
		dmScreenSettings.dmFields=DM_BITSPERPEL|DM_PELSWIDTH|DM_PELSHEIGHT;
     
		// Try To Set Selected Mode And Get Results.  NOTE: CDS_FULLSCREEN Gets Rid Of Start Bar.
		ChangeDisplaySettings(&dmScreenSettings,4); //!=DISP_CHANGE_SUCCESSFUL
		*/
         hDC = GetDC(hWnd);
         setupPixelFormat(hDC);
         setupPalette(hDC);
         hRC = wglCreateContext(hDC);
         wglMakeCurrent(hDC, hRC);
         GetClientRect(hWnd, &rect);
 //        rect.right=640;
 //        rect.bottom=480;
         initializeGL(rect.right, rect.bottom);
         width=rect.right;
         height=rect.bottom;
         step=0;
         SetTimer(hWnd, nTimerID,REFSPEED,NULL);
         break;     
      case WM_PALETTECHANGED:
         if (hRC && hPalette && (HWND) wParam != hWnd) {
            UnrealizeObject(hPalette);
            SelectPalette(hdc1, hPalette, FALSE);
            RealizePalette(hdc1);
            return 0;
         }
         break;
      case WM_QUERYNEWPALETTE:
         if (hRC && hPalette) {
            UnrealizeObject(hPalette);
            SelectPalette(hdc1, hPalette, FALSE);
            RealizePalette(hdc1);
            return TRUE;
         }
         break;
      case WM_DESTROY:
         KillTimer(hWnd, nTimerID);
         DestroyWindow(hChild);
         PostQuitMessage(0);
         break;
      case WM_TIMER:
         drawScene();
         SwapBuffers(hDC);
         step+=.05;
         if(((int)(step*20))%300==0) explode=10;
         noclose=0;
         break;
      case WM_CLOSE:
         if (noclose) return 0;
      default:
         return DefScreenSaverProc(hWnd, message, wParam, lParam);
   }
   return 0;
}

void setupPixelFormat(HDC hDC) {
   PIXELFORMATDESCRIPTOR pfd = {
      sizeof(PIXELFORMATDESCRIPTOR),1,PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER,
      PFD_TYPE_COLORINDEX,8,0,0,0,0,0,0,0,0,0,0,0,0,0,8,0,0,PFD_MAIN_PLANE,0,0,0,0
   };
   int SelectedPixelFormat;
   BOOL retVal;

   SelectedPixelFormat = ChoosePixelFormat(hDC, &pfd);
   if (SelectedPixelFormat == 0)
      exit(1);
   retVal = SetPixelFormat(hDC, SelectedPixelFormat, &pfd);
   if (retVal != TRUE)
      exit(1);
}

double dist(double a,double b,double c) {
   return sqrt(a*a+b*b+c*c);
}

unsigned seed=7652;

int myrand() { // pick a random number
   seed=(seed*2416+374441)%1771875;
   return seed;
}


GLvoid createObjects(float offset) {
   int i,k;
   const int w=20;
   const int pts=13;
   double xoffset,yoffset,zoffset;
   double sq[][3]= { {100,100,0}, {100-w,100,0}, {-100+w,100,0}, {-100,100,0}, {-100,100-w,0}, {-100,-100+w,0}, {-100,-100,0}, {-100+w,-100,0}, {100-w,-100,0}, {100,-100,0}, {100,-100+w,0}, {100,100-w,0}, {100,100,0}
   };
   double sq1[pts][3];
   double sq2[pts][3];
   double n[pts][3];
   double x1;
   double sum;
   double th,x,phi,cth,sth,cphi,sphi,y,z;
   int j;
   seed=567;

   offset=(exp(offset)-1)/20.0;

   glNewList(1, GL_COMPILE);
   glShadeModel(GL_FLAT);
   for(i=0;i<steps+1;i++) {
      th=(i*2*PI/steps); // angle
      cth=cos(th);
      sth=sin(th);
      phi=-(i*1.5*PI)/steps; // twist
      cphi=cos(phi);
      sphi=sin(phi);
      xoffset=offset*cth+(myrand()%100)/200.0*offset;
      yoffset=offset*sth+(myrand()%100)/200.0*offset;
      zoffset=offset*sth+(myrand()%100)/200.0*offset;
      for(j=0;j<pts;j++) {
         x=sq[j][0];
         y=sq[j][1];
         z=sq[j][2];
         x1=cphi*x-sphi*y;
         y=cphi*y+sphi*x;
         x=x1+300;
         n[j][0]=cth*x1-sth*z+xoffset;
         n[j][2]=y;
         n[j][1]=cth*z+sth*x1+yoffset;
         sq1[j][0]=(cth*x-sth*z)/600;
         sq1[j][2]=y/600;
         sq1[j][1]=(cth*z+sth*x)/600;
      }
      glBegin(GL_QUAD_STRIP);
      if(i!=0)
         for (j=0; j<pts; j++) {
            if(((j+1)%3)==0 && !((j<pts-1) && (i%3==0) && (((j*4)/(pts-1))==i/(steps/3) ||
              ((((j*4)/(pts-1))+2)%4)==i/(steps/3))))
            	glMaterialiv(GL_FRONT, GL_COLOR_INDEXES, colors[1].indexes);
            else
               glMaterialiv(GL_FRONT, GL_COLOR_INDEXES, colors[0].indexes);
            sum=dist(n[j][0], n[j][1], n[j][2]);
            glNormal3f(n[j][0]/sum, n[j][1]/sum, n[j][2]/sum);
            glVertex3f(sq1[j][0]+xoffset, sq1[j][1]+yoffset, sq1[j][2]+zoffset);
            glVertex3f(sq2[j][0]+xoffset, sq2[j][1]+yoffset, sq2[j][2]+zoffset);
         }
      glEnd();
      for(j=0;j<pts;j++)
         for(k=0;k<3;k++)
            sq2[j][k]=sq1[j][k];
   }
   glEndList();
}

GLvoid initializeGL(GLsizei width, GLsizei height) {
   GLfloat     maxObjectSize, aspect;
   GLdouble    near_plane, far_plane;

   glClearIndex((GLfloat) clearcolour);


   glEnable(GL_DEPTH_TEST);
   glMatrixMode( GL_PROJECTION );
   aspect = (GLfloat) width / height;
   gluPerspective( 45.0, aspect, 1.0, 200.0 );
   glMatrixMode( GL_MODELVIEW );
   near_plane = 3.0;
   far_plane = 10.0;
   maxObjectSize = 3.0F;
   radius = near_plane + maxObjectSize/2.0;
   createObjects(explode);
   initLights();
   glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );

}
void translateit() {
	 glTranslatef(2.5 * width / height * sin(step * 1.11)/3, 2.5 *
                     cos(step * 1.25 * 1.11)/3,   -5-2.5 *
                     sin(step * 1.25 * 1.11)  );

        glRotatef(step * 100, 1, 0, 0);
        glRotatef(step * 95, 0, 1, 0);
        glRotatef(step * 90, 0, 0, 1);
}


GLvoid drawScene(GLvoid) {
   glClear( GL_COLOR_BUFFER_BIT  | GL_DEPTH_BUFFER_BIT );
   glPushMatrix();
   translateit();
   if(explode>0) {
     explode-=.2;
     if(explode<.1) explode=0;
     if(explode>5)
       createObjects(10-explode);
     else
       createObjects(explode);
   }

   glCallList(1);
   glPopMatrix();
}

BOOL WINAPI ScreenSaverConfigureDialog (HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam) {
   switch (message) {
      case WM_INITDIALOG:
      return TRUE;
      break;
      case WM_COMMAND:
      switch (LOWORD(wParam)) {
         case IDOK:
         EndDialog(hDlg, TRUE);
         break;
         default:
         break;
      }
      return TRUE;
      break;
      default:
      return 0;
      break;
   }
   return 0;
}


BOOL WINAPI RegisterDialogClasses(HANDLE hInst) {
   return TRUE;
}



