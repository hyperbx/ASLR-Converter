# ASLR Converter
A utility tool for transforming memory addresses between the new base and the old base for modules using ASLR.

# Prerequisites
### Building
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Running
- .NET 8.0 Desktop Runtime ([x86](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.6-windows-x86-installer), [x64](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.6-windows-x64-installer))

# Usage
### Base
This field is the current base address of the module you're looking at, you can obtain this in various ways.

### Transform Base
This field is the original base address of the module, you can obtain this by inspecting the executable file or through a disassembler. Typically this value is 0x400000 for 32-bit and 0x140000000 for 64-bit, but it may vary between modules.

### Transform
This field is the address you want to transform between the new base and the old base. If you're copying an address from the module's memory, you'd choose the `From ASLR` radio button to get the original address of that location. Otherwise, choose `To ASLR` if you wish to transform an address from the original base to the new module base in memory.