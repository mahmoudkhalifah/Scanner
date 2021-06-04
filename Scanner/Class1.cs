using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionary
{
    public class Dictionary_
    {
        string[] s_output = { "lineNo", "lexeme", "ReturnToken", "lexemeNoInLine", "matchability" };
        static int counter1 = 0;
        static int counter2 = 0;
        static int counter3 = 0;
        static int counter4 = 0;
        static int counter5 = 0;
        EnvironmentVariableTarget i;
        // Instance Variables
        string[] lineNo = new string[100];
        string[] lexeme = new string[100];
        string[] ReturnToken = new string[100];
        string[] matchability = new string[100];
        string[] lexemeNoInLine = new string[100];

        // Constructor Declaration of Class


        public void add(string key, dynamic value)
        {
            foreach (string item in s_output)
            {
                if (item.Equals(key))
                {
                    if (item == "lineNo")
                        lineNo[counter1++] = value;
                    else if (item == "lexeme")
                        lexeme[counter2++] = value;
                    else if (item == "ReturnToken")
                        ReturnToken[counter3++] = value;
                    else if (item == "lexemeNoInLine")
                        lexemeNoInLine[counter4++] = value;
                    else if (item == "matchability")
                        matchability[counter5++] = value;
                }
            }
        }

        public void clearAll()
        {
            Array.Clear(lineNo, 0, lineNo.Length);
            Array.Clear(lexeme, 0, lexeme.Length);
            Array.Clear(ReturnToken, 0, ReturnToken.Length);
            Array.Clear(lexemeNoInLine, 0, lexemeNoInLine.Length);
            Array.Clear(matchability, 0, matchability.Length);

        }
        public string[] get(string key)
        {
            if (key == "lineNo")
                return lineNo;
            else if (key == "lexeme")
                return lexeme;
            else if (key == "ReturnToken")
                return ReturnToken;
            else if (key == "lexemeNoInLine")
                return lexemeNoInLine;
            else
                return matchability;
        }

        public int length()
        {
            return lineNo.Length;
        }
    }
}

