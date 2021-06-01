namespace Scanner
{
	using System;

	public class Lexer
	{
		private const string Arthmetic = "+-/*";
		private const string Digits = "0123456789.";
		private const char EndOfLine = '^';
		private const string WhiteSpaces = " \t\n";
		private string _text;
		private int _postion;
		private int _lineNo;
		private int _lexemeNo;

		public Lexer()
		{

		}
		//returns current char that we points to
		private char Current
		{
			get
			{
				if (_postion >= _text.Length)
					return '\0';
				return _text[_postion];
			}
		}
		//method to set text that we'll analyze
		public void SetText(string text)
		{
			_text = text;
		}
		//increase postion that our current char points to
		private void Next() {
			_postion++;
		}
		//increase line number
		private void IncreaseLineNo() { _lineNo++; }
		//increase lexme number
		private void IncreaseLexemeNo() { _lexemeNo++; }
		//reset lexeme number
		private void ResetLexemeNo() { _lexemeNo = 0; }
		//checks is the cureent char is ^
		private bool IsEndOfLine()
		{
			if (Current == EndOfLine)
				return true;
			return false;
		}
		//checks is the current char is digit
		private bool IsDigit()
		{
			foreach (char digit in Digits)
			{
				if (Current == digit)
					return true;
			}
			return false;
		}
		//checks is the current char is arthmetic operator
		private bool IsArthmetic()
		{
			foreach (char arth in Arthmetic)
			{
				if (Current == arth)
					return true;
			}
			return false;
		}
		//checks is the current char is whitespace
		private bool IsWhitspace()
		{
			foreach (char whitespace in WhiteSpaces)
			{
				if (Current == whitespace)
					return true;
			}
			return false;
		}
		//returns substring from the original string from start to end-1 (end not included)
		private string SubString(int start, int end)
		{
			string subString = "";
			for (int i = start; i < end; i++)
			{
				subString += _text[i];
			}
			return subString;
		}
		//the main method that tokeize the code
		public void Tokinize()
		{
			_postion = 0;
			_lineNo = 1;									
			_lexemeNo = 0;
			int start;
			while (_postion<_text.Length)						//while we still in text boundries
            {
				if (IsEndOfLine())                              //check if current is ^
				{
					IncreaseLexemeNo();
					System.Diagnostics.Debug.WriteLine(Current + " " + _lineNo + " " + _lexemeNo + " ENDOFLINE");
					IncreaseLineNo();                           //increase line because the first line has ended
					ResetLexemeNo();                            //count lexems from the begining again for the new line
					Next();                                     //increase the postion for the next iterate
				}

				else if (IsDigit())                             //check if current is digit
				{
					start = _postion;
					while (IsDigit())                           //while the new charcter is still digit
						Next();
					string Digit = SubString(start, _postion);  //store the whole number
					IncreaseLexemeNo();
					System.Diagnostics.Debug.WriteLine(Digit + " " + _lineNo + " " + _lexemeNo + " DIGIT");
				}

				else if (IsWhitspace())                         //check if current is whitespace
				{
					start = _postion;
					while (IsWhitspace())
						Next();
					string whitespace = SubString(start, _postion);
					IncreaseLexemeNo();
					System.Diagnostics.Debug.WriteLine(whitespace + " " + _lineNo + " " + _lexemeNo + " WHITESPACE");

				}

				else if (IsArthmetic())                         //check if current is arthmetic operator
				{
					char arthmetic = Current;                   //store the arthmetic operator
					IncreaseLexemeNo();
					System.Diagnostics.Debug.WriteLine(Current + " " + _lineNo + " " + _lexemeNo + " ARTHMETIC");
					Next();                                     //increase the postion for the next iterate
				}
				else Next();									//if the input is not all the above just increase postion to avoid infinite loop
			}
		}
	}
}