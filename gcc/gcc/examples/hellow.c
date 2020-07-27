//
//  Simple demo to show that it is possible to write windows programs with this compiler
//  it must be linked using the compiler options -luser32 -lgdi32
//     Martin Johnson 26/10/99
//
#include <stdlib.h>
#include <windows.h>
#include <wingdi.h>   // these are needed because I took them out of windows.h to make console
#include <winuser.h>  // apps compile a bit faster.
#define MAXPTS 1000   // Max no of points in the path
HFONT hfont;          // font to use for the string
int width=510;
int height=150;       // initial size of the window
HDC hdc1;             // used for double buffering
HWND hwnd;            // main window
HBITMAP bm;           // where the string is drawn

//
//  This gets called when something happens to the window e.g. resize or close
//
LRESULT WndProc (HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam) {
   HBITMAP bm1;       // for new bitmap

   switch (message) {
      case WM_SIZE:   // resize window
         width=LOWORD(lParam);    // get new size
         height = HIWORD(lParam);
         bm1=CreateCompatibleBitmap(hdc1,width,height);
         SelectObject(hdc1,bm1);  // change size of bitmap
         DeleteObject(bm);        // free up the old one
         bm=bm1;
         break;
      case WM_CLOSE:  // close box
         if(MessageBox(hwnd,"Goodbye Hello World?","Exit",
            MB_OKCANCEL | MB_ICONEXCLAMATION | MB_DEFBUTTON2)==IDCANCEL)
         return 0;
         break;
      case WM_DESTROY: // exit program
         PostQuitMessage(0);
         exit(0);
   }
   return DefWindowProc (hwnd, message, wParam, lParam);
}

//
// Draw a line drawing specified using x,y and z co-ordinates
//
void draw(HDC hdc,int x[],int y[],int z[],int no,int k,BYTE types[]) {
	int i;
	int x1,y1,z1;
	int mx=0,my=0;
	
   Rectangle(hdc,0,0,width,height);   // clear the drawing area
   for(i=0;i<no;i++) {                // look at all the points
      z1=(z[i]>>18)+(590-k)*2+64;     // calculate the z co-ordinate
      if(z1==0) z1=1;                 // stop division by zero
      x1=width/2+((x[i]>>10))/z1;     // calculate x co-ordinate
      y1=height/2+((y[i]>>10))/z1;    // calculate y co-ordinate
      if(types[i]==PT_MOVETO ) {      // is this point a move
         mx=x1;                       // remember moves
         my=y1;                       // so that polygons can be closed
         MoveToEx(hdc,mx,my,0);       // do the move
      }
      if(types[i]&PT_LINETO)          // is this the endpoint of a line
         LineTo(hdc,x1,y1);           // draw to this point
      if(types[i]&PT_CLOSEFIGURE)     // was this the last point in a polygon
         LineTo(hdc,mx,my);           // if so, draw a line to the first point
      z[i]=z[i]-((x[i]+y[i])>>6);     // spin by using z=z-(x+y)/64
      x[i]=x[i]+(z[i]>>6)+k;          // x=x+z/64
      y[i]=y[i]+(z[i]>>6);            // y=y+z/64
   }
}	
//
// Do some horrible windows initialisation stuff, not nice but needs to be done.
//
HDC initialise(HINSTANCE hInstance, HINSTANCE hPrevInstance,int nCmdShow) {
	static char szAppName[] = "hellow"; // application name
	WNDCLASS wc= {                      // class info
      0,(WNDPROC)WndProc,0,0,hInstance, LoadIcon( NULL, IDI_APPLICATION ),
      LoadCursor(NULL, IDC_ARROW),(HBRUSH)(COLOR_WINDOW+1),0,szAppName };
      
   if (!hPrevInstance)                 // register the new class
      RegisterClass (&wc) ;
   // find the font - anything 100 pixels high will do, usually uses Arial.
   hfont=CreateFont(100,0,0,0,0,0,0,0,DEFAULT_CHARSET,OUT_DEFAULT_PRECIS,
                    CLIP_DEFAULT_PRECIS,DEFAULT_QUALITY,DEFAULT_PITCH | FF_DONTCARE,"Arial");
   // create the window
   hwnd=CreateWindow (szAppName,"Hello World",WS_OVERLAPPEDWINDOW,0,0,width,height,
                        NULL,NULL,hInstance,NULL) ;
   ShowWindow(hwnd, nCmdShow); // make the window visible

   return GetDC(hwnd);  // return something we can use to draw on
}

//
//  main function 
//
int PASCAL WinMain (HINSTANCE hInstance, HINSTANCE hPrevInstance,LPSTR lpszCmd, int nCmdShow) {

   HDC hdc;                  // device context to draw into
   POINT points[MAXPTS];     // data structure to put the text path in
   int x[MAXPTS],y[MAXPTS],z[MAXPTS]; // x, y and z co-ordinates of the line drawing
   BYTE types[MAXPTS];          // type of each point
   int i,k,no;

   MSG msg;                     // for windows messages
   SIZE size;                   // for the size of the text
   char *string;
   
   string="Hello World ";  // default text

   if (strlen(lpszCmd)) string=lpszCmd;  // if run with a parameter use this instead 
   hdc=initialise(hInstance,hPrevInstance,nCmdShow); // register class, create window and font
   SelectObject(hdc,hfont);              // use this font
   GetTextExtentPoint32(hdc,string,strlen(string),&size); // find size of text
   BeginPath(hdc);
   TextOut(hdc,20,20,string,strlen(string));  // draw text into a path
   EndPath(hdc);
   FlattenPath(hdc);                     // convert to lines
   no=GetPath(hdc,points,types,MAXPTS);  // get co-ordinates
   hdc1=CreateCompatibleDC(hdc);         // create double buffer
   bm=CreateCompatibleBitmap(hdc,width,height);    // with bitmap
   SelectObject(hdc1,GetStockObject(WHITE_BRUSH)); // for clearing the background
   SelectObject(hdc1,GetStockObject(BLACK_PEN));   // for drawing lines
   SelectObject(hdc1,bm);                          // for drawing on
   while(1) {
      for(i=0;i<no;i++) {
         z[i]=0;
         x[i]=(points[i].x-size.cx/2)<<16;   // convert points to x,y and z co-ordinates.
         y[i]=(points[i].y-size.cy/2)<<16;
      }
      for(k=0;k<600;k++) {
			draw(hdc1,x,y,z,no,k,types);    // draw lines and rotate each point
         BitBlt(hdc,0,0,width,height,hdc1,0,0,SRCCOPY); // copy to screen
         while(PeekMessage(&msg,hwnd,0,0,PM_REMOVE))
            DispatchMessage(&msg);       // handle any windows messages e.g. close
      }
   }
   return (0);  // FIN
}
