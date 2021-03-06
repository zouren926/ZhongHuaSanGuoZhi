﻿namespace GameFreeText
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class GameObjectTextBranch
    {
        public string BranchName;
        public List<GameObjectTextLeaf> Leaves = new List<GameObjectTextLeaf>();
        public int Time;

        internal void LoadFromXmlNode(XmlNode rootNode)
        {
            foreach (XmlNode node in rootNode.ChildNodes)
            {
                GameObjectTextLeaf item = new GameObjectTextLeaf();
                XmlNode namedItem = node.Attributes.GetNamedItem("Property");
                if (namedItem != null)
                {
                    item.Property = namedItem.Value;
                }
                namedItem = node.Attributes.GetNamedItem("Text");
                if (namedItem != null)
                {
                    item.Text = namedItem.Value;
                }
                item.TextColor.PackedValue = uint.Parse(node.Attributes.GetNamedItem("Color").Value);
                this.Leaves.Add(item);
            }
        }
    }
}

