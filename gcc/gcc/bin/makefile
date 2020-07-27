all: gcc.exe install.exe
	@echo Finished
gcc.exe: gcc.c install.exe
	g++ gcc.c -o gcc.exe -Wl,-s -Os -ladvapi32
	install
install.exe: install.c
	g++ install.c -o install.exe -Wl,-s -Os -ladvapi32
clean:
	del install.exe
	del gcc.exe
	