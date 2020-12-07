using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            // HashSet to save all the created nodes
            HashSet<BagNode> createdNodes = new HashSet<BagNode>();
            // Return value
            int ret = 0;
            // Getting input
            String line = System.IO.File.ReadAllText("input.txt");
            // Formatting input
            line = line.Replace("bags", "\b").Replace("bag", "\b").Replace("contain", "\b").Replace(",", "").Replace(".", "");
            line = Regex.Replace(line, "[0-9]", "|");

            // Splitting the lines
            String[] lines = line.Split("\n");

            // Creating a node foreach line
            foreach (String currLine in lines)
            {
                String[] words = currLine.Split("|");
                // Words[0] is the root of the subtree
                BagNode rootNode = new BagNode(words[0].Replace("\b", "").Replace(" ", "").Replace("noother", ""));

                if (!createdNodes.Contains(rootNode))
                {
                    createdNodes.Add(rootNode);
                }
                else
                {
                    createdNodes.TryGetValue(rootNode, out rootNode);
                }

                for (int i=1; i<words.Length; i++)
                {
                    BagNode currNode = new BagNode(words[i].Replace("\b", "").Replace(" ", "").Replace("noother", ""));
                    
                    if (!createdNodes.Contains(currNode))
                    {
                        createdNodes.Add(currNode);
                    }
                    else
                    {
                        createdNodes.TryGetValue(currNode, out currNode);
                    }

                    rootNode.AddChild(currNode);
                }
            }

            foreach (BagNode b in createdNodes)
            {
                if (b.HasGoldBag())
                {
                    ret++;
                }
            }

            // Apparently you don't have to count the shiny gold bag itself
            Console.WriteLine(ret - 1);
        }
    }

    public class BagNode
    {
        private String bagName;
        private List<BagNode> children;

        public BagNode(String name)
        {
            bagName = name;
            children = new List<BagNode>();
        }

        public void AddChild(BagNode child)
        {
            children.Add(child);
        }

        public bool HasGoldBag()
        {
            if (bagName.Equals("shinygold"))
            {
                return true;
            }
            else
            {
                for (int i=0; i<children.Count; i++)
                {
                    if (children[i].HasGoldBag())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public String GetName()
        {
            return bagName;
        }

        public override int GetHashCode()
        {
            return bagName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return ((BagNode)obj).GetName().Equals(bagName);
        }
    }
}
