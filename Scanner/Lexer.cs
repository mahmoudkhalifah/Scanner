﻿namespace Scanner
{
	using dictionary;
	using System;
	using System.IO;

	public class Lexer
	{
		private const string Digits = "0123456789.";
		private const string Chars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_";
		private readonly string[] Keywords = { "Pattern", "DerivedFrom", "TrueFor", "Else", "Ity", "Sity",
			"Cwq", "CwqSequence","Ifity","Sifity","Valueless","Logical", "BreakFromThis","Whatever", "Respondwith", "Srap", "Scan", "Conditionof","Require" };
		private readonly string[] ReturnTokens = { "Class", "Inheritance", "Condition", "Condition", "Integer", "SInteger",
			"Character","String","float","SFloat","Void","Boolean","Break","Loop","Return","Struct","Switch","Switch","Inclusion"};
		private readonly string[] Symbols = { "@", "$", "\"'", "{}[]()", "^", "&&", "||", "~", "=", "->", "==", "<>", "!=", "<=", ">=", "--", "/-", "-/", "+-*/" };
		private readonly string[] ReturnTokensForSymbols = { "Start Symbol","End Symbol", "Quotation Mark", "Braces",
			"Line Delimiter", "Logic Operator", "Logic Operator", "Logic Operator",
			"Assignment Operator", "Access Operator","Relational Operators","Relational Operators","Relational Operators",
			"Relational Operators","Relational Operators","Comment","Comment","Comment","Arithmetic Operator"};
		private const char TokenDelimiter = '#';
		private const string WhiteSpaces = " \t\n";
		private string _text;
		private int _postion;
		private int _lineNo;
		private int _lexemeNo;
		private Dictionary_ _dic;

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
		/*public void SetText(string text)
		{
			_text = text;
		}*/
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
				if (symbol.Length == 1)
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
			for (int i = 0; i < Keywords.Length; i++)
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
			foreach (char char_ in Chars)
			{
				try
				{
					if (word[0] == char_)
						return true;
				}
				catch { }
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
			foreach (char char_ in Chars)
			{
				if (Current == char_)
					return true;
			}
			return false;
		}
		private bool IsTokenDelimiter()
		{
			if (Current == TokenDelimiter)
				return true;
			return false;
		}
		private bool IsComma()
		{
			if (Current == ',')
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
		private void addLexeme(int lineNo, string lexeme, string returnToken, int lexemeNo, string matchability)
		{
			_dic.add("lineNo", lineNo.ToString());
			_dic.add("lexeme", lexeme);
			_dic.add("ReturnToken", returnToken);
			_dic.add("lexemeNoInLine", lexemeNo.ToString());
			_dic.add("matchability", matchability);
			return;
		}
		//the main method that tokeize the code
		public void Tokinize(string text, Dictionary_ dic)
		{
			_dic = dic;
			_text = text;
			_postion = 0;
			_lineNo = 1;
			_lexemeNo = 0;
			int start;
			while (_postion < _text.Length && !IsEndOfFile())                       //while we still in text boundries
			{
				if (IsCharacter())                                         //check if current is digit
				{
					start = _postion;
					while (IsCharacter() || IsDigit() && !IsEndOfFile())                           //while the new charcter is still digit
						Next();
					IncreaseLexemeNo();
					string word = SubString(start, _postion);               //store the whole number
					if (IsKeyword(word) != "NOT FOUND")
					{
						//System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + IsKeyword(word));
						addLexeme(_lineNo, word, IsKeyword(word), _lexemeNo, "matched");
						if (IsKeyword(word) == "Inclusion")
						{
							while (IsWhitspace())
								Next();

							if (Current == '"')
							{
								Next();
							}
								
							
							start = _postion;
							while ((IsCharacter() || IsDigit() || IsWhitspace()) && (Current != '"' && !IsEndOfFile()))                           //while the new charcter is still digit
								Next();
							string fileName = SubString(start, _postion);
							Next();
							if (File.Exists(fileName))
							{
								int pos = _postion;
								string txt = _text;
								int lineNo = _lineNo;
								int lexemeNo = _lexemeNo;
								StreamReader sr = new StreamReader(fileName);
								string code = sr.ReadToEnd();
								sr.Close();
								Tokinize(code, dic);
								_postion = pos;
								_text = txt;
								_lineNo = lineNo;
								_lexemeNo = lexemeNo;
							}
						}
					}
					else if (IsIdentifier(word))
						addLexeme(_lineNo, word, "Identifier", _lexemeNo, "matched");
					//System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + " Identifier");
				}
				else if (IsTokenDelimiter() || IsComma())
				{
					if (IsTokenDelimiter())
					{
						IncreaseLexemeNo();
						addLexeme(_lineNo, Current + "", "Token Delimiter", _lexemeNo, "matched");
						//System.Diagnostics.Debug.WriteLine(Current + " " + _lineNo + " " + _lexemeNo + " Token Delimiter");
					}
					Next();
					start = _postion;
					while (IsCharacter() || IsDigit())
						Next();
					IncreaseLexemeNo();
					string word = SubString(start, _postion);
					if (IsIdentifier(word))
						addLexeme(_lineNo, word, "Identifier", _lexemeNo, "matched");
					else addLexeme(_lineNo, word, "Error", _lexemeNo, "not matched");
					//System.Diagnostics.Debug.WriteLine(word + " " + _lineNo + " " + _lexemeNo + " Error");
				}

				else if (IsDigit())                             //check if current is digit
				{
					start = _postion;
					while (IsDigit() && !IsEndOfFile())                           //while the new charcter is still digit
						Next();
					string Digit = SubString(start, _postion);  //store the whole number
					IncreaseLexemeNo();
					//System.Diagnostics.Debug.WriteLine(Digit + " " + _lineNo + " " + _lexemeNo + " Constant");
					addLexeme(_lineNo, Digit, "Constant", _lexemeNo, "matched");
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
					string other = "";
					other += Current;

					while (!IsCharacter() && !IsDigit() && !IsWhitspace() && !IsEndOfFile())
						Next();

					other = SubString(start, _postion);
					if (IsSymbol(other) != "NOT FOUND")
					{
						IncreaseLexemeNo();
						//System.Diagnostics.Debug.WriteLine(other + " " + _lineNo + " " + _lexemeNo + IsSymbol(other));
						addLexeme(_lineNo, other, IsSymbol(other), _lexemeNo, "matched");
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
							if (other == "'")
							{
								while (Current != '\'' && !IsEndOfFile())
									Next();
							}
							else while (Current != '\"' && !IsEndOfFile())
									Next();
						}
					}
					else
                    {
						foreach (char c in other)
						{
							if (IsSymbol(c+"") != "NOT FOUND")
							{
								IncreaseLexemeNo();
								addLexeme(_lineNo, c+"", IsSymbol(c+""), _lexemeNo, "matched");
							}
						}
                    }
				}                                   //if the input is not all the above just increase postion to avoid infinite loop
				else Next();
			}
			return;
		}
	}
}