using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;
using RDCompiler.Lexical_Analyzer;



namespace RDCompiler.Syntactic_Analyzer
{
    class SNLParser
    {
        private List<SNLToken> _TokenList;
        private SNLTreeNode _Head;
        private SNLTreeNode _CurrNode;
        private int _Pointer = 0;

        public bool StartParser(List<SNLToken> TokenList)
        {
            _Head = new SNLTreeNode(null, _TokenList[_Pointer].GetLineNo(), SNLTreeNodeType.ProK, SNLAttrType.NULL);
            _CurrNode = _Head;
            _TokenList = TokenList;
            if (!MatchProgramHead())
                return false;
            if (!MatchDeclarePart())
                return false;
            if (!MatchProgramBody())
                return false;
            if (_TokenList[_Pointer].GetLexType() != SNLLexType.END)
                return false;
            return true;
        }

        private bool MatchProgramHead()
        {
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.PROGRAM)
            {
                SNLTreeNode Child = new SNLTreeNode(_CurrNode, _TokenList[_Pointer].GetLineNo(),SNLTreeNodeType.PheadK, SNLAttrType.NULL);
                _Head.AddChild(Child);
                _CurrNode = Child;
                return MatchProgramName();
            }
            return false;
        }

        private bool MatchProgramName()
        {
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.ID)
            {
                _CurrNode.SetTypeName(_TokenList[_Pointer].GetSem());
                return true;
            }
            return false;
        }

        private bool MatchDeclarePart()
        {
            throw new NotImplementedException();
        }

        private bool MatchProgramBody()
        {
            throw new NotImplementedException();
        }
    }
}
