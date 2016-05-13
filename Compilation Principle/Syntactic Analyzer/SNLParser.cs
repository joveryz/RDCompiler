using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;
using RDCompiler.Lexical_Analyzer;
using System.Windows.Forms;



namespace RDCompiler.Syntactic_Analyzer
{
    class SNLParser
    {
        private List<SNLToken> _TokenList = new List<SNLToken>();
        private SNLTreeNode _Head = new SNLTreeNode();
        private SNLTreeNode _CurrFaNode = new SNLTreeNode();
        private SNLTreeNode _CurrNode = new SNLTreeNode();
        private int _Pointer = -1;

        public bool StartParser(List<SNLToken> TokenList)
        {
            _TokenList = TokenList;

            SNLTreeNode _Head = new SNLTreeNode(_TokenList[_Pointer + 1].GetLineNo(), SNLTreeNodeType.ProK, SNLAttrType.NULL);
            _CurrNode = _Head;
            _CurrFaNode = null;

            if (!MatchProgramHead())
                return false;
            if (!MatchDeclarePart())
                return false;
            if (!MatchProgramBody())
                return false;

            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ENDFILE)
                return false;
            return true;
        }

        public int GetPointer()
        {
            MessageBox.Show("截止至Token" + _Pointer.ToString() + "之前没有错误", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return _Pointer;
        }

        public SNLTreeNode SNLTree()
        {
            return _Head;
        }

        /// <summary>
        /// Match Program Head
        /// </summary>
        /// <returns></returns>
        private bool MatchProgramHead()
        {
            if (_Pointer +1 < _TokenList.Count && _TokenList[++_Pointer].GetLexType() == SNLLexType.PROGRAM)
            {
                _CurrFaNode = _Head;
                _CurrNode = _CurrFaNode.AddChild(new SNLTreeNode(_TokenList[_Pointer].GetLineNo(), SNLTreeNodeType.PheadK, SNLAttrType.NULL));
                return MatchProgramName();
            }
            return false;
        }

        private bool MatchProgramName()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ID)
            {
                _CurrNode.SetTypeName(_TokenList[_Pointer].GetSem());
                return true;
            }
            return false;
        }

        /// <summary>
        /// Match Declare Part
        /// </summary>
        /// <returns></returns>
        private bool MatchDeclarePart()
        {
            if (!MatchTypeDecpart())
                return false;
            if (!MatchVarDecpart())
                return false;
            if (!MatchProcDecpart())
                return false;
            return true;
        }

        /// <summary>
        /// Match Type Declare
        /// </summary>
        /// <returns></returns>
        private bool MatchTypeDecpart()
        {
            MatchTypeDec();
            return true;
        }

        private bool MatchTypeDec()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.TYPE )
            {
                _Pointer--;
                return false;
            }
            else
            {
                SNLTreeNode TypeDec = new SNLTreeNode(_TokenList[_Pointer].GetLineNo(), SNLTreeNodeType.TypeK, SNLAttrType.NULL);
                _CurrNode = _CurrFaNode.AddChild(TypeDec);
                if (!MatchTypeDecList())
                {
                    _Pointer--;
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        private bool MatchTypeDecList()
        {
            if (!MatchTypeId())
                return false;
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.EQ) 
            {
                _Pointer--;
                return false;
            }
            if (!MatchTypeName())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.SEMI)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            return MatchTypeDecMore();
        }

        private bool MatchTypeDecMore()
        {
            MatchTypeDecList();
            return true;
        }

        private bool MatchTypeId()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ID)
            {

                return true;
            }
            else
            {
                _Pointer--;
                return false;
            }
        }

        private bool MatchTypeName()
        {
            if (MatchBaseName())
                return true;
            if (MatchStructureType())
                return true;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ID)
                return true;
            else
            {
                _Pointer--;
                return false;
            }
        }

        private bool MatchBaseName()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.INTEGER)
                return true;
            else
            {
                _Pointer--;
            }
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.CHAR)
                return true;
            else
            {
                _Pointer--;
            }
            return false;
        }

        private bool MatchStructureType()
        {
            if (MatchArrayType())
                return true;
            if (MatchRecType())
                return true;
            return false;
        }

        private bool MatchArrayType()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ARRAY)
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LMIDPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchLow())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.UNDERANGE)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.UNDERANGE)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchTop())
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RMIDPAREN)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.OF)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return MatchBaseName();
        }

        private bool MatchLow()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.INTC)
            {
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchTop()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.INTC)
            {
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchRecType()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RECORD)
            {
                _Pointer--;
                return false;
            }
            if (!MatchFieldDecList())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.END)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchFieldDecList()
        {
            if (MatchBaseName())
                if (MatchIdList())
                    if (_TokenList[++_Pointer].GetLexType() == SNLLexType.SEMI)
                    {
                        if (MatchFieldDecMore())
                            return true;
                    }
                    else
                    {
                        _Pointer--;
                    }
            if (MatchArrayType())
                if (MatchIdList())
                    if (_TokenList[++_Pointer].GetLexType() == SNLLexType.SEMI)
                    {
                        if (MatchFieldDecMore())
                            return true;
                    }
                    else
                    {
                        _Pointer--;
                    }
            return false;
        }

        private bool MatchFieldDecMore()
        {
            MatchFieldDecList();
            return true;
        }

        private bool MatchIdList()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            return MatchIdMore();
        }

        private bool MatchIdMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.COMMA)
                if (MatchIdList())
                {
                    return true;
                }
                else
                {
                    _Pointer--;
                }
            return true;
        }

        private bool MatchVarDecpart()
        {
            MatchVarDec();
            return true;
        }

        private bool MatchVarDec()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.VAR)
            {
                _Pointer--;
                return false;
            }


            if (MatchVarDecList())
                return true;
            else
            {
                _Pointer--;
                return false;
            }
        }

        private bool MatchVarDecList()
        {
            if (!MatchTypeName())
                return false;
            if (!MatchVarIdList())
                return false;
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.SEMI)
            {
                _Pointer--;
                return false;
            }
            if (!MatchVarDecMore())
                return false;
            return true;
        }

        private bool MatchVarDecMore()
        {
            MatchVarDecList();
            return true;
        }

        private bool MatchVarIdList()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            if (!MatchVarIdMore())
                return false;
            return true;
        }

        private bool MatchVarIdMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.COMMA)
            {
                if (MatchVarIdList())
                {
                    return true;
                }
                else
                {
                    _Pointer--;
                }
            }
            else
            {
                _Pointer--;
            }

            return true;
        }

        //过程声明
        private bool MatchProcDecpart()
        {
            MatchProcDec();
            return true;
        }

        private bool MatchProcDec()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.PROCEDURE)
            {
                _Pointer--;
                return false;
            }
            if (!MatchProcName())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchParamList())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RPAREN)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.SEMI)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchProcDecPart())
            {
                _Pointer--;
                return false;
            }
            if (!MatchProcBody())
            {
                _Pointer--;
                return false;
            }
            if (!MatchProcDecMore())
            {
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchProcDecMore()
        {
            MatchProcDec();
            return true;
        }

        private bool MatchProcName()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            return true;
        }
        
        //参数声明
        private bool MatchParamList()
        {
            MatchParamDecList();
            return true;
        }

        private bool MatchParamDecList()
        {
            if (!MatchParam())
                return false;
            if (!MatchParamMore())
                return false;
            return true;
        }

        private bool MatchParamMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.SEMI)
            {
                if (MatchParamDecList())
                    return true;
                else
                    _Pointer--;
            }
            else
            {
                _Pointer--;
            }
            return true;
        }

        private bool MatchParam()
        {
            if (MatchTypeName())
                return MatchFormList();
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.VAR)
            {
                if (MatchTypeName())
                {
                    if (MatchFormList())
                        return true;
                    else
                        _Pointer--;
                }
                else
                {
                    _Pointer--;
                }
            }
            else
            {
                _Pointer--;
            }
            return false;
        }

        private bool MatchFormList()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            if (!MatchFidMore())
            {
                _Pointer--;
                return false;
            }
            else
                return true;
        }

        private bool MatchFidMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.COMMA)
            {
                if (MatchFormList())
                    return true;
                else
                    _Pointer--;
            }
            else
            {
                _Pointer--;
            }
            return true;
        }
        
        //过程中的声明
        private bool MatchProcDecPart()
        {
            return MatchDeclarePart();
        }
        
        //过程体
        private bool MatchProcBody()
        {
            return MatchProgramBody();
        }

        private bool MatchProgramBody()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.BEGIN)
            {
                _Pointer--;
                return false;
            }
            if (!MatchStmList())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.END)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }
        
        //语句序列
        private bool MatchStmList()
        {
            if (!MatchStm())
                return false;
            if (!MatchStmMore())
                return false;
            return true;
        }

        private bool MatchStmMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.SEMI)
            {
                if (MatchStmList())
                    return true;
                else
                {
                    _Pointer--;
                    return false;
                }
            }
            else
                _Pointer--;
            return true;
        }
        
        //语句
        private bool MatchStm()
        {
            if (MatchConditionalStm())
                return true;
            if (MatchLoopStm())
                return true;
            if (MatchInputStm())
                return true;
            if (MatchOutputStm())
                return true;
            if (MatchReturnStm())
                return true;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ID)
                if (MatchAssCall())
                    return true;
                else
                    _Pointer--;
            else
                _Pointer--;
            return false;
        }

        private bool MatchAssCall()
        {
            if (MatchAssignmentRest())
                return true;
            if (MatchCallStmRest())
                return true;
            return false;
        }

        private bool MatchAssignmentRest()
        {
            if (!MatchVariMore())
                return false;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ASSIGN)
            {
                if (!MatchExp())
                {
                    _Pointer--;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                _Pointer--;
                return false;
            }
        }

        private bool MatchConditionalStm()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.IF)
            {
                _Pointer--;
                return false;
            }
            if (!MatchRelExp())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.THEN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchStmList())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ELSE)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchStmList())
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.FI)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchLoopStm()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.WHILE)
            {
                _Pointer--;
                return false;
            }
            if (!MatchRelExp())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.DO)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchStmList())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ENDWH)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchInputStm()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.READ)
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchInvar())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RPAREN)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchInvar()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchOutputStm()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.WRITE)
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchExp())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RPAREN)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchReturnStm()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RETURN)
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (!MatchExp())
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RPAREN)
            {
                _Pointer--;
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchCallStmRest()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.LPAREN)
            {
                _Pointer--;
                return false;
            }
            if (!MatchActParamList())
            {
                _Pointer--;
                return false;
            }
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RPAREN)
            {
                _Pointer--;
                _Pointer--;
                return false;
            }
            return true;
        }

        private bool MatchActParamList()
        {
            if (!MatchExp())
                return MatchActParamMore();
            return true;
        }

        private bool MatchActParamMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.SEMI)
            {
                if (MatchActParamList())
                    return true;
                else
                {
                    _Pointer--;
                    return false;
                }
            }
            else
                _Pointer--;
            return true;
        }

        private bool MatchRelExp()
        {
            if (!MatchExp())
                return false;
            if (!MatchOtherRelE())
                return false;
            return true;
        }

        private bool MatchOtherRelE()
        {
            if (!MatchCmpOp())
                return false;
            if (!MatchExp())
                return false;
            return true;
        }

        private bool MatchExp()
        {
            if (!MatchTerm())
                return false;
            if (!MatchOtherTerm())
                return false;
            return true;
        }

        private bool MatchOtherTerm()
        {
            if (MatchAddOp())
                return MatchExp();
            return true;
        }

        private bool MatchTerm()
        {
            if (!MatchFactor())
                return false;
            if (!MatchOtherFactor())
                return false;
            return true;
        }

        private bool MatchOtherFactor()
        {
            if (MatchMultOp())
                return MatchTerm();
            return true;
        }

        private bool MatchFactor()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.LPAREN)
            {
                if (MatchExp())
                {
                    if (_TokenList[++_Pointer].GetLexType() == SNLLexType.RPAREN)
                        return true;
                    else
                    {
                        _Pointer--;
                        _Pointer--;
                        return false;
                    }
                }
                else
                {
                    _Pointer--;
                    return false;
                }
            }
            else
            {
                _Pointer--;
            }


            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.INTC)
                return true;
            else
            {
                _Pointer--;
            }
            if (MatchVariable())
                return true;
            return false;

        }

        private bool MatchVariable()
        {
            if (_TokenList[++_Pointer].GetLexType() != SNLLexType.ID)
            {
                _Pointer--;
                return false;
            }
            return MatchVariMore();
        }

        private bool MatchVariMore()
        {
            bool flag = true;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.LMIDPAREN)
            {
                if (MatchExp())
                {
                    if (_TokenList[++_Pointer].GetLexType() == SNLLexType.RMIDPAREN)
                    {
                        return true;
                    }
                    else
                    {
                        _Pointer--;
                        _Pointer--;
                        return false;
                    }
                }
                else
                {
                    _Pointer--;
                    return false;
                }
            }
            else
            {
                _Pointer--;
            }
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.DOT)
                if (MatchFieldVar())
                    return true;
                else
                {
                    _Pointer--;
                    return false;
                }
            else
            {
                _Pointer--;
            }
            return true;
        }

        private bool MatchFieldVar()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.ID)
            {
                if (MatchFieldVarMore())
                    return true;
                else
                {
                    _Pointer--;
                    return false;
                }
            }
            else
            {
                _Pointer--;
                return false;
            }
        }

        private bool MatchFieldVarMore()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.LMIDPAREN)
            {
                if (!MatchExp())
                {
                    _Pointer--;
                    return false;
                }
                if (_TokenList[++_Pointer].GetLexType() != SNLLexType.RMIDPAREN)
                {
                    _Pointer--;
                    return false;
                }
            }
            else
            {
                _Pointer--;
            }
            return true;
        }

        private bool MatchCmpOp()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.LT)
                return true;
            else
                _Pointer--;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.EQ)
                return true;
            else
                _Pointer--;
            return false;
        }

        private bool MatchAddOp()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.PLUS)
                return true;
            else
                _Pointer--;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.MINUS)
                return true;
            else
                _Pointer--;
            return false;
        }

        private bool MatchMultOp()
        {
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.TIMES)
                return true;
            else
                _Pointer--;
            if (_TokenList[++_Pointer].GetLexType() == SNLLexType.OVER)
                return true;
            else
                _Pointer--;
            return false;
        }
        
    }
}
