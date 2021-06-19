using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Randomizer.Generator.Core
{
    /// <summary>
    /// Types of generators
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GeneratorTypes
    {
        Unknown,
        List,
        Assignment,
        Phonotactics
    }

    /// <summary>
    /// Output formats of a generator's results
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OutputFormats
    {
        Text,
        Html
    }

    /// <summary>
    /// Enumeration of the available types for a parameter
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ParameterTypes
    {
        Text,
        Integer,
        Decimal,
        List,
        Date,
        Boolean
    }

    /// <summary>
    /// Possible cases for text lcase, UCASE, Tcase
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TextCases
    {
        None,
        Lower,
        Upper,
        Title
    }
}