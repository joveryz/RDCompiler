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
            private SNLChildType _ChildType;
        }

        struct ProcAttr
        {
            private SNLParamtType _ParamtType;
        }

        struct ExpAttr
        {
            private SNLAttrOPType _OP;
            private int _Val;
            private SNLAttrVarKindType _VarKind;
            private SNLAttrType _Type;
        }

        struct Attr
        {
            object 
            //ArrayAttr _ArrayAttr;
            //ProcAttr _ProcAttr;
            //ExpAttr _ExpAttr;
        }

        private List<SNLTreeNode> _Child;
        private SNLTreeNode _Sibling;
        private int _LinoNo;
        private SNLTreeNodeType _NodeKind;
        private object _Kind;

        //private SNLTreeNodeTypeDecK _KindDec;
        //private SNLTreeNodeTypeExpK _KingExp;
        //private SNLTreeNodeTypeStmtK _StmtK;

        private int _IDNum;
        private List<string> _Name;
        private List<int> _Table;
        private string _TypeName;
        private object _Attr;
    }
}
