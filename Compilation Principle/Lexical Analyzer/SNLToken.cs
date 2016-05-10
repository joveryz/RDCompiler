using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDCompiler.Lexical_Analyzer
{
    class SNLToken
    {
        public enum _SNLLexType { ENDFILE, ERROR, PROGRAM, PROCEDURE, TYPE, VAR, IF, THEN, ELSE, FI, WHILE, DO, ENDWH, BEGIN, END, READ, WRITE, ARRAY, OF, RECORD, RETURN, INTEGER, CHAR, ID, INTC, CHARC, ASSIGN, EQ, LT, PLUS, MINUS, TIMES, OVER, LPAREN, RPAREN, DOT, COLON, SEMI, COMMA, LMIDPAREN, RMIDPAREN, UNDERANGE, SINGLED};
       
        private int _LineNo;
        private _SNLLexType _Lex;
        private string _Sem;
        private string _Str;

        public SNLToken(int LineNo, _SNLLexType Lex, string Sem, string Str)
        {
            _LineNo = LineNo;
            _Lex = Lex;
            _Sem = Sem;
            _Str = Str;
            if (Lex == _SNLLexType.ID)
            {
                foreach (_SNLLexType iter in Enum.GetValues(typeof(_SNLLexType)))
                {
                    if (iter.ToString() == Sem.ToUpper())
                    {
                        _Lex = iter;
                        _Sem = "无语义信息";
                    }
                }
            }
            else if (Lex == _SNLLexType.SINGLED) 
            {
                switch(Str)
                {
                    case ",":
                        _Lex = _SNLLexType.COMMA;
                        break;
                    case "+":
                        _Lex = _SNLLexType.PLUS;
                        break;
                    case "-":
                        _Lex = _SNLLexType.MINUS;
                        break;
                    case "*":
                        _Lex = _SNLLexType.TIMES;
                        break;
                    case "/":
                        _Lex = _SNLLexType.OVER;
                        break;
                    case "(":
                        _Lex = _SNLLexType.LPAREN;
                        break;
                    case ")":
                        _Lex = _SNLLexType.RPAREN;
                        break;
                    case "[":
                        _Lex = _SNLLexType.LMIDPAREN;
                        break;
                    case "]":
                        _Lex = _SNLLexType.RMIDPAREN;
                        break;
                    case ";":
                        _Lex = _SNLLexType.SEMI;
                        break;
                    case "<":
                        _Lex = _SNLLexType.LT;
                        break;
                    case "=":
                        _Lex = _SNLLexType.EQ;
                        break;

                }
            }
        }

        public void SetSNLToken(int LineNo, _SNLLexType Lex, string Sem, string Str)
        {
            _LineNo = LineNo;
            _Lex = Lex;
            _Sem = Sem;
            _Str = Str;
        }

        public string GetLineNo()
        {
            return _LineNo.ToString();
        }

        public string GetLexType()
        {
            return _Lex.ToString();
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
