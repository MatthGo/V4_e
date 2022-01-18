using System;
using System.Collections.Generic;

namespace V4_e
{
    internal class ParsingLogic
    {
       
        public ParsingLogic() {
        
        }

        public void parse(string toParse, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess, char splitBy)
        {
            string[] sort = toParse.Split(splitBy);

            for (int i = 0; i < sort.Length; i++)
            {
                if (cancelCurrentProcess)
                    return;

                string item = sort[i].Trim();

                if (item != String.Empty)
                    assignToUnsortedOutput(item, UnsortedOutput);
            }
        }

        public void parse(string toParse, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess, char splitBy, ref int maxStringLength)
        {
            string[] sort = toParse.Split(splitBy);
            
            for (int i = 0; i < sort.Length; i++)
            {
                if (cancelCurrentProcess)
                    return;

                string item = sort[i].Trim();

                if (item != String.Empty)
                {
                    assignToUnsortedOutput(item, UnsortedOutput);
                    if (item.Length > maxStringLength) { maxStringLength = item.Length; }
                }
            }
        }

        private static void assignToUnsortedOutput(string item, Dictionary<string, int> UnsortedOutput)
        {
            if (UnsortedOutput.ContainsKey(item))
                UnsortedOutput[item]++;
            else
                UnsortedOutput.Add(item, 1);
        }
    }
}
