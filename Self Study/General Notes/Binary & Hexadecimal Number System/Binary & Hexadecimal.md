## Why Do Computers Use Binary?
Computers are built from billions of tiny switches called **transistors**. A switch has only two states:
- OFF -> `0`
- ON -> `1`
That is Every number, letter, image and sound your computer processes is ultimately a pattern of `0`s and `1`s. This is binary (base-2) number system.
Our everyday number system is decimal (base-10) -- we use 10 digits: `0-9`. Binary only use 2 digits `0`and `1`. Each digit in binary is called a bit.

---
## Understanding Place Values
In decimal, each position is a **power of 10**:
```
1 3 7
│ │ └── 7 × 10⁰ = 7
│ └──── 3 × 10¹ = 30
└────── 1 × 10² = 100
                  ───
                  137
```
In binary, each position is **power of 2**:
```
1 0 1 1
│ │ │ └── 1 × 2⁰ =  1
│ │ └──── 1 × 2¹ =  2
│ └────── 0 × 2² =  0
└──────── 1 × 2³ =  8
                   ──
                   11  (decimal)
```
So binary `1011` = decimal `11`

---
## Decimal <-> Binary Conversion
Decimal -> Binary (Divide by 2, read reminders bottom up)
Lets Convert 25 to binary:
```
25 ÷ 2 = 12  remainder 1  ↑ (LSB - Least Significant Bit)
12 ÷ 2 =  6  remainder 0  ↑
 6 ÷ 2 =  3  remainder 0  ↑
 3 ÷ 2 =  1  remainder 1  ↑
 1 ÷ 2 =  0  remainder 1  ↑ (MSB - Most Significant Bit)

Read bottom to top: 11001
```
25 in decimal = `1101`in binary
Binary -> Decimal (Multiply each by its power of 2)
Lets convert `11001` back:
```
 1×2⁴ + 1×2³ + 0×2² + 0×2¹ + 1×2⁰
= 16  +  8   +  0   +  0   +  1
= 25 
```
C# Code: Decimal <-> Binary
```C#
// Decimal to Binary string
int number = 25;
string binary = Convert.ToString(number, 2);
Console.WriteLine($"{number} in binary = {binary}"); // 11001

// Binary string to Decimal
string binaryStr = "11001";
int backToDecimal = Convert.ToInt32(binaryStr, 2);
Console.WriteLine($"Binary {binaryStr} = {backToDecimal}"); // 25

// Manual bit by bit inspection (very useful in emulators!)
for (int i = 7; i >= 0; i--)
{
    int bit = (number >> i) & 1; // Shift right, isolate last bit
}
// Output: 00011001
```
---
## Hexadecimal (Base-16)
Binary is precise but **hard to read** -- imagine reading `1111 1010 1011 1100`. Hexadecimal (**hex**) is shorthand humans use to represent binary more compactly.

Hex uses 16 digits

| Decimal | Binary | Hex   |
| ------- | ------ | ----- |
| 0       | 0000   | 0     |
| 1       | 0001   | 1     |
| 2       | 0010   | 2     |
| 3       | 0011   | 3     |
| 4       | 0100   | 4     |
| 5       | 0101   | 5     |
| 6       | 0110   | 6     |
| 7       | 0111   | 7     |
| 8       | 1000   | 8     |
| 9       | 1001   | 9     |
| 10      | 1010   | **A** |
| 11      | 1011   | **B** |
| 12      | 1100   | **C** |
| 13      | 1101   | **D** |
| 14      | 1110   | **E** |
| 15      | 1111   | **F** |
> **rule** : Every 4 bits = exactly 1 hex digit!!
### Binary -> Hex (Group 4 bits at a time)
Convert `1111 1010` to hex:
```
1111 = F
1010 = A

Result: 0xFA
```
Binary `1111010` = Hex `0xFA`
The `0x` is the universal notation for hexadecimal in code.
### Hex -> Decimal (Powers of 16)
Convert `0xFA` to decimal
```
F × 16¹  =  15 × 16  =  240
A × 16⁰  =  10 ×  1  =   10
                        ───
                        250
```
C# Code: Hex Conversions
```C#
// Decimal to Hex
int value = 250;
string hex = Convert.ToString(value, 16).ToUpper();
Console.WriteLine($"{value} in hex = 0x{hex}"); // 0xFA

// Hex to Decimal
string hexStr = "FA";
int fromHex = Convert.ToInt32(hexStr, 16);
Console.WriteLine($"0x{hexStr} = {fromHex}"); // 250

// Hex literal directly in C# (very common in emulators!)
int opcode = 0xFA;
Console.WriteLine(opcode); // 250

// Format as hex with padding (e.g., memory addresses)
Console.WriteLine($"Address: 0x{value:X4}"); // 0x00FA
```
---
## How Emulators Really Use This
This is where it all connects. Here is a taste of real emulator logic:

1- Memory Addresses are in Hex
The Game Boy CPU has memory mapped from `0x0000` to `0xFFFF` (65,536 bytes). You will always see addresses written in hex -- it is far more readable than decimal.
```C#
// A simple emulator memory bank
byte[] memory = new byte[0x10000]; // 65536 bytes (0x0000 to 0xFFFF)

// Write a value to address 0xFF80 (Game Boy's High Ram)
memory[0xFF80] = 0x42;

// Read it back
byte val = memory[0xFF80];
Console.WriteLine($"Value at 0xFF80: 0x{val:X2}"); // 0x42
```

2- Opcodes are Hex Bytes
CPU instructions are encoded as bytes. For example, in the Z80 CPU (used in Game Boy):
```C#
byte opcode = memory[programCounter]; // Fetch instructions

switch(opcode)
{
    case 0x00: /* NOP - do nothing*/ break;
    case 0x3E: /* LD A, n - load* next byte into register A */ break;
    case 0x76: /*HALT - stop CPU*/ break;
    // ... hundreds more
}
```

3- Bit Manipulation
Emulation use bitwise operation constantly -- to read CPU flags, check button presses,
Manipulate graphics, etc.
```C#
// CPU FLAGS register (each bit = a flag)
// Bit 7=Zero, Bit 6=Subtract, Bit 5=HalfCarry, Bit 4=Carry
byte flags = 0b10100000; // Zero and HalfCarry flags set

// Check if Zero flag is set (bit 7)
bool isZero = (flags & 0x80) != 0; // 0x80 = 10000000
Console.WriteLine($"Zero flag: {isZero}"); // True

// Set the Carry flag (bit 4)
flags |= 0x10; // OR with 00010000

// Clear the HalfCarry flag (bit 5)
flags &= ~0x20; // AND with inverted 00100000

Console.WriteLine($"Flags: 0b{Convert.ToString(flags, 2).PadLeft(8, '0')}");
```

4- Keeping Values in 8-bit or 16-bit Range
```C#
// Emulating an 8-bit register — must never exceed 255!
int result = 200 + 100; // = 300, too big for 8-bit!
byte eightBit = (byte)(result & 0xFF); // Mask to 8 bits → 44 (wraps around)
Console.WriteLine(eightBit); // 44  (overflow behavior, just like real hardware)

// 16-bit mask
int address = someValue & 0xFFFF; // Keep within 16-bit range
```