using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            // HashSet to save all the created nodes
            HashSet<BagNode> createdNodes = new HashSet<BagNode>();
            // Saving the shinygold bag
            BagNode shinyGold = null;
            // Return value
            int ret = 0;
            // Getting input
            String line = System.IO.File.ReadAllText("input.txt");
            // Formatting input
            line = line.Replace("bags", "\b").Replace("bag", "\b").Replace("contain", "|").Replace(",", "|").Replace(".", "");

            Console.WriteLine(line);

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

                for (int i = 1; i < words.Length; i++)
                {
                    String bagKey = words[i].Replace("\b", "").Replace(" ", "").Replace("noother", "");

                    if (!bagKey.Equals(""))
                    {
                        int amount = Int32.Parse(bagKey.Substring(0, 1));
                        BagNode currNode = new BagNode(bagKey.Substring(1));

                        if (!createdNodes.Contains(currNode))
                        {
                            createdNodes.Add(currNode);
                        }
                        else
                        {
                            createdNodes.TryGetValue(currNode, out currNode);
                        }

                        rootNode.AddChild(currNode, amount);
                    }
                }

                if (rootNode.GetName().Equals("shinygold"))
                {
                    shinyGold = rootNode;
                }
            }

            Console.WriteLine(shinyGold.GetTotalNodes());
        }
    }

    public class BagNode
    {
        private String bagName;
        private List<int> childrenAmount;
        private List<BagNode> children;

        public BagNode(String name)
        {
            bagName = name;
            childrenAmount = new List<int>();
            children = new List<BagNode>();
        }

        public void AddChild(BagNode child, int amount)
        {
            children.Add(child);
            childrenAmount.Add(amount);
        }

        public int GetTotalNodes()
        {
            int ret = 1;

            for (int i = 0; i < children.Count; i++)
            {
                ret += children[i].GetTotalNodes() * childrenAmount[i];
            }

            return ret;
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
