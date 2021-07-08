
using System;
namespace Randomizer.Generator.UI.Terminal
{
    public static partial class AssemblyInfo
    {
        public static DateTime CompilationTimestampUtc { get { return new DateTime(637604959080696683L, DateTimeKind.Utc); } }
        public static String ProductName { get => "Randomizer UIT"; }
        public static String Author { get => "Lance Boudreaux"; }
      
#if ALPHA
        public static String ReleaseType { get => "Alpha"; }
#elif BETA
        public static String ReleaseType { get => "Beta"; }
#else 
        public static String ReleaseType { get => String.Empty; }
#endif
    }
}