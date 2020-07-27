/*
* Example of a Win32 OpenGL program.
* must be linked using -lglu32 -lopengl32 -lgdi32 -luser32
*/
#include <windows.h>
#include <gl\glut.h>
#include <math.h>

/* Windows globals, defines, and prototypes */
CHAR szAppName[]="Win OpenGL";
HWND  ghWnd;
HDC   ghDC;
HGLRC ghRC;


#define SWAPBUFFERS SwapBuffers(ghDC)

#define WIDTH           300
#define HEIGHT          200

LONG WINAPI MainWndProc (HWND, UINT, WPARAM, LPARAM);
BOOL bSetupPixelFormat(HDC);

/* OpenGL globals, defines, and prototypes */
GLfloat latitude, longitude, latinc, longinc;
GLdouble radius;

#define GLOBE    1
#define CYLINDER 2
#define CONE     3

GLvoid resize(GLsizei, GLsizei);
GLvoid initializeGL(GLsizei, GLsizei);
GLvoid drawScene(GLvoid);
void polarView( GLdouble, GLdouble, GLdouble, GLdouble);
static void initLights( void )
// initializes light and material properties
{
   // variables defining light source properties
   GLfloat light_ambient[] =
   {1.0, 1.0, 0.0, 1.0};
   GLfloat light_diffuse[] =
   {0.8, 0.8, 0.8, 1.0};
   GLfloat light_position[] =
   {1.0, 1.0, 2.0, 1.0};

   // variables defining the material properties
   GLfloat mat_diffuse[] =
   {1.0, 1.0, 1.0, 1.0};
   GLfloat mat_specular[] =
   {1.0, 1.0, 1.0, 1.0};
   GLfloat mat_shininess[] =
   {50.0};

   glEnable(GL_LIGHTING);   // enables lighting
   glEnable(GL_LIGHT0);     // enables light source 0

   // calls initializing the light source information
   glLightfv(GL_LIGHT0, GL_AMBIENT, light_ambient);
   glLightfv(GL_LIGHT0, GL_POSITION,light_position);
   glLightfv(GL_LIGHT0, GL_DIFFUSE, light_diffuse);

   // calls initializing the material information
   glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, mat_diffuse);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SPECULAR, mat_specular);
   glMaterialfv(GL_FRONT_AND_BACK, GL_SHININESS, mat_shininess);

}
int WINAPI WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
   MSG        msg;
   WNDCLASS   wndclass;

   wndclass.style         = 0;
   wndclass.lpfnWndProc   = (WNDPROC)MainWndProc;
   wndclass.cbClsExtra    = 0;
   wndclass.cbWndExtra    = 0;
   wndclass.hInstance     = hInstance;
   wndclass.hIcon         = LoadIcon (hInstance, szAppName);
   wndclass.hCursor       = LoadCursor (NULL,IDC_ARROW);
   wndclass.hbrBackground = (HBRUSH)(COLOR_WINDOW+1);
   wndclass.lpszMenuName  = szAppName;
   wndclass.lpszClassName = szAppName;

   if (!RegisterClass (&wndclass) )
      return FALSE;
   ghWnd = CreateWindow (szAppName,
                         "Generic OpenGL Sample",
                         WS_OVERLAPPEDWINDOW | WS_CLIPSIBLINGS | WS_CLIPCHILDREN,
                         CW_USEDEFAULT,
                         CW_USEDEFAULT,
                         WIDTH,
                         HEIGHT,
                         NULL,
                         NULL,
                         hInstance,
                         NULL);
   if (!ghWnd)
      return FALSE;
   ShowWindow (ghWnd, nCmdShow);
   UpdateWindow (ghWnd);
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
LONG WINAPI MainWndProc (
HWND    hWnd,
UINT    uMsg,
WPARAM  wParam,
LPARAM  lParam)
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

/* OpenGL code */

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
GLint ell;
GLvoid createObjects()
{
   GLUquadricObj *quadObj;

   glNewList(CONE, GL_COMPILE);
   glPushMatrix ();
   quadObj = gluNewQuadric ();
   gluQuadricDrawStyle (quadObj, GLU_FILL);
   gluQuadricNormals (quadObj, GLU_SMOOTH);
   glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, (GLfloat[]){1.0,0.0,0.0,1.0});
   gluCylinder(quadObj, 0.3, 0.0, 0.6, 15, 10);
   gluQuadricOrientation(quadObj,GLU_INSIDE);
   gluDisk(quadObj,0.0,0.3,15,2);
   gluQuadricOrientation(quadObj,GLU_OUTSIDE);
   glTranslatef ((GLfloat)-0.6, (GLfloat)0.2, (GLfloat)-0.6);
   glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, (GLfloat[]){1.0,0.0,1.0,1.0});
   gluSphere(quadObj,0.4,20,20);
   glPopMatrix ();
   glEndList();
   glNewList(CYLINDER, GL_COMPILE);
   glPushMatrix ();
   glRotatef ((GLfloat)90.0, (GLfloat)1.0, (GLfloat)0.0, (GLfloat)0.0);
   glTranslatef ((GLfloat)0.0, (GLfloat)0.0, (GLfloat)-1.0);
   quadObj = gluNewQuadric ();
   gluQuadricDrawStyle (quadObj, GLU_FILL);
   gluQuadricNormals (quadObj, GLU_SMOOTH);
   glMaterialfv(GL_FRONT_AND_BACK, GL_DIFFUSE, (GLfloat[]){0.0,0.0,1.0,1.0});
   gluCylinder (quadObj, 0.3, 0.3, 0.6, 12, 2);
   gluQuadricOrientation(quadObj,GLU_INSIDE);
   gluDisk(quadObj,0.0,0.3,12,2);
   gluQuadricOrientation(quadObj,GLU_OUTSIDE);
   glTranslatef(0.0,0.0,0.6);
   gluDisk(quadObj,0.0,0.3,12,2);
   glPopMatrix ();
   glEndList();
}


GLvoid initializeGL(GLsizei width, GLsizei height)
{
   GLfloat     maxObjectSize, aspect;
   GLdouble    near_plane, far_plane;

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
   glCallList(CONE);
   glTranslatef(0.8F, -0.65F, 0.0F);
   glRotatef(30.0F, 1.0F, 0.5F, 1.0F);
   glCallList(CYLINDER);
   glPopMatrix();
   SWAPBUFFERS;
}
