using System.Text;
using System.Xml.Serialization;

namespace Medicines.Utilities;

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


    //Serialize<ExportDto[]>(ExportDto[], rootName)
    //Serialize<ExportDto>(ExportDto, rootName)
    public string Serialize<T>(T obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), rootAttribute);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(String.Empty, String.Empty);

        using StringWriter stringWriter = new StringWriter(sb);
        xmlSerializer.Serialize(stringWriter, obj , namespaces);

        return sb.ToString().TrimEnd();
    }

    //Serialize<ExportDto>(ExportDto[], rootName)
    public string Serialize<T>(T[] obj, string rootName)
    {
        StringBuilder sb = new StringBuilder();
        XmlRootAttribute rootAttribute = new XmlRootAttribute(rootName);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), rootAttribute);

        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(String.Empty, String.Empty);

        using StringWriter stringWriter = new StringWriter(sb);
        xmlSerializer.Serialize(stringWriter, obj, namespaces);

        return sb.ToString().TrimEnd();
    }

}