using System;

enum SyntaxKind
{
    NumberToken,
}

public class SyntaxToken
{
	public SyntaxToken(SyntaxKind kind, int postion, string text)
    {
        kind = kind;
        postion = postion;
        text = text;
    }
    public SyntaxKind Kind { get; }
    public int Position { get; }
    public string Text { get; }
}

public class Lexer
{
	private readonly string _text;
	private int _postion;
	public Lexer(string text)
	{
		_text = text;
	}

	private char Current
    {
        get
        {
            if (_postion >= _text.Length)                   //if we go outside the boundry of the file return \0
                return '\0';
            return _text[_postion]                          //otherwise we return the char of that postion
        }
    }

    private void Next()
    {
        _postion++;
    }

	public SyntaxToken NextToken()
    {
        if (char.IsDigit(Current))
        {
            var start = _postion;                           //to know track from where to begun checking

            while (char.IsDigit(Current))                   //////////////////////////////////
                Next();                                     //continue checking digits to know where is the end of the number
            var len = _postion - start;
            var text = _text.Substring(start, len);           //////////////////////////////////
            return new SyntaxToken(SyntaxKind.NumberToken, start, text);
        }
    }
}

