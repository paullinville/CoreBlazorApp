using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EATTS.Common.Models;

public class KeyValueModel
{
	public string Key { get; set; }

	[JsonConverter(typeof(SafeNullableConverter<string>))]
	public string Value { get; set; }
}