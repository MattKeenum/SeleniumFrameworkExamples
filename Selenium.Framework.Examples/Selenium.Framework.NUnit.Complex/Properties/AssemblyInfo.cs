using System.Reflection;
using System.Runtime.InteropServices;
using NUnit.Framework;


// NUnit configuration for parallel execution

// Enable parallel execution at the assembly level
[assembly: Parallelizable(ParallelScope.All)]

// Optional: Set the maximum number of parallel threads
[assembly: LevelOfParallelism(4)] // Adjust this value as per your system capabilities
