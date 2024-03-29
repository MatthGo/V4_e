﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace V4_e
{
    internal class ComputeOutput
    {
        ///<summary>        
        ///<para>Takes path to file and a cancel token. If cancelCurrentProcess == true, function aborts.<br /> 
        ///  Returns string[] with sorted and formated output.</para>
        ///</summary>
        public static string[] GetOutput(string path, ref bool cancelCurrentProcess)
        {
            int maxStringLength = 0;
            var parsingLogic = new ParsingLogic();

            Dictionary<string, int> unsortedOutput = parsingLogic.ParseFile(path, splitBy: ' ',ref cancelCurrentProcess, ref maxStringLength);

            GUI.gui.SetprogressDefinition("Sorting...");
            var sortedOutput = new List<string>();
            //sorting from unsorted Dictionary to sorted List holding lines (word, Occurrence)
            foreach (var entry in from entry in unsortedOutput orderby entry.Value descending select entry)
            {
                BuildOutput(sortedOutput, entryKey: entry.Key, entryValue: entry.Value, maxStringLength);
            }
            BuildHead(headA: "Word", headB: "Occurrence", maxStringLength, sortedOutput);

            if(cancelCurrentProcess)
                GUI.gui.SetprogressDefinition("Cancelled");
            else
                GUI.gui.SetprogressDefinition("Ready");

            return sortedOutput.ToArray();
        }

        ///<summary>
        ///Adds a formatted string to List sortedOutput.
        ///Takes a entry.key (string) and a entry.Value(int) from DictionaryEntry.
        ///Format of string depends on maxStringLength.
        ///</summary>
        private static void BuildOutput(List<string> sortedOutput, string entryKey, int entryValue, int maxStringLength) {
            sortedOutput.Add(BuildOutputString(entryA: entryKey, entryB: entryValue.ToString(),
                padRight: entryKey.Length < maxStringLength ? maxStringLength - entryKey.Length : 0));
        }
        
        private static string BuildOutputString(string entryA, string entryB, int padRight)
        {
            int padding = 2;

            padding += padRight;
            string addString = entryA;
            for (int i = 0; i < padding; i++) { addString += " "; }
            addString += "|  " + entryB;

            return addString;
        }

        ///<summary>
        ///Adds two formatted string to List sortedOutput.
        ///takes headA (Head of col A) and headB (Head of col B) as headline.
        ///Format of string depends on maxStringLength.
        ///</summary>
        private static void BuildHead(string headA, string headB, int maxStringLength, List<string> sortedOutput) {
            int paddingPartingLine = 2;
            sortedOutput.Insert(0, String.Empty.PadRight((maxStringLength + headA.Length + headB.Length + paddingPartingLine), '-'));
            sortedOutput.Insert(0, BuildHeadString(headA, headB, padRight: maxStringLength, paddingPartingLine));
        }

        private static string BuildHeadString(string headA, string headB, int padRight, int paddingPartingLine)
        {
            int padding = 2;

            padding += padRight- headA.Length - paddingPartingLine;
            string addString = headA;
            for (int i = 0; i < padding+paddingPartingLine; i++) { addString += " "; }
            addString += "|";
            for (int i = 0; i < paddingPartingLine; i++) { addString += " "; }
            addString += headB;

            return addString;
        }
    }
}
