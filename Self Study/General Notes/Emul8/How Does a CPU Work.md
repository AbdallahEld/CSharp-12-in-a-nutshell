To Understand How CHIP_8 Work First we had to understand how CPU Works since they are the Core of any hardware

## What CPU does?
CPU is the heart of any device - it reads instructions from Memory and Execute it one by one
All Instruction is a number saved in memory, CPU Reads it, Understand what it should do and go do it thats what we call
### fetch -> decode -> execute cycle
```
while (runing):
    instruction = memory[PC] // Fetch: get the instruction from memory
    PC++                     // move program counter to the next instruction
    decode (instruction)     // Understand what he want
    execute (instruction)    // Execute
```
---
## What is Registers
Registers is small storage units inside CPU it self - too much faster than RAM. The CPU work on them directly
### Ex - Game Boy Processor (LR35902)
- `Register A` = Accumulator, store result of an equation
- When it see: `ADD A, $22` it means take value in A, increment it by `$22` and store result back on A

### Ex - Chip-8
- it has 16 registers from `V0` to `VF`
- when it sees: `7522$` - it means
  - `$75` = ADD to register V5
  - `$22` = Value that will be added
---
## How Instructions turn to bytes
That is what Assembler do
```
// Programmer Type
ADD V5, $22

// ASSEMBLER TURN IT TO
$7522 -> 0111 0101 0010 0010
```
---
## Chip-8 is not a real CPU

|                 | Real CPU         | CHIP-8                    |
| --------------- | ---------------- | ------------------------- |
| Type            | Silicon chip     | Virtual Machine (Program) |
| Instructions    | Hardware opcodes | Custom Instructions       |
| Execution Level | Hardware Level   | Inside Interpreter        |
