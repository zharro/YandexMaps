namespace YandexMaps
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public static class XmlNodeExtensions
    {
        /// <summary>
        /// Возвращает узел XML, соответствующий указанному пути
        /// </summary>
        /// <param name="startNode">Узел относительно которого отсчитывается относительный путь</param>
        /// <param name="path">Относительный путь (относительно startNode), список имен тегов, разделенных символом /</param>
        /// <returns>Узел XML или null, если он не существует</returns>
        public static XmlNode GetChild(this XmlNode startNode, string path)
        {
            if (startNode == null)
            {
                throw new ArgumentException("startNode");
            }
            return GetNode(startNode, path.Split('\\', '/'));
        }

        /// <summary>
        /// Возвращает узел XML, соответствующий указанному пути
        /// </summary>
        /// <param name="startNode">Узел относительно которого отсчитывается относительный путь</param>
        /// <param name="pathParts">Относительный путь (относительно startNode), список имен тегов</param>
        /// <returns>Узел XML или null, если он не существует</returns>
        private static XmlNode GetNode(XmlNode startNode, IEnumerable<string> pathParts)
        {
            var currNode = startNode;
            if (pathParts == null) return currNode;
            foreach (var tagName in pathParts)
            {
                if (currNode.Name.Equals(tagName))
                {
                    continue;
                }
                if (tagName == "..")
                {
                    currNode = currNode.ParentNode;
                    if (currNode == null)
                    {
                        break;
                    }
                    continue;
                }
                if (tagName.Length <= 0) continue;
                var children = currNode.ChildNodes;
                currNode = null;
                foreach (XmlNode node in children)
                {
                    if (String.Compare(node.Name, tagName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        currNode = node;
                        break;
                    }
                }
                if (currNode == null)
                {
                    break;
                }
            }
            return currNode;
        }
    }
}
