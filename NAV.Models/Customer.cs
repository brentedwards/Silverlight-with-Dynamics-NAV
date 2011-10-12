using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.ComponentModel;

namespace NAV.Models
{
	public sealed class Customer : Model
	{
		private Field NameField { get; set; }

		private List<Field> _fields = new List<Field>();
		public IEnumerable<Field> Fields
		{
			get { return _fields; }
		}

		public string Name
		{
			get
			{
				return NameField != null ? NameField.Value : null;
			}
		}

		public void AddField(string fieldId, string caption, string value)
		{
			var field = new Field(fieldId, caption, value);
			_fields.Add(field);

			if (caption == "Name")
			{
				NameField = field;
				NameField.PropertyChanged += (sender, args) =>
					{
						if (args.PropertyName == "Value")
						{
							NotifyPropertyChanged("Name");
						}
					};
			}
		}

		public sealed class Field : Model
		{
			public Field(string fieldId, string caption, string value)
			{
				FieldId = fieldId;
				Caption = caption;
				Value = value;
			}

			public string FieldId { get; private set; }
			public string Caption { get; private set; }

			private string _value;
			public string Value
			{
				get { return _value; }
				set
				{
					_value = value;
					NotifyPropertyChanged("Value");
				}
			}
		}
	}
}
