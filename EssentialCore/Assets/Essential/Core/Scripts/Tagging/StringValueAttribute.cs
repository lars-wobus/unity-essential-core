using System;

namespace Essential.Core.Tagging
{
	public class StringValueAttribute : Attribute
	{
		private string _value;

		public StringValueAttribute(string value)
		{
			_value = value;
		}

		public string Value
		{
			get { return _value; }
		}

		public static string GetStringValue(Enum value)
		{
			string output = null;
			Type type = value.GetType();

			// TODO caching

			var fieldInfo = type.GetField(value.ToString());
			StringValueAttribute[] attributes =
				fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];

			// TODO caching

			return attributes[0].Value;
		}
	}
}
