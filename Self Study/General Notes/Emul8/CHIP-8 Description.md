since we want to mimic CHIP-8 Components we need to understand them first
## 16 8-bit Registers
CHIP-8 Has a 16 register that are like that
```
V0  V1  V2  V3
V4  V5  V6  V7
V8  V9  VA  VB
VC  VD  VE  VF
```
each one of them store 8-bit a value from `0x00` to `0xFF` (0 to 255)
### Why exactly 8-bit
```
8 bits =  1 byte
00000000  →  0x00  =  0
11111111  →  0xFF  =  255
```
that mean each register can store a value from 0 to 255
### VF - The Flag Register
The `VF` Register is not used to store normal data it responsible to flag unusual behaviors for Example **overflow**, **underflow** and **sprite bugs** it simply answer the question what happened  so in case a something need to be adjusted happen like an operation output number bigger than what your registers can hold then the VF notify your program to go adjust this value to the max value
#### Example
```
V1 = 0xFF (255)
V2 = 0x01 (1)

ADD V1, V2 = 256
```
you cant store number bigger than 255 so 
```
V1 = 0x00
VF = 1 -> It indicate overflow happens
```
You might think of it as a **logger** but not really it does not log for you or tell you that an error happen it tell your code and your code should be the one that making sure everything working fine
