using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Randomizer.Generator.Assignment;
using Randomizer.Generator.Utility;

namespace Randomizer.Generator.Sampler
{
    class SampleParser
    {
        AssignmentDefinition definition;

        private const String START_ITEM = "Start";

        public AssignmentDefinition ParseFile(String filePath, Int32 length)
        {
            return Parse(File.ReadAllLines(filePath).ToList(), length);            
        }
        
        public AssignmentDefinition ParseString(String content, Int32 length, String delimiter = "\n")
        {
            var items = content.Split(delimiter);
            return Parse(items.ToList(), length);
        }

        public AssignmentDefinition Parse(List<String> lines, Int32 length)
        {
            definition = new();
            definition.LineItems.Add(START_ITEM, new LineItemList());

            foreach (var line in lines)
            {
                var parts = line.Split(length);

                for (var i = 0; i < parts.Count; i++)
                {
                    var part = parts[i];
                    var isOpen = i == 0;
                    var isClose = i == parts.Count - 1;

                    if (isOpen && isClose)
                    {
                        // Singular value
                        if (!definition.LineItems[START_ITEM].Any(li => FindItem(li, part)))
                            definition.LineItems[START_ITEM].Add(new LineItem() { Content = part });
                    }
                    else if (isOpen)
                    {
                        // Starting value
                        if (!definition.LineItems[START_ITEM].Any(li => FindItem(li, part)))
                            definition.LineItems[START_ITEM].Add(new LineItem() { Content = $"{part}[{part}]" });
                        if (!definition.LineItems.Any(li => li.Key.Equals(part.ToUpper())))
                            definition.LineItems.Add(part.ToUpper(), new LineItemList());                        
                    }
                    else if (isClose)
                    {
                        // Ending value
                        var previous = parts[i - 1];
                        if (!definition.LineItems[previous.ToUpper()].Any(li => FindItem(li, part)))
                            definition.LineItems[previous.ToUpper()].Add(new LineItem() { Content = part });
                    }
                    else
                    {
                        var previous = parts[i - 1];
                        var content = $"{part}[{part.ToUpper()}]";
                        if (!definition.LineItems[previous.ToUpper()].Any(li => FindItem(li, content)))
                            definition.LineItems[previous.ToUpper()].Add(new LineItem() { Content = content });
                        if (!definition.LineItems.Any(li => li.Key.Equals(part.ToUpper())))
                            definition.LineItems.Add(part.ToUpper(), new LineItemList());
                    }
                }
            }
            return definition;
        }        

        private static Boolean FindItem(LineItem li, String part)
        {
            return li.Content.Equals(part, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
