/*
* Example of a Win32 OpenGL program.
* 
*/
#include <stdio.h>
#include <windows.h>
#include <GL/glut.h>

/* Windows globals, defines, and prototypes */
CHAR szAppName[]="Win OpenGL Hello World";
HWND  ghWnd;
HDC   ghDC;
HGLRC ghRC;

#define SWAPBUFFERS SwapBuffers(ghDC)

#define WIDTH 400
#define HEIGHT 400
#define MAXPTS 8000
#define STRING 1
#define FRONTred 1.0
#define FRONTgreen 0.0
#define FRONTblue 0.0
#define BACKred 0.75164
#define BACKgreen 0.60648
#define BACKblue 0.22648
#define BACKCOLOR (GLfloat[]){BACKred,BACKgreen,BACKblue,1.0}
#define FRONTCOLOR (GLfloat[]){FRONTred,FRONTgreen,FRONTblue,1.0}

HFONT hfont;

POINT points[MAXPTS];     // data structure to put the text path in
BYTE types[MAXPTS];
GLfloat data[MAXPTS][2];
SIZE size;
int no;
int m=1;

char *string="Hello World";
  
LONG WINAPI MainWndProc (HWND, UINT, WPARAM, LPARAM);
BOOL bSetupPixelFormat(HDC);

/* OpenGL globals, defines, and prototypes */
GLfloat latitude, longitude, latinc, longinc;
GLdouble radius;
 
GLvoid resize(GLsizei, GLsizei);
GLvoid initializeGL(GLsizei, GLsizei);
GLvoid drawScene(GLvoid);
void polarView( GLdouble, GLdouble, GLdouble, GLdouble);


static void initLights( void )
{  // initializes light and material properties
   // variables defining light source properties
   // 0.24725, 0.1995, 0.0745,
   //   0.75164, 0.60648, 0.22648, 0.628281, 0.555802, 0.366065, 0.4);


   GLfloat light_position[] =  {1.0, 1.0, 2.0, 1.0};

   // variables defining the material properties

   GLfloat white[] = {1.0, 1.0, 1.0, 1.0};
   GLfloat grey[] = {0.2, 0.2, 0.2, 1.0};


   GLfloat mat_shininess[] = {0.4*128};

   glEnable(GL_LIGHTING);   // enables lighting
   glEnable(GL_LIGHT0);     // enables light source 0
   
   glLightModelfv(GL_LIGHT_MODEL_TWO_SIDE,(float[]){GL_TRUE});

   // calls initializing the light source information
   glLightfv(GL_LIGHT0, GL_AMBIENT, white);// light_ambient);
   glLightfv(GL_LIGHT0, GL_POSITION,  light_position);
   glLightfv(GL_LIGHT0, GL_DIFFUSE, white);// light_diffuse);

   // calls initializing the material information
   glMaterialfv(GL_FRONT_AND_BACK, GL_AMBIENT, grey); //mat_ambient);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, white); //mat_specular);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, mat_shininess);
   glMaterialfv(GL_BACK, GL_DIFFUSE, BACKCOLOR);
   glMaterialfv(GL_FRONT, GL_DIFFUSE, FRONTCOLOR);

}
int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
   MSG        msg;
   WNDCLASS   wndclass={                      // class info
      0,(WNDPROC)MainWndProc,0,0,hInstance, LoadIcon( NULL, IDI_APPLICATION ),
      LoadCursor(NULL, IDC_ARROW),(HBRUSH)(COLOR_WINDOW+1),0,szAppName };

   if (strlen(lpCmdLine)) string=lpCmdLine;
   if (!RegisterClass (&wndclass) )
      return FALSE;
   ghWnd = CreateWindow (szAppName,"Hello World", WS_OVERLAPPEDWINDOW | WS_CLIPSIBLINGS | WS_CLIPCHILDREN,
                 CW_USEDEFAULT,CW_USEDEFAULT,WIDTH,HEIGHT,NULL,NULL,hInstance,NULL);
   if (!ghWnd)
      return FALSE;
   ShowWindow (ghWnd, nCmdShow);
   while (1)
   {
      while (PeekMessage(&msg, NULL, 0, 0, PM_NOREMOVE) == TRUE)
      {
         if (GetMessage(&msg, NULL, 0, 0) )
         {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
         }
         else
         {
            return TRUE;
         }
      }
      drawScene();
   }
}

/* main window procedure */
LONG WINAPI MainWndProc (HWND    hWnd,UINT    uMsg,WPARAM  wParam,LPARAM  lParam)
{
   LONG    lRet = 1;
   PAINTSTRUCT    ps;
   RECT rect;

   switch (uMsg)
   {
      case WM_CREATE:
         ghDC = GetDC(hWnd);
         if (!bSetupPixelFormat(ghDC))
            PostQuitMessage (0);
         ghRC = wglCreateContext(ghDC);
         wglMakeCurrent(ghDC, ghRC);
         GetClientRect(hWnd, &rect);
         initializeGL(rect.right, rect.bottom);
         break;
      case WM_PAINT:
         BeginPaint(hWnd, &ps);
         EndPaint(hWnd, &ps);
         break;
      case WM_SIZE:
         GetClientRect(hWnd, &rect);
         resize(rect.right, rect.bottom);
         break;
      case WM_CLOSE:
         if (ghRC)
            wglDeleteContext(ghRC);
         if (ghDC)
            ReleaseDC(hWnd, ghDC);
         ghRC = 0;
         ghDC = 0;
         DestroyWindow (hWnd);
         break;
      case WM_DESTROY:
         if (ghRC)
            wglDeleteContext(ghRC);
         if (ghDC)
            ReleaseDC(hWnd, ghDC);
         PostQuitMessage (0);
         break;
      case WM_KEYDOWN:
         switch (wParam)
         {
            case VK_LEFT:
               longinc += 0.5F;
               break;
            case VK_RIGHT:
               longinc -= 0.5F;
               break;
            case VK_UP:
               latinc += 0.5F;
               break;
            case VK_DOWN:
               latinc -= 0.5F;
               break;
         }
      default:
         lRet = DefWindowProc (hWnd, uMsg, wParam, lParam);
         break;
   }
   return lRet;
}

BOOL bSetupPixelFormat(HDC hdc)
{
   PIXELFORMATDESCRIPTOR  *ppfd;
   HPALETTE m_hPalette;
   int pixelformat;
   PIXELFORMATDESCRIPTOR pfd = {
      sizeof(PIXELFORMATDESCRIPTOR),1,PFD_DRAW_TO_WINDOW |PFD_SUPPORT_OPENGL |PFD_DOUBLEBUFFER,   
      PFD_TYPE_RGBA,24,0, 0, 0, 0, 0, 0, 0,0,
      0,0, 0, 0, 0,32,0,0,PFD_MAIN_PLANE,0,0, 0, 0
   };
	int i;
	struct	{		WORD VersionNumber;
		WORD NumberOfEntries;
		PALETTEENTRY PalEntryArr[256];
	} MyPalette = { 0x300, 256};
   pfd.cColorBits = GetDeviceCaps(ghDC,BITSPIXEL);
   ppfd = &pfd;
   pixelformat = ChoosePixelFormat(hdc, ppfd);
   SetPixelFormat(hdc, pixelformat, ppfd);
   DescribePixelFormat(hdc,pixelformat,sizeof(pfd),&pfd);
	if(pfd.dwFlags & PFD_NEED_PALETTE) {
		for(i=0;i<256;i++) {
		   MyPalette.PalEntryArr[i].peRed=((i&7)<<5);
	   	MyPalette.PalEntryArr[i].peGreen=((i&0x38)*4);
	   	MyPalette.PalEntryArr[i].peBlue=(i&0xc0);
		}
		m_hPalette = CreatePalette ((LOGPALETTE*) &MyPalette);  
		SelectPalette(hdc,m_hPalette,0);
   	RealizePalette(hdc);
	}
   return TRUE;
}

GLvoid resize( GLsizei width, GLsizei height )
{
   GLfloat aspect;

   glViewport( 0, 0, width, height );

   aspect = (GLfloat) width / height;

   glMatrixMode( GL_PROJECTION );
   glLoadIdentity();
   gluPerspective( 45.0, aspect, 3.0, 7.0 );
   glMatrixMode( GL_MODELVIEW );
}

GLvoid createObjects()
{
   int i,n=0;
   static GLUtriangulatorObj *tobj = NULL;
   typedef void(CALLBACK *TING)(void);
   GLdouble vertex[3];
   double x1,y1;

   if (tobj == NULL) {
    tobj = gluNewTess(); 
    gluTessCallback(tobj, GLU_BEGIN, (TING)(glBegin));
    gluTessCallback(tobj, GLU_VERTEX,  (TING)(glVertex2fv));  /* semi-tricky */
    gluTessCallback(tobj, GLU_END,  (TING)(glEnd));
  }
  glNewList(STRING, GL_COMPILE);
  gluBeginPolygon(tobj);
   for(i=0;i<no;i++) {
	   x1=(points[i].x-size.cx/2)/120.0;
	   y1=(points[i].y-size.cy/2)/120.0;
		vertex[0] = x1;
      vertex[1] = y1;
      vertex[2] = 0;
      data[n][0]=x1;
      data[n++][1]=y1;
      gluTessVertex(tobj, vertex, data[n-1]);
      if((types[i]&PT_CLOSEFIGURE)) 
			gluNextContour(tobj, GLU_UNKNOWN);
	}
  gluEndPolygon(tobj);
  glEndList();
}


GLvoid initializeGL(GLsizei width, GLsizei height)
{
   GLfloat     maxObjectSize, aspect;
   GLdouble    near_plane, far_plane;
	HDC hdc;                  // device context to draw into

   glClearColor(0.0, 0.0, 0.0, 0.0);
   glEnable(GL_DEPTH_TEST);
   glMatrixMode( GL_PROJECTION );
   aspect = (GLfloat) width / height;
   gluPerspective( 45.0, aspect, 3.0, 7.0 );
   glMatrixMode( GL_MODELVIEW );

   near_plane = 3.0;
   far_plane = 7.0;
   maxObjectSize = 3.0F;
   radius = near_plane + maxObjectSize/2.0;

   latitude = 0.0F;
   longitude = 0.0F;
   latinc = 6.0F;
   longinc = 2.5F;
   hdc=ghDC;
   hfont=CreateFont(100,0,0,0,0,0,0,0,DEFAULT_CHARSET,OUT_DEFAULT_PRECIS,
                    CLIP_DEFAULT_PRECIS,DEFAULT_QUALITY,DEFAULT_PITCH | FF_DONTCARE,"Times New Roman");
   SelectObject(hdc,hfont);              // use this font
   SetBkMode(hdc, TRANSPARENT); 
   GetTextExtentPoint32(hdc,string,strlen(string),&size); // find size of text
   BeginPath(hdc);
   TextOut(hdc,20,20,string,strlen(string));  // draw text into a path
   EndPath(hdc);
   FlattenPath(hdc);                     // convert to lines
   no=GetPath(hdc,points,types,MAXPTS);  // get co-ordinates
   createObjects();
   initLights();
}

void polarView(GLdouble radius, GLdouble twist, GLdouble latitude,
               GLdouble longitude)
{
   glTranslated(0.0, 0.0, -radius);
   glRotated(-twist, 0.0, 0.0, 1.0);
   glRotated(-latitude, 1.0, 0.0, 0.0);
   glRotated(longitude, 0.0, 0.0, 1.0);

}


GLvoid drawScene(GLvoid)
{
   glClear( GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT );
   glPushMatrix();
   latitude += latinc;
   longitude += longinc;
   polarView( radius, 0, latitude, longitude );
   glPushMatrix();

	glCallList(STRING);
   glPopMatrix();
   glPopMatrix();
   SWAPBUFFERS;
}

