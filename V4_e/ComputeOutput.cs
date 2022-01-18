using System;
using System.Collections.Generic;
using System.Linq;

namespace V4_e
{
    internal class ComputeOutput
    {
        public static string[] getOutput(string path, ref bool cancelCurrentProcess) {
            
            Dictionary<string, int> unsortedOutput = new Dictionary<string, int>();
            int maxStringLength = 0;
            try
            {
                GUI.gui.setProgressBarValue(0);
                ParsingLogic parsingLogic = new ParsingLogic();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default))
                {
                    System.IO.Stream baseStream = sr.BaseStream;
                    long length = baseStream.Length;

                    string toParse = String.Empty;

                    while ((toParse = sr.ReadLine()) != null)
                    {
                        if (cancelCurrentProcess)
                            break;

                        GUI.gui.setProgressBarValue(value: Convert.ToInt32((double)baseStream.Position / length * 100));
                        parsingLogic.parse(toParse, unsortedOutput, ref cancelCurrentProcess, splitBy: ' ', ref maxStringLength);
                    }
                }
            }
            catch (Exception ex)
            {
                GUI.gui.reportError(ex.Message);
            }
            Console.WriteLine("maxStringLength: {0}", maxStringLength);

            GUI.gui.setprogressDefinition("Sorting...");
            List<string> sortedOutput = new List<string>();
            string addString = string.Empty;
            //sorting from unsorted Dictionary to sorted List holding lines (word, Occurrence)
            foreach (var item in from entry in unsortedOutput orderby entry.Value descending select entry)
            {
                int padding = 4;

                if (item.Key.Length < maxStringLength) { padding += maxStringLength - item.Key.Length; }
               
                addString = item.Key;
                for (int i = 0; i < padding; i++) { addString += " "; }                

                addString += item.Value;

                Console.WriteLine(addString);
                sortedOutput.Add(addString);
            }
            addString = "Word";
            for(int i = 0; i < maxStringLength; i++) { addString += " "; }
            addString += "Occurrence";
            sortedOutput.Insert(0,String.Empty);
            sortedOutput.Insert(0,addString);

            if(cancelCurrentProcess)
                GUI.gui.setprogressDefinition("Cancelled");
            else
                GUI.gui.setprogressDefinition("Ready");

            return sortedOutput.ToArray();
        }
    }
}
