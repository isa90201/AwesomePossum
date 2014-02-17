using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace RPG
{
    public static class Serializer
    {
        //Write XML to file
        public static void Serialize(string path, object node)
        {
            var serializer = new XmlSerializer(node.GetType());
            var writer = new StreamWriter(path, false);
            serializer.Serialize(writer, node);
            writer.Close();
        }

        //Read XML file; Create object.
        public static object Deserialize(string path, Type t)
        {
            var serializer = new XmlSerializer(t);
            var reader = new StreamReader(path);
            var ret = serializer.Deserialize(reader);
            reader.Close();
            return ret;
        }
    }
}
