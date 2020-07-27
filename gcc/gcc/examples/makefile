EXE=hellow.exe glex.exe dining.exe calendar.exe glhw.exe
%.exe : %.c
	gcc  $< -o $@ -Wl,-s -O3
all: $(EXE) massey.scr hellow.exe

clean:
	@del *.exe *.o *.org *.scr *.coff

glmuss.coff: glmuss.rc
	windres glmuss.rc -o glmuss.coff

massey.scr: glmuss.c glmuss.coff
	gcc -Os -Wl,-s -mwindows glmuss.coff glmuss.c -o massey.scr -lscrnsave -ladvapi32
