@echo off
del options > NUL
echo General Compiler Options >> options
g++ --help >> options
echo C Preprocessor Options >> options
..\lib\gcc-lib\cpp0 --help >> options
echo C++ Options >> options
..\lib\gcc-lib\cc1plus --help >> options
echo Assembler Options >> options
as --help >> options
echo Linker Options >> options
ld --help >> options
echo Make Options >> options
make --help >> options
jfe options