using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleAppSerialization
{
	public class Root
	{
		//public string GlobalData { get; set; }
		[XmlElement("ModelFile")]
		public ModelFile ModelFiles { get; set; }
	}

	public class ModelFile
	{
		[XmlElement("ProductOccurence")]
		public List<ProductOccurence> ProductOccurences { get; set; }
	}

	public class ProductOccurence
	{
		[XmlAttribute]
		public string Id { get; set; }

		[XmlAttribute]
		public string Name { get; set; }

		[XmlElement]
		[JsonIgnore]
		public XmlAttributes Attributes { get; set; }
		
		[XmlIgnore]
		public List<Prop> Props { 
			// for json empty array when props is null
			get => Attributes == null ? new List<Prop>() : Attributes.Attr;
		}
		//public List<Prop> Props { get => Attributes?.Attr; }
	}

	public class Prop
	{
		[XmlAttribute]
		public string Name { get; set; }

		[XmlAttribute]
		public string Type { get; set; }

		[XmlAttribute]
		public string Value { get; set; }
	}

	public class XmlAttributes
	{
		[XmlElement]
		public List<Prop> Attr { get; set; }
	}
}
