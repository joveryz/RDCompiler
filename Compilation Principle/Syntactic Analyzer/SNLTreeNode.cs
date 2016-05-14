using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;

namespace RDCompiler.Syntactic_Analyzer
{
    class SNLTreeNode
    {
        struct Kind
        {
            public SNLTreeNodeTypeStmt _Stmt;
            public SNLTreeNodeTypeDec _Dec;
            public SNLTreeNodeTypeExp _Exp;
        }

        struct ArrayAttr
        {
            public int _Low;
            public int _Up;
            public SNLTreeNodeTypeDec _ChildType;
        }

        struct ProcAttr
        {
            public SNLProcParamtType _ParamtType;
        }

        struct ExpAttr
        {
            public SNLLexType _OP;
            public int _Val;
            public SNLExpAttrVarKindType _VarKind;
            public SNLExpAttrType _Type;
        }

        struct Attr
        {
            public bool Array;
            public ArrayAttr _ArrayAttr;

            public bool Proc;
            public ProcAttr _ProcAttr;

            public bool Exp;
            public ExpAttr _ExpAttr;
            
            public string _TypeName;
        }

        private List<SNLTreeNode> _Child=new List<SNLTreeNode>();
        private SNLTreeNode _Sibling;
        private int _LineNo = -1;
        private SNLTreeNodeType _NodeKind = new SNLTreeNodeType();
        
        private Kind _Kind;

        private int _IDNum = 0;
        private List<string> _Name = new List<string>();
        //private List<int> _Table = new List<int>();语义分析用


        private Attr _Attr;

        public SNLTreeNode AddChild(SNLTreeNode Child)
        {
            _Child.Add(Child);
            return Child;
        }

        public SNLTreeNode GetChild(int index)
        {
            return _Child[index];
        }

        public void SetSibling(SNLTreeNode Sibling)
        {
            _Sibling = Sibling;
        }

        public void SetNodeKind(SNLTreeNodeType NodeKind)
        {
            _NodeKind = NodeKind;
        }

        public void SetLineNo(int Line)
        {
            _LineNo = Line;
        }
        
        public void SetKindStmt(SNLTreeNodeTypeStmt Stmt)
        {
            _Kind._Stmt = Stmt;
        }

        public void SetKindDec(SNLTreeNodeTypeDec Dec)
        {
            _Kind._Dec = Dec;
        }

        public SNLTreeNodeTypeDec GetKindDec()
        {
            return _Kind._Dec;
        }

        public void SetKindExp(SNLTreeNodeTypeExp Exp)
        {
            _Kind._Exp = Exp;
        }

        public void AddName(string Name)
        {
            _IDNum++;
            _Name.Add(Name);
        }

        public void SetAttrTypeName(string TypeName)
        {
            _Attr._TypeName = TypeName;
        }
        
        public void SetAttrArray(int Low, int Up)
        {
            _Attr._ArrayAttr._Low = Low;
            _Attr._ArrayAttr._Up = Up;
            _Attr.Array = true;
            _Attr.Proc = false;
            _Attr.Exp = false;
        }

        public void SetAttrArray(SNLTreeNodeTypeDec ChildType)
        {
            _Attr._ArrayAttr._ChildType = ChildType;
            _Attr.Array = true;
            _Attr.Proc = false;
            _Attr.Exp = false;
        }

        public void SetAttrProc(SNLProcParamtType ParamtType)
        {
            _Attr._ProcAttr._ParamtType = ParamtType;
            _Attr.Array = false;
            _Attr.Proc = true;
            _Attr.Exp = false;
        }

        public void SetAttrExp(SNLLexType OP)
        {
            _Attr._ExpAttr._OP = OP;
            _Attr.Array = false;
            _Attr.Proc = false;
            _Attr.Exp = true;
        }

        public void SetAttrExp(int Val)
        {
            _Attr._ExpAttr._Val = Val;
            _Attr.Array = false;
            _Attr.Proc = false;
            _Attr.Exp = true;
        }

        public void SetAttrExp(SNLExpAttrVarKindType VarKind)
        {
            _Attr._ExpAttr._VarKind = VarKind;
            _Attr.Array = false;
            _Attr.Proc = false;
            _Attr.Exp = true;
        }

        public void SetAttrExp(SNLExpAttrType Type)
        {
            _Attr._ExpAttr._Type = Type;
            _Attr.Array = false;
            _Attr.Proc = false;
            _Attr.Exp = true;
        }
        
    }
}
