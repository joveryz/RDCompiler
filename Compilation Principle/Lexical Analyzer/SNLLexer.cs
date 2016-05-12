using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;

namespace RDCompiler.Lexical_Analyzer
{
    class SNLLexer
    {
        private int _Pointer = 0;
        private int _LineNo = 1;

        private List<SNLToken> _TokenList = new List<SNLToken>();
        private List<List<string>> _DebugList = new List<List<string>>();

        public void StartLexer(string Content)
        {
            while (_Pointer < Content.Length) 
            {
                if (Content[_Pointer] == '\n')
                    _LineNo++;
                if (Char.IsLetter(Content[_Pointer]))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Content[_Pointer]);
                    while (_Pointer + 1 <= Content.Length - 1 && Char.IsLetterOrDigit(Content[++_Pointer]))
                    {
                        sb.Append(Content[_Pointer]);
                    }
                    if (!Char.IsLetterOrDigit(Content[_Pointer]))
                        _Pointer--;
                    _TokenList.Add(new SNLToken(_LineNo, SNLLexType.ID, sb.ToString(), sb.ToString()));
                }
                else if (Char.IsDigit(Content[_Pointer]))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(Content[_Pointer]);
                    while (_Pointer + 1 <= Content.Length - 1 && Char.IsDigit(Content[++_Pointer]))
                    {
                        sb.Append(Content[_Pointer]);
                    }
                    if (!Char.IsDigit(Content[_Pointer]))
                        _Pointer--;
                    _TokenList.Add(new SNLToken(_LineNo, SNLLexType.INTC, sb.ToString(), sb.ToString()));
                }
                else if (IsSingleDelimiter(Content[_Pointer]))
                {
                    _TokenList.Add(new SNLToken(_LineNo, SNLLexType.SINGLED, "无语义信息", Content[_Pointer].ToString()));
                }
                else if (Content[_Pointer] == ':')
                {
                    if (_Pointer + 1 <= Content.Length - 1 && Content[++_Pointer] == '=')
                        _TokenList.Add(new SNLToken(_LineNo, SNLLexType.ASSIGN, "无语义信息", ":="));
                    else
                    {
                        List<string> s = new List<string>();
                        s.Add(_LineNo.ToString());
                        s.Add(SNLLexType.ASSIGN.ToString());
                        s.Add("UNEXPECTED CHARACTER" + Content[_Pointer] + "AFTER \':\'\n");
                        _DebugList.Add(s);
                    }
                        
                }
                else if (Content[_Pointer] == '{')
                {
                    while (_Pointer + 1 <= Content.Length - 1 && Content[++_Pointer] != '}') { }
                }
                else if (Content[_Pointer] == '.')
                {
                    if (_Pointer + 1 <= Content.Length - 1 && Content[++_Pointer] == '.')
                        _TokenList.Add(new SNLToken(_LineNo, SNLLexType.UNDERANGE, "无语义信息", ".."));
                    else
                    {
                        _Pointer--;
                        if (Char.ToUpper(Content[_Pointer - 1]) != 'D' && Char.ToUpper(Content[_Pointer - 2]) != 'N' && Char.ToUpper(Content[_Pointer - 3]) != 'E')
                        {
                            List<string> s = new List<string>();
                            s.Add(_LineNo.ToString());
                            s.Add(SNLLexType.UNDERANGE.ToString());
                            s.Add("UNEXPECTED DOT\n");
                            _DebugList.Add(s);
                        }
                    }
                }
                else if (Content[_Pointer] == '\'')
                {
                    if (_Pointer + 1 <= Content.Length - 1 && Char.IsLetterOrDigit(Content[++_Pointer]))
                        if (_Pointer + 1 <= Content.Length - 1 && Content[++_Pointer] == '\'')
                            _TokenList.Add(new SNLToken(_LineNo, SNLLexType.CHARC, Content[_Pointer - 1].ToString(), Content[_Pointer - 1].ToString()));
                        else
                        {
                            List<string> s = new List<string>();
                            s.Add(_LineNo.ToString());
                            s.Add(SNLLexType.CHARC.ToString());
                            s.Add("-MORE THAN ONE CHARACTER BETWEEN \"\'\" AND \"\'\"\n");
                            _DebugList.Add(s);
                        }
                }
                else if (Content[_Pointer] != ' ' && Content[_Pointer] != '\n' && Content[_Pointer] != '\r' && Content[_Pointer] != '\t')
                {
                    int x = Content[_Pointer];
                    List<string> s = new List<string>();
                    s.Add(_LineNo.ToString());
                    s.Add(SNLLexType.CHARC.ToString());
                    s.Add("-UNKNOWN CHARACTER-" + x + "\n");
                    _DebugList.Add(s);
                }
                    
                _Pointer++;
            }
            _TokenList.Add(new SNLToken(_LineNo - 1, SNLLexType.ENDFILE, "无语义信息", ""));
        }

        private bool IsSingleDelimiter(char c)
        {
            if (c == ',' || c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')' || c == '[' || c == ']' || c == ';' || c == '<' || c == '=' || c == '\0') 
                return true;
            return false;
        }

        public List<SNLToken> GetTokenList()
        {
            return _TokenList;
        }

        public List<List<string>> GetDebugList()
        {
            return _DebugList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (SNLToken Token in _TokenList)
            {
                sb.Append(Token.ToString());
            }
            return sb.ToString();
        }


    }
}
