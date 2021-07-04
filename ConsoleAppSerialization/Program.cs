using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleAppSerialization
{
	class Program
	{
		static void Main(string[] args)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Root));

			FileStream fileStream = new FileStream("../../test.xml", FileMode.Open);
			
			Root result = (Root)serializer.Deserialize(fileStream);

			var srlz = JsonSerializer.Create();
			srlz.Formatting = Newtonsoft.Json.Formatting.Indented;
			var streamjson = new StreamWriter("../../_test.json");
			var jtw = new JsonTextWriter(streamjson);

			srlz.Serialize(jtw, result.ModelFiles.ProductOccurences);

			jtw.Flush();
		}

	}
}
