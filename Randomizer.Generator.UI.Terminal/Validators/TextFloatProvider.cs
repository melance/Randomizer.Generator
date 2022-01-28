using NStack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Terminal.Gui.TextValidateProviders;
using Rune = System.Rune;

namespace Randomizer.Generator.UI.Terminal.Validators
{
	class TextFloatProvider : ITextValidateProvider
	{
		#region Constructor
		public TextFloatProvider(Double minValue = Double.MinValue, Double maxValue = Double.MaxValue) => (MinValue, MaxValue) = (minValue, maxValue);
		#endregion

		#region Members
		private List<Rune> _text;
		#endregion

		#region Properties
		public Boolean ValidateOnInput { get; set; } = true;
		public Double MaxValue { get; set; }
		public Double MinValue { get; set; }
		public Int32 MaxDecimalDigits { get; set; } = -1;

		public Boolean Fixed => false;

		public Boolean IsValid => Validate(RawText);

		public ustring Text
		{
			get => ustring.Make(RawText);
			set => RawText = value != ustring.Empty ? value.ToRuneList() : null;
		}

		List<Rune> RawText
		{
			get
			{
				if (_text == null)
					_text = new();
				return _text;
			}
			set => _text = value;
		}
		#endregion

		#region Public Methods
		public ustring DisplayText => Text;

		public Int32 Cursor(Int32 pos)
		{
			if (pos < 0)
				return CursorStart();
			else if (pos >= RawText.Count)
				return CursorEnd();

			return pos;
		}

		public Int32 CursorEnd() => _text.Count;

		public Int32 CursorLeft(Int32 pos)
		{
			if (pos > 0)
				return pos - 1;
			return pos;
		}

		public Int32 CursorRight(Int32 pos)
		{
			if (pos < RawText.Count)
				return pos + 1;
			return pos;
		}

		public Int32 CursorStart() => 0;

		public Boolean Delete(Int32 pos)
		{
			if (RawText.Count > 0 && pos < RawText.Count)
				RawText.RemoveAt(pos);
			return true;
		}

		public Boolean InsertAt(Char ch, Int32 pos)
		{
			var test = RawText.ToList();
			test.Insert(pos, ch);
			if (Validate(test) || ValidateOnInput == false)
			{
				RawText.Insert(pos, ch);
				return true;
			}
			return false;
		}
		#endregion

		#region Private Methods
		Boolean Validate(List<Rune> text)
		{
			var textString = ustring.Make(text).ToString();

			if (String.IsNullOrEmpty(textString))
			{
				Text = MinValue.ToString();
				return true;
			}

			if (Double.TryParse(textString, out var value))
			{
				if (value >= MinValue && value <= MaxValue)
				{
					var valueString = value.ToString();
					var parts = valueString.Split(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
					if (parts.Length <= 1) return true;
					return parts.Last().Length <= MaxDecimalDigits;
				}
			}
			return false;

		}
		#endregion
	}
}
