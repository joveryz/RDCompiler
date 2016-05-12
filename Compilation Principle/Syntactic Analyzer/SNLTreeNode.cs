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
        struct ArrayAttr
        {
            private int _Low;
            private int _Up;
            private SNLArrayChildType _ChildType;

            public void SetArrayAttr(int Low, int Up, SNLArrayChildType ChildType)
            {
                _Low = Low;
                _Up = Up;
                _ChildType = ChildType;
            }
        }

        struct ProcAttr
        {
            private SNLProcParamtType _ParamtType;


            public void SetProcAttr(SNLProcParamtType ParamtType)
            {
                _ParamtType = ParamtType;
            }
        }

        struct ExpAttr
        {
            private SNLExpAttrOPType _OP;
            private int _Val;
            private SNLExpAttrVarKindType _VarKind;
            private SNLExpAttrType _Type;

            public void SetExpAttr(SNLExpAttrOPType OP, int Val, SNLExpAttrVarKindType VarKind, SNLExpAttrType Type)
            {
                _OP = OP;
                _Val = Val;
                _VarKind = VarKind;
                _Type = Type;
            }
        }

        struct Attr
        {
            //ArrayAttr _ArrayAttr;
            //ProcAttr _ProcAttr;
            //ExpAttr _ExpAttr;
        }

        private List<SNLTreeNode> _Child;
        private SNLTreeNode _Sibling;
        private int _LineNo = -1;
        private SNLTreeNodeType _NodeKind;
        
        private object _Kind;
        //private SNLTreeNodeTypeDecK _KindDec;
        //private SNLTreeNodeTypeExpK _KingExp;
        //private SNLTreeNodeTypeStmtK _StmtK;

        private int _IDNum = 0;
        private List<string> _Name;
        private List<int> _Table;

        private string _TypeName;

        private SNLAttrType _AttrType;
        private object _Attr;

        public SNLTreeNode(SNLTreeNode Sibling, int LineNo, SNLTreeNodeType NodeKind, SNLAttrType AttrType)
        {
            _Sibling = Sibling;
            _LineNo = LineNo;
            _NodeKind = NodeKind;
            _AttrType = AttrType;
        }

        public void AddChild(SNLTreeNode Child)
        {
            _Child.Add(Child);
        }

        public void AddID(string Name, int Table)
        {
            _IDNum++;
            _Name.Add(Name);
            _Table.Add(Table);
        }

        public void SetTypeName(string TypeName)
        {
            _TypeName = TypeName;
        }

        public void SetKind()
        {
            switch (_NodeKind)
            {
                case SNLTreeNodeType.DecK:
                    _Kind = new SNLTreeNodeTypeDecK();
                    break;
                case SNLTreeNodeType.StmtK:
                    _Kind = new SNLTreeNodeTypeStmtK();
                    break;
                case SNLTreeNodeType.ExpK:
                    _Kind = new SNLTreeNodeTypeExpK();
                    break;
            }
        }

        public void SetAttr()
        {
            switch(_AttrType)
            {
                case SNLAttrType.ArrayAttr:
                    _Attr = new ArrayAttr();
                    break;
                case SNLAttrType.ProcAttr:
                    _Attr = new ProcAttr();
                    break;
                case SNLAttrType.ExpAttr:
                    _Attr = new ExpAttr();
                    break;
            }
        }

    }
}
