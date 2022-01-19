using System;
using System.Collections.Generic;
using System.Linq;

namespace V4_e
{
    internal class ParsingLogic
    {
       
        public ParsingLogic() {
        
        }

        /// <summary>
        /// Call ParseFile with path, char splitting and a cancellation token. <br/>
        /// Returns Dictionary unsortedOutput.
        /// </summary>
        public Dictionary<string, int> ParseFile(string path, char splitBy, ref bool cancelCurrentProcess)
        {
            Dictionary<string, int> unsortedOutput = new Dictionary<string, int>();
            try
            {
                GUI.gui.SetProgressBarValue(0);

                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default))
                {
                    System.IO.Stream baseStream = sr.BaseStream;
                    long length = baseStream.Length;

                    string toParse = String.Empty;

                    while ((toParse = sr.ReadLine()) != null)
                    {
                        if (cancelCurrentProcess) { break; }

                        GUI.gui.SetProgressBarValue(value: Convert.ToInt32((double)baseStream.Position / length * 100));
                        Parse(toParse, splitBy, unsortedOutput, ref cancelCurrentProcess);
                    }
                }
            }
            catch (Exception ex)
            {
                GUI.gui.ReportError(ex.Message);
            }

            return unsortedOutput;
        }

        /// <summary>
        /// Call ParseFile with path, char splitting, a cancellation token and max length of processed strings <br/>
        /// Returns Dictionary unsortedOutput.
        /// </summary>
        public Dictionary<string, int> ParseFile(string path, char splitBy, ref bool cancelCurrentProcess, ref int maxStringLength)
        {
            Dictionary<string, int> unsortedOutput = new Dictionary<string, int>();
            try
            {
                GUI.gui.SetProgressBarValue(0);
                
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path, System.Text.Encoding.Default))
                {
                    System.IO.Stream baseStream = sr.BaseStream;
                    long length = baseStream.Length;

                    string toParse = String.Empty;

                    while ((toParse = sr.ReadLine()) != null)
                    {
                        if (cancelCurrentProcess) { break; }

                        GUI.gui.SetProgressBarValue(value: Convert.ToInt32((double)baseStream.Position / length * 100));
                        Parse(toParse, splitBy, unsortedOutput, ref cancelCurrentProcess, ref maxStringLength);
                    }
                }
            }
            catch (Exception ex)
            {
                GUI.gui.ReportError(ex.Message);
            }
            return unsortedOutput;
        }

        /// <summary>
        ///Takes a string, splits it by the char given and adds it to Dictionary UnsortedOutput. If cancelCurrentProcess == true, function aborts.
        /// </summary>
        private void Parse(string toParse, char splitBy, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess)
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
        private void Parse(string toParse, char splitBy, Dictionary<string, int> UnsortedOutput, ref bool cancelCurrentProcess,  ref int maxStringLength)
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
