using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Utilities;

public class XmlHelper
{
    public T Deserialize<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

        using StringReader reader = new StringReader(inputXml);

        T deserializedObj = (T)xmlSerializer.Deserialize(reader);

        return deserializedObj;
    }

    public T[] DeserializeCollection<T>(string inputXml, string rootName)
    {
        XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

        using StringReader reader = new StringReader(inputXml);
        T[] deserializedObj = (T[])xmlSerializer.Deserialize(reader);

        return deserializedObj;
    }

}