using System;
using System.Collections.Generic;

namespace _6._2
{
    class Program
    {
        private static int ParseGroup(String group)
        {
            String[] lines = group.Split("\n");
            int ret = 0;
            // Just to fake some optimization
            HashSet<char> alreadyFound = new HashSet<char>();

            for (int i=0; i<lines.Length; i++)
            {
                String currLine = lines[i];

                for (int j=0; j<currLine.Length; j++)
                {
                    char currentChar = currLine[j];

                    if (!alreadyFound.Contains(currentChar))
                    {
                        int h = 0;
                        bool ok = true;

                        while (h < lines.Length && ok)
                        {
                            if (!lines[h].Contains(currentChar) && !lines[h].Equals(""))
                            {
                                ok = false;
                            }

                            h++;
                        }

                        if (ok)
                        {
                            alreadyFound.Add(currentChar);
                            ret++;
                        }
                    }
                }
            }    

            return ret;
        }
        static void Main(string[] args)
        {
            String[] lines = System.IO.File.ReadAllText("input.txt").Split("\n");
            int ret = 0;
            String currentGroup = "";

            foreach (String line in lines)
            {
                // Reconstructing group
                if (line.Equals(""))
                {
                    ret += Program.ParseGroup(currentGroup);
                    currentGroup = "";
                }
                else
                {
                    currentGroup += line + "\n";
                }
            }

            ret += Program.ParseGroup(currentGroup);

            Console.WriteLine(ret);
        }
    }
}
