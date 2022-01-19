using System;
using System.Collections.Generic;

namespace V4_e
{
    internal class ParsingLogic
    {
       
        public ParsingLogic() {
        
        }
        /// <summary>
        ///Takes a string, splits it by the char given and adds it to Dictionary UnsortedOutput. If cancelCurrentProcess == true, function aborts.
        /// </summary>

        public void Parse(string toParse, char splitBy, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess)
        {
            string[] sort = toParse.Split(splitBy);

            for (int i = 0; i < sort.Length; i++)
            {
                if (cancelCurrentProcess) { return; }

                string item = sort[i].Trim();

                if (item != String.Empty)
                    AssignToUnsortedOutput(item, UnsortedOutput);
            }
        }
        /// <summary>
        ///Takes a string, splits it by the char given and adds it to Dictionary UnsortedOutput. If cancelCurrentProcess == true, function aborts.< /br>
        ///Additonally sets maxStringLength
        /// </summary>

        public void Parse(string toParse, char splitBy, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess,  ref int maxStringLength)
        {
            string[] sort = toParse.Split(splitBy);
            
            for (int i = 0; i < sort.Length; i++)
            {
                if (cancelCurrentProcess) { return; }

                string item = sort[i].Trim();

                if (item != String.Empty)
                {
                    AssignToUnsortedOutput(item, UnsortedOutput);
                    if (item.Length > maxStringLength) { maxStringLength = item.Length; }
                                    }
            }
        }

        private static void AssignToUnsortedOutput(string item, Dictionary<string, int> UnsortedOutput)
        {
            if (UnsortedOutput.ContainsKey(item))
                UnsortedOutput[item]++;
            else
                UnsortedOutput.Add(item, 1);
        }
    }
}
