using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;

namespace RDCompiler.Lexical_Analyzer
{
    public class SNLToken
    {
        private int _LineNo;
        private SNLLexType _Lex;
        private string _Sem;
        private string _Str;

        public SNLToken(int LineNo, SNLLexType Lex, string Sem, string Str)
        {
            _LineNo = LineNo;
            _Lex = Lex;
            _Sem = Sem;
            _Str = Str;
            if (Lex == SNLLexType.ID)
            {
                foreach (SNLLexType iter in Enum.GetValues(typeof(SNLLexType)))
                {
                    if (iter.ToString() == Sem.ToUpper())
                    {
                        _Lex = iter;
                        _Sem = "无语义信息";
                    }
                }
            }
            else if (Lex == SNLLexType.SINGLED) 
            {
                switch(Str)
                {
                    case ",":
                        _Lex = SNLLexType.COMMA;
                        break;
                    case "+":
                        _Lex = SNLLexType.PLUS;
                        break;
                    case "-":
                        _Lex = SNLLexType.MINUS;
                        break;
                    case "*":
                        _Lex = SNLLexType.TIMES;
                        break;
                    case "/":
                        _Lex = SNLLexType.OVER;
                        break;
                    case "(":
                        _Lex = SNLLexType.LPAREN;
                        break;
                    case ")":
                        _Lex = SNLLexType.RPAREN;
                        break;
                    case "[":
                        _Lex = SNLLexType.LMIDPAREN;
                        break;
                    case "]":
                        _Lex = SNLLexType.RMIDPAREN;
                        break;
                    case ";":
                        _Lex = SNLLexType.SEMI;
                        break;
                    case "<":
                        _Lex = SNLLexType.LT;
                        break;
                    case "=":
                        _Lex = SNLLexType.EQ;
                        break;

                }
            }
        }

        public void SetSNLToken(int LineNo, SNLLexType Lex, string Sem, string Str)
        {
            _LineNo = LineNo;
            _Lex = Lex;
            _Sem = Sem;
            _Str = Str;
        }

        public int GetLineNo()
        {
            return _LineNo;
        }

        public SNLLexType GetLexType()
        {
            return _Lex;
        }

        public string GetSem()
        {
            return _Sem;
        }

        public string GetString()
        {
            return _Str;
        }

        public override string ToString()
        {
            return String.Format(_LineNo.ToString() + "   " + _Lex.ToString() + "   " + _Sem + "\n");
        }
    }
}
