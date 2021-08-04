
using System;
namespace Randomizer.Generator.UI.Terminal
{
    /// <summary>
    /// Compile time assembly info
    /// </summary>
    public static partial class AssemblyInfo
    {
        /// <summary>Date and time of Compilation</summary>
        public static DateTime CompilationTimestampUtc { get { return new DateTime(637613618517072648L, DateTimeKind.Utc); } }
        /// <summary>Name of the product</summary>
        public static String ProductName { get => "Randomizer UIT"; }
        /// <summary>Author of product</summary>
        public static String Author { get => "Lance Boudreaux"; }
      
#if ALPHA
        /// <summary>Alpha release</summary>
        public static String ReleaseType { get => "Alpha"; }
#elif BETA
        /// <summary>Beta release</summary>
        public static String ReleaseType { get => "Beta"; }
#else 
        /// <summary>Release</summary>
        public static String ReleaseType { get => String.Empty; }
#endif
    }
}