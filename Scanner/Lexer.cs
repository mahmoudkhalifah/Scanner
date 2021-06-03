namespace Scanner
{
	using System;
	//check for keywords and its tokens
	//check for identifiers
	//check for error in identifier naming
	//check for comments
	public class Lexer
	{
		private const string Digits = "0123456789.";
		private const string IdentifierChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_";
		private readonly string[] Keywords = { "Pattern", "DerivedFrom", "TrueFor", "Else", "Ity", "Sity",
			"Cwq", "CwqSequence","Ifity","Sifity","Valueless","Logical", "BreakFromThis","Whatever", "Respondwith", "Srap", "Scan", "Conditionof","Require" };
		private readonly string[] ReturnTokens = { "Class", "Inheritance", "Condition", "Condition", "Integer", "SInteger",
			"Character","String","float","SFloat","Void","Boolean","Break","Loop","Return","Struct","Switch","Inclusion"};
		private readonly string[] Symbols = { "@", "$", "\"'","{}[]()","#","^","&&","||","~","=","->","==","<>","!=","<=",">=","--","/-","-/", "+-*/" };
		private readonly string[] ReturnTokensForSymbols = { "Start Symbol","End Symbol", "Quotation Mark", "Braces", "Token Delimiter",
			"Line Delimiter", "Logic Operator", "Logic Operator", "Logic Operator",
			"Assignment Operator", "Access Operator","Relational Operators","Relational Operators","Relational Operators",
			"Relational Operators","Relational Operators","Comment","Comment","Comment","Arithmetic Operator"};
		private const char TokenDelimiter = '#';
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
		private void Next() { _postion++; }
		//increase line number
		private void IncreaseLineNo() { _lineNo++; }
		//increase lexme number
		private void IncreaseLexemeNo() { _lexemeNo++; }
		//reset lexeme number
		private void ResetLexemeNo() { _lexemeNo = 0; }
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

		private string IsSymbol(string symbol)
		{
			for (int i = 0; i < Symbols.Length; i++)
			{
				if (symbol == Symbols[i])
					return ReturnTokensForSymbols[i];
				if(symbol.Length == 1)
                {
					foreach (char _symbol in Symbols[i])	
					{
						if (symbol[0] == _symbol)
							return ReturnTokensForSymbols[i];
					}
				}
				
			}
			return "NOT FOUND";
		}
		//checks is the current char is arthmetic operator
		private string IsKeyword(string word)
		{
			for (int i=0; i< Keywords.Length;i++)
			{
				if (word == Keywords[i])
					return ReturnTokens[i];
			}
			return "NOT FOUND";
		}
		//checks is the current char is arthmetic operator
		private bool IsEndOfFile()
		{
			if (Current == '\0')
				return true;
			return false;
		}
		//checks is the current char is arthmetic operator
		private bool IsIdentifier(string word)
		{
			foreach (char char_ in IdentifierChars)
			{
				if (word[0] == char_)
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
		//checks is the current char is charcter
		private bool IsCharacter()
		{
			foreach (char char_ in IdentifierChars)
			{
				if (Current == char_)
					return true;
			}
			return false;
		}
		//checks is the current char is charcter
		private bool IsTokenDelmiter()
		{
			if (Current == TokenDelimiter)
				return true;
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
			while (_postion<_text.Length && !IsEndOfFile())						//while we still in text boundries
            {

				if (IsCharacter())                                         //check if current is digit
				{
					start = _postion;
					while (IsCharacter() || IsDigit() && !IsEndOfFile())                           //while the new charcter is still digit
						Next();
					IncreaseLexemeNo();
					string word = SubString(start, _postion);               //store the whole number
					if (IsKeyword(word) != "NOT FOUND")                       //////////////
						System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + IsKeyword(word));
					else if (IsIdentifier(word))
						System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + " Identifier");
					else System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + " ERROR");
				}

				else if (IsDigit())                             //check if current is digit
				{
					start = _postion;
					while (IsDigit() && !IsEndOfFile())                           //while the new charcter is still digit
						Next();
					string Digit = SubString(start, _postion);  //store the whole number
					IncreaseLexemeNo();
					System.Diagnostics.Debug.WriteLine(Digit + " " + _lineNo + " " + _lexemeNo + " DIGIT");
				}

				else if (IsWhitspace())                                 //check if current is whitespace
				{
					while (IsWhitspace() && !IsEndOfFile())
					{
						if (Current == '\n')
						{
							IncreaseLineNo();
							ResetLexemeNo();
						}
						Next();
					}

				}

				else if (!IsCharacter() && !IsDigit() && !IsWhitspace())
				{
					start = _postion;
					Next();
					while (!IsCharacter() && !IsDigit() && !IsWhitspace() && !IsEndOfFile())
						Next();

					string other = SubString(start, _postion);
					if (IsSymbol(other) != "NOT FOUND")
					{
						IncreaseLexemeNo();
						System.Diagnostics.Debug.WriteLine(other + " " + _lineNo + " " + _lexemeNo + IsSymbol(other));
						if (IsSymbol(other) == "Comment")
                        {

                            if (other == "--")
                            {
								while (Current != '\n' && !IsEndOfFile())
									Next();
                            }
                            else if (other == "/-")
                            {
								while (Current != '-' && !IsEndOfFile())
									Next();
							}
                        }
						else if (IsSymbol(other) == "Quotation Mark")
                        {
							if(other == "'")
                            {
								while (Current != '\'' && !IsEndOfFile())
									Next();
							}
							else while (Current != '\"' && !IsEndOfFile())
									Next();
						}
					}
				}                                   //if the input is not all the above just increase postion to avoid infinite loop
				else Next();
			}
		}
	}
}
