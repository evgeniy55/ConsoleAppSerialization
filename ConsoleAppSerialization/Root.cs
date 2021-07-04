﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ConsoleAppSerialization
{
	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
	

	public class Prop
	{
		[XmlAttribute]
		//[JsonProperty("Name")]
		public string Name { get; set; }

		[XmlAttribute]
		//[JsonProperty("Type")]
		public string Type { get; set; }

		[XmlAttribute]
		//[JsonProperty("Value")]
		public string Value { get; set; }
	}

	[XmlRoot("ProductOccurence")]
	public class ProductOccurence
	{
		[XmlAttribute]
		//[JsonProperty("Id")]
		public string Id { get; set; }

		[XmlAttribute]
		//[JsonProperty("Name")]
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

	public class XmlAttributes
	{
		[XmlElement]
		public List<Prop> Attr { get; set; }
	}
	
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



}
