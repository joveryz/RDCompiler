using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RDCompiler.Language;
using RDCompiler.Lexical_Analyzer;
using System.Windows.Forms;
using System.Data;

namespace RDCompiler.Syntactic_Analyzer
{
    class SNLParser
    {
        private List<SNLToken> _TokenList = new List<SNLToken>();
        private List<List<string>> _DebugList = new List<List<string>>();
        private SNLTreeNode _Root = new SNLTreeNode();
        private SNLTreeNode _CurrFaNode = new SNLTreeNode();
        private SNLTreeNode _CurrNode = new SNLTreeNode();
        private DataTable _DataTable = new DataTable();
        private int _Pointer = -1;
        private int _Index = 0;
        private string TempName;

        public void StartParser(List<SNLToken> TokenList)
        {
            _TokenList = TokenList;
            _Root = parse();
            InitDataTable();
            FillDataTable(_Root, 0);
            for (int i = 0; i < _DataTable.Columns.Count; i++)
            {
                _DataTable.Columns[i].ReadOnly = true;
            }

        }

        public int GetPointer()
        {
            MessageBox.Show("截止至Token" + _Pointer.ToString() + "之前没有错误", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return _Pointer;
        }

        public SNLTreeNode GetRoot()
        {
            return _Root;
        }
        
        public List<List<string>> GetDebugList()
        {
            return _DebugList;
        }

        public DataTable GetDataTable()
        {
            return _DataTable;
        }

        public void InitDataTable()
        {

            _DataTable.Columns.Add("NodeKind", typeof(string));
            _DataTable.Columns.Add("ID", typeof(string));
            _DataTable.Columns.Add("ParentID", typeof(string));
            _DataTable.Columns.Add("NodeID", typeof(string));
            _DataTable.Columns.Add("Priview", typeof(string));
            _DataTable.Columns.Add("Child", typeof(string));
            _DataTable.Columns.Add("Sibling", typeof(string));
            _DataTable.Columns.Add("LineNo", typeof(string));
            _DataTable.Columns.Add("K_Dec", typeof(string));
            _DataTable.Columns.Add("K_Stmt", typeof(string));
            _DataTable.Columns.Add("K_Exp", typeof(string));
            _DataTable.Columns.Add("ID_Num", typeof(string));
            _DataTable.Columns.Add("Name", typeof(string));
            _DataTable.Columns.Add("Table", typeof(string));
            _DataTable.Columns.Add("Attr", typeof(string));
            _DataTable.Columns.Add("TypeName", typeof(string));
            _DataTable.Columns.Add("AA_Low", typeof(string));
            _DataTable.Columns.Add("AA_Up", typeof(string));
            _DataTable.Columns.Add("AA_ChildType", typeof(string));
            _DataTable.Columns.Add("PA_Paramt", typeof(string));
            _DataTable.Columns.Add("EA_Op", typeof(string));
            _DataTable.Columns.Add("EA_Val", typeof(string));
            _DataTable.Columns.Add("EA_VarKind", typeof(string));
            _DataTable.Columns.Add("EA_Type", typeof(string));
        }

        public void FillDataTable(SNLTreeNode tree, int level)
        {
            while (tree != null)
            {
                string NodeKind = tree.GetNodeKind().ToString();
                string ID = (_Index++).ToString();
                string ParentID = level.ToString();
                string NodeID = ID;
                string Preview = printTree(tree, 0).ToString();
                string Child = tree.GetChildCount().ToString();
                string Sibling;
                if (tree.GetSibling() != null)
                    Sibling = "1";
                else
                    Sibling = "0";
                string LineNo = tree.GetLineNo().ToString();
                string K_Dec = tree.GetKindDec().ToString();
                string K_Stmt = tree.GetKindStmt().ToString();
                string K_Exp = tree.GetKindExp().ToString();
                string IDNum = tree.GetIDNum().ToString();
                string Name = "NULL";
                if (IDNum != "0")
                {
                    Name = "";
                    for (int i = 0; i < tree.GetIDNum(); i++)
                        Name = Name + tree.GetName(i) + "|";
                }
                string Table = "NULL";
                string Attr = tree.GetAttrType();
                string AttrTypeName = tree.GetAttrTypeName();
                if (AttrTypeName == null)
                    AttrTypeName = "NULL";
                string AA_Low = tree.GetAttrArrayLow().ToString();
                string AA_Up = tree.GetAttrArrayUp().ToString();
                string AA_ChildType = tree.GetAttrArrayChildType().ToString();
                string PA_Paramt = tree.GetAttrProcParamtType().ToString();
                string EA_OP = tree.GetAttrExpOP().ToString();
                string EA_Val = tree.GetAttrExpVal().ToString();
                string EA_VarKind = tree.GetAttrExpVarKind().ToString();
                string EA_Type = tree.GetAttrExpType().ToString();
                _DataTable.Rows.Add(new object[] { NodeKind, ID, ParentID, NodeID, Preview, Child, Sibling, LineNo, K_Dec, K_Stmt, K_Exp, IDNum, Name, Table, Attr, AttrTypeName, AA_Low, AA_Up, AA_ChildType, PA_Paramt, EA_OP, EA_Val, EA_VarKind, EA_Type });

                for (int i = 0; i < tree.GetChildCount(); i++)
                    FillDataTable(tree.GetChild(i), int.Parse(ID));

                tree = tree.GetSibling();
            }
        }

        private void printSpaces()
        {
            int i;
            for (i = 0; i < indentno; i++)
                Console.Write(" ");
        }
        
        private void AddDebugInfo(SNLLexType LexType)
        {
            List<string> debug = new List<string>();
            debug.Add(_TokenList[_Pointer - 1].GetLineNo().ToString());
            debug.Add(LexType.ToString());
            debug.Add("A "+LexType.ToString()+" type toekn is expected!");
            _DebugList.Add(debug);
        }
        private void printTab(int tabnum)
        {
            for (int i = 0; i < tabnum; i++)
                Console.Write(" ");
        }

        int indentno = 0;
        bool Error = false;

        public void printTree(SNLTreeNode tree)
        {
            int i;
            while (tree != null)
            {
                if (tree.GetLineNo() == 0)
                    printTab(9);
                else
                    switch ((int)(tree.GetLineNo() / 10))
                    {
                        case 0:
                            Console.Write("line" + tree.GetLineNo());
                            printTab(3);
                            break;
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            Console.Write("line" + tree.GetLineNo());
                            printTab(2);
                            break;
                        default:
                            Console.Write("line" + tree.GetLineNo());
                            printTab(1);
                            break;
                    }
                printSpaces();
                switch (tree.GetNodeKind())
                {
                    case SNLTreeNodeType.ProK:
                        Console.Write("ProK  "); break;
                    case SNLTreeNodeType.PheadK:
                        {
                            Console.Write("PheadK  ");
                            Console.Write(tree.GetName(0) + "  ");
                        }
                        break;
                    case SNLTreeNodeType.DecK:
                        {
                            Console.Write("DecK  ");
                            if (tree.GetAttrProcParamtType() == SNLProcParamtType.VARPARAMTYPE)
                                Console.Write("var param:  ");
                            if (tree.GetAttrProcParamtType() == SNLProcParamtType.VALPARAMTYPE)
                                Console.Write("value param:  ");
                            switch (tree.GetKindDec())
                            {
                                case SNLTreeNodeTypeDec.ArrayK:
                                    Console.Write("ArrayK  ");
                                    Console.Write(tree.GetAttrArrayUp() + "  ");
                                    Console.Write(tree.GetAttrArrayLow() + "  ");
                                    if (tree.GetAttrArrayChildType() == SNLTreeNodeTypeDec.CharK)
                                        Console.Write("Chark  ");
                                    else if (tree.GetAttrArrayChildType() == SNLTreeNodeTypeDec.IntegerK)
                                        Console.Write("IntegerK  ");
                                    break;
                                case SNLTreeNodeTypeDec.CharK:
                                    Console.Write("CharK  "); break;
                                case SNLTreeNodeTypeDec.IntegerK:
                                    Console.Write("IntegerK  "); break;
                                case SNLTreeNodeTypeDec.RecordK:
                                    Console.Write("RecordK  "); break;
                                case SNLTreeNodeTypeDec.IdK:
                                    Console.Write("IdK  ");
                                    Console.Write(tree.GetAttrTypeName() + "  ");
                                    break;
                                default:
                                    Console.Write("error1!");
                                    Error = true;
                                    break;
                            };
                            if (tree.GetIDNum() != 0)
                                for (int ii = 0; ii < tree.GetIDNum(); ii++)
                                {
                                    Console.Write(tree.GetName(ii) + "  ");
                                }
                            else
                            {
                                Console.Write("wrong!no var!\n");
                                Error = true;
                            }
                        }
                        break;
                    case SNLTreeNodeType.TypeK:
                        Console.Write("TypeK  "); break;

                    case SNLTreeNodeType.VarK:
                        Console.Write("VarK  ");
                        break;

                    case SNLTreeNodeType.ProcDecK:
                        Console.Write("ProcDecK  ");
                        Console.Write(tree.GetName(0) + "  ");
                        break;
                    case SNLTreeNodeType.StmLK:
                        Console.Write("StmLk  "); break;

                    case SNLTreeNodeType.StmtK:
                            Console.Write("StmtK  ");
                            switch (tree.GetKindStmt())
                            {
                                case SNLTreeNodeTypeStmt.IfK:
                                    Console.Write("If  "); break;
                                case SNLTreeNodeTypeStmt.WhileK:
                                    Console.Write("While  "); break;

                                case SNLTreeNodeTypeStmt.AssignK:
                                    Console.Write("Assign  ");
                                    break;
                                case SNLTreeNodeTypeStmt.ReadK:
                                    Console.Write("Read  ");
                                    Console.Write(tree.GetName(0) + "  ");
                                    break;
                                case SNLTreeNodeTypeStmt.WriteK:
                                    Console.Write("Write  "); break;

                                case SNLTreeNodeTypeStmt.CallK:
                                    Console.Write("Call  ");
                                    break;
                                case SNLTreeNodeTypeStmt.ReturnK:
                                    Console.Write("Return  "); break;
                                default:
                                    Console.Write("error2!");
                                    Error = true;
                                    break;
                            }
                        break;
                    case SNLTreeNodeType.ExpK:
                        {
                            Console.Write("ExpK  ");
                            switch (tree.GetKindExp())
                            {
                                case SNLTreeNodeTypeExp.OpK:
                                        Console.Write("Op  ");
                                        switch (tree.GetAttrExpOP())
                                        {
                                            case SNLLexType.EQ:
                                                Console.Write("=  ");
                                                break;
                                            case SNLLexType.LT:
                                                Console.Write("<  ");
                                                break;
                                            case SNLLexType.PLUS:
                                                Console.Write("+  ");
                                                break;
                                            case SNLLexType.MINUS:
                                                Console.Write("-  ");
                                                break;
                                            case SNLLexType.TIMES:
                                                Console.Write("*  ");
                                                break;
                                            case SNLLexType.OVER:
                                                Console.Write("/  ");
                                                break;
                                            default:
                                                Console.Write("error3!");
                                                Error = true;
                                                break;
                                        }
                                        if (tree.GetAttrExpVarKind() == SNLExpAttrVarKindType.ArrayMembV)
                                        {
                                            Console.Write("ArrayMember  ");
                                            Console.Write(tree.GetName(0) + "  ");
                                        }
                                    break;
                                case SNLTreeNodeTypeExp.ConstK:
                                    Console.Write("Const  ");
                                    switch (tree.GetAttrExpVarKind())
                                    {
                                        case SNLExpAttrVarKindType.IdV:
                                            Console.Write("Id  ");
                                            Console.Write(tree.GetAttrExpVal() + "  ");
                                            break;
                                        case SNLExpAttrVarKindType.FieldMembV:
                                            Console.Write("FieldMember  ");
                                            Console.Write(tree.GetAttrExpVal() + "  ");
                                            break;
                                        case SNLExpAttrVarKindType.ArrayMembV:
                                            Console.Write("ArrayMember  ");
                                            Console.Write(tree.GetAttrExpVal() + "  ");
                                            break;
                                        default:
                                            Console.Write("var type error!");
                                            Error = true;
                                            break;
                                    }
                                    break;
                                case SNLTreeNodeTypeExp.VariK:
                                    Console.Write("Vari  ");
                                    switch (tree.GetAttrExpVarKind())
                                    {
                                        case SNLExpAttrVarKindType.IdV:
                                            Console.Write("Id  ");
                                            Console.Write(tree.GetName(0) + "  ");
                                            break;
                                        case SNLExpAttrVarKindType.FieldMembV:
                                            Console.Write("FieldMember  ");
                                            Console.Write(tree.GetName(0) + "  ");
                                            break;
                                        case SNLExpAttrVarKindType.ArrayMembV:
                                            Console.Write("ArrayMember  ");
                                            Console.Write(tree.GetName(0) + "  ");
                                            break;
                                        default:
                                            Console.Write("var type error!");
                                            Error = true;
                                            break;
                                    }
                                    break;
                                default:
                                    Console.Write("error4!");
                                    Error = true;
                                    break;
                            }
                        }; break;
                    default:
                        Console.Write("error5!");
                        Error = true;
                        break;
                }

                Console.Write("\n");
                for (i = 0; i < tree.GetChildCount(); i++)
                    printTree(tree.GetChild(i));
                tree = tree.GetSibling();
            }
            indentno -= 4;
        }

        public StringBuilder printTree(SNLTreeNode tree, int x)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Line:" + tree.GetLineNo() + " ");
            switch (tree.GetNodeKind())
            {
                case SNLTreeNodeType.ProK:
                    sb.Append("Prok ");
                    break;
                case SNLTreeNodeType.PheadK:
                    sb.Append("PheadK " + tree.GetName(0) + " ");
                    break;
                case SNLTreeNodeType.DecK:
                    {
                        sb.Append("DecK ");
                        if (tree.GetAttrProcParamtType() == SNLProcParamtType.VARPARAMTYPE)
                            sb.Append("VARPARAMTYPE: ");
                        if (tree.GetAttrProcParamtType() == SNLProcParamtType.VALPARAMTYPE)
                            sb.Append("VALPARAMTYPE: ");
                        switch (tree.GetKindDec())
                        {
                            case SNLTreeNodeTypeDec.ArrayK:
                                sb.Append("ArrayK ");
                                sb.Append(tree.GetAttrArrayUp() + " ");
                                sb.Append(tree.GetAttrArrayLow() + " ");
                                if (tree.GetAttrArrayChildType() == SNLTreeNodeTypeDec.CharK)
                                    sb.Append("Chark ");
                                else if (tree.GetAttrArrayChildType() == SNLTreeNodeTypeDec.IntegerK)
                                    sb.Append("IntegerK ");
                                break;
                            case SNLTreeNodeTypeDec.CharK:
                                sb.Append("CharK "); break;
                            case SNLTreeNodeTypeDec.IntegerK:
                                sb.Append("IntegerK "); break;
                            case SNLTreeNodeTypeDec.RecordK:
                                sb.Append("RecordK "); break;
                            case SNLTreeNodeTypeDec.IdK:
                                sb.Append("IdK ");
                                sb.Append(tree.GetAttrTypeName() + " ");
                                break;
                        };
                        if (tree.GetIDNum() != 0)
                            for (int ii = 0; ii < tree.GetIDNum(); ii++)
                            {
                                sb.Append(tree.GetName(ii) + " ");
                            }
                    }
                    break;
                case SNLTreeNodeType.TypeK:
                    sb.Append("TypeK ");
                    break;
                case SNLTreeNodeType.VarK:
                    sb.Append("VarK ");
                    break;
                case SNLTreeNodeType.ProcDecK:
                    sb.Append("ProcDecK ");
                    sb.Append(tree.GetName(0) + "  ");
                    break;
                case SNLTreeNodeType.StmLK:
                    sb.Append("StmLk ");
                    break;
                case SNLTreeNodeType.StmtK:
                    sb.Append("StmtK ");
                    switch (tree.GetKindStmt())
                    {
                        case SNLTreeNodeTypeStmt.IfK:
                            sb.Append("IfK ");
                            break;
                        case SNLTreeNodeTypeStmt.WhileK:
                            sb.Append("WhileK ");
                            break;

                        case SNLTreeNodeTypeStmt.AssignK:
                            sb.Append("AssignK ");
                            break;
                        case SNLTreeNodeTypeStmt.ReadK:
                            sb.Append("ReadK ");
                            sb.Append(tree.GetName(0) + " ");
                            break;
                        case SNLTreeNodeTypeStmt.WriteK:
                            sb.Append("WriteK ");
                            break;
                        case SNLTreeNodeTypeStmt.CallK:
                            sb.Append("CallK ");
                            break;
                        case SNLTreeNodeTypeStmt.ReturnK:
                            sb.Append("ReturnK ");
                            break;
                    }
                    break;
                case SNLTreeNodeType.ExpK:
                    sb.Append("ExpK ");
                    switch (tree.GetKindExp())
                    {
                        case SNLTreeNodeTypeExp.OpK:
                            {
                                sb.Append("OpK ");
                                switch (tree.GetAttrExpOP())
                                {
                                    case SNLLexType.EQ:
                                        sb.Append("= ");
                                        break;
                                    case SNLLexType.LT:
                                        sb.Append("< ");
                                        break;
                                    case SNLLexType.PLUS:
                                        sb.Append("+ ");
                                        break;
                                    case SNLLexType.MINUS:
                                        sb.Append("- ");
                                        break;
                                    case SNLLexType.TIMES:
                                        sb.Append("* ");
                                        break;
                                    case SNLLexType.OVER:
                                        sb.Append("/ ");
                                        break;
                                }
                                if (tree.GetAttrExpVarKind() == SNLExpAttrVarKindType.ArrayMembV)
                                {
                                    sb.Append("ArrayMemberV ");
                                    sb.Append(tree.GetName(0) + " ");
                                }
                            }; break;
                        case SNLTreeNodeTypeExp.ConstK:
                            sb.Append("ConstK ");
                            switch (tree.GetAttrExpVarKind())
                            {
                                case SNLExpAttrVarKindType.IdV:
                                    sb.Append("IdV ");
                                    sb.Append(tree.GetAttrExpVal() + " ");
                                    break;
                                case SNLExpAttrVarKindType.FieldMembV:
                                    sb.Append("FieldMemberV ");
                                    sb.Append(tree.GetAttrExpVal() + " ");
                                    break;
                                case SNLExpAttrVarKindType.ArrayMembV:
                                    sb.Append("ArrayMemberV ");
                                    sb.Append(tree.GetAttrExpVal() + " ");
                                    break;
                            }
                            break;
                        case SNLTreeNodeTypeExp.VariK:
                            sb.Append("VariK ");
                            switch (tree.GetAttrExpVarKind())
                            {
                                case SNLExpAttrVarKindType.IdV:
                                    sb.Append("IdV ");
                                    sb.Append(tree.GetName(0) + " ");
                                    break;
                                case SNLExpAttrVarKindType.FieldMembV:
                                    sb.Append("FieldMemberV ");
                                    sb.Append(tree.GetName(0) + " ");
                                    break;
                                case SNLExpAttrVarKindType.ArrayMembV:
                                    sb.Append("ArrayMemberV ");
                                    sb.Append(tree.GetName(0) + " ");
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return sb;
        }

        private SNLTreeNode newRootNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.ProK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newPheadNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.PheadK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newDecANode(SNLTreeNodeType NodeKind)
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(NodeKind);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newTypeNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.TypeK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newVarNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.VarK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newDecNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.DecK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newProcNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.ProcDecK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newStmlNode()
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.StmLK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            return temp;
        }

        private SNLTreeNode newStmtNode(SNLTreeNodeTypeStmt Stmt)
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.StmtK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            temp.SetKindStmt(Stmt);
            return temp;
        }

        private SNLTreeNode newExpNode(SNLTreeNodeTypeExp Exp)
        {
            SNLTreeNode temp = new SNLTreeNode();
            temp.SetNodeKind(SNLTreeNodeType.ExpK);
            temp.SetLineNo(_TokenList[_Pointer].GetLineNo());
            temp.SetKindExp(Exp);
            temp.SetAttrExp(SNLExpAttrVarKindType.IdV);
            temp.SetAttrExp(SNLExpAttrType.Void);
            return temp;
        }

        private bool ReadToken()
        {
            if (_Pointer + 1 <= _TokenList.Count)
            {
                _Pointer++;
                return true;
            }
            return false;
        }

        private bool match(SNLLexType LexType)
        {
            if (_Pointer<_TokenList.Count && _TokenList[_Pointer].GetLexType() == LexType)
            {
                ReadToken();
                return true;
            }
            ReadToken();
            AddDebugInfo(LexType);
            return false;
        }

        private SNLTreeNode program()
        {
            SNLTreeNode root = newRootNode();
            SNLTreeNode t = programHead();
            SNLTreeNode q = declarePart();
            SNLTreeNode s = programBody();
            if (t != null)
                root.AddChild(t);
            else
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A Pprogram head is expected!");
                _DebugList.Add(debug);
            }
            if (q != null)
                root.AddChild(q);
            if (s != null)
                root.AddChild(s);
            else
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A Program body is expected!");
                _DebugList.Add(debug);
            }
            match(SNLLexType.DOT);
            return root;
        }

        private SNLTreeNode programHead()
        {
            SNLTreeNode temp = newPheadNode();
            match(SNLLexType.PROGRAM);
            if ((temp != null) && (_TokenList[_Pointer].GetLexType() == SNLLexType.ID))
            {
                temp.AddName(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.ID);
            return temp;
        }

        private SNLTreeNode declarePart()
        {
            SNLTreeNode typeP = newDecANode(SNLTreeNodeType.TypeK);
            SNLTreeNode pp = typeP;
            if (typeP != null)
            {
                SNLTreeNode tp1 = typeDec();
                if (tp1 != null)
                    typeP.AddChild(tp1);
                else
                    typeP = null;
            }
            SNLTreeNode varP = newDecANode(SNLTreeNodeType.VarK);
            if (varP != null)
            {
                SNLTreeNode tp2 = varDec();
                if (tp2 != null)
                    varP.AddChild(tp2);
                else
                    varP = null;
            }
            SNLTreeNode s = procDec();

            if (varP == null)
                varP = s;
            if (typeP == null)
                pp = typeP = varP;
            if (typeP != varP)
            {
                typeP.SetSibling(varP);
                typeP = varP;
            }
            if (varP != s)
            {
                varP.SetSibling(s);
                varP = s;
            }
            return pp;
        }

        private SNLTreeNode typeDec()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.TYPE:
                    t = typeDeclaration();
                    break;
                case SNLLexType.VAR:

                case SNLLexType.PROCEDURE:

                case SNLLexType.BEGIN:
                    break;

                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add("NULL");
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode typeDeclaration()
        {
            match(SNLLexType.TYPE);
            SNLTreeNode t = typeDecList();
            if (t == null)
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A type declaration is expected!");
                _DebugList.Add(debug);
            }
            return t;
        }

        private SNLTreeNode typeDecList()
        {
            SNLTreeNode t = newDecNode();
            if (t != null)
            {
                typeId(t);
                match(SNLLexType.EQ);
                typeName(t);
                match(SNLLexType.SEMI);
                SNLTreeNode p = typeDecMore();
                if (p != null)
                    t.SetSibling(p);
            }
            return t;
        }

        private SNLTreeNode typeDecMore()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.VAR:
                case SNLLexType.PROCEDURE:
                case SNLLexType.BEGIN:
                    break;
                case SNLLexType.ID:
                    t = typeDecList();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private void typeId(SNLTreeNode t)
        {
            if ((_TokenList[_Pointer].GetLexType() == SNLLexType.ID) && (t != null))
            {
                t.AddName(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.ID);
        }

        private void typeName(SNLTreeNode t)
        {
            if (t != null)
                switch (_TokenList[_Pointer].GetLexType())
                {
                    case SNLLexType.INTEGER:
                    case SNLLexType.CHAR:
                        baseType(t);
                        break;
                    case SNLLexType.ARRAY:
                    case SNLLexType.RECORD:
                        structureType(t);
                        break;
                    case SNLLexType.ID:
                        t.SetKindDec(SNLTreeNodeTypeDec.IdK);
                        t.SetAttrTypeName(_TokenList[_Pointer].GetSem());
                        match(SNLLexType.ID);
                        break;
                    default:
                        ReadToken();
                        List<string> debug = new List<string>();
                        debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                        debug.Add("NULL");
                        debug.Add("An unexpected token is here!");
                        _DebugList.Add(debug);
                        break;
                }
        }

        private void baseType(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.INTEGER:
                    match(SNLLexType.INTEGER);
                    t.SetKindDec(SNLTreeNodeTypeDec.IntegerK);
                    break;

                case SNLLexType.CHAR:
                    match(SNLLexType.CHAR);
                    t.SetKindDec(SNLTreeNodeTypeDec.CharK);
                    break;

                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private void structureType(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.ARRAY:
                    arrayType(t);
                    break;
                case SNLLexType.RECORD:
                    t.SetKindDec(SNLTreeNodeTypeDec.RecordK);
                    recType(t);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private void arrayType(SNLTreeNode t)
        {
            match(SNLLexType.ARRAY);
            match(SNLLexType.LMIDPAREN);
            int low = -1, up = -1;
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.INTC)
            {
                low = int.Parse(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.INTC);
            match(SNLLexType.UNDERANGE);
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.INTC)
            {
                up = int.Parse(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.INTC);
            t.SetAttrArray(low, up);
            match(SNLLexType.RMIDPAREN);
            match(SNLLexType.OF);
            baseType(t);
            t.SetAttrArray(t.GetKindDec());
            t.SetKindDec(SNLTreeNodeTypeDec.ArrayK);
        }

        private void recType(SNLTreeNode t)
        {
            SNLTreeNode p = null;
            match(SNLLexType.RECORD);
            p = fieldDecList();
            if (p != null)
                t.AddChild(p);
            else
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A record body is requested!");
                _DebugList.Add(debug);
            }
            match(SNLLexType.END);
        }

        private SNLTreeNode fieldDecList()
        {
            SNLTreeNode t = newDecNode();
            SNLTreeNode p = null;
            if (t != null)
            {
                switch (_TokenList[_Pointer].GetLexType())
                {
                    case SNLLexType.INTEGER:
                    case SNLLexType.CHAR:
                        baseType(t);
                        idList(t);
                        match(SNLLexType.SEMI);
                        p = fieldDecMore();
                        break;
                    case SNLLexType.ARRAY:
                        arrayType(t);
                        idList(t);
                        match(SNLLexType.SEMI);
                        p = fieldDecMore();
                        break;
                    default:
                        ReadToken();
                        List<string> debug = new List<string>();
                        debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                        debug.Add("NULL");
                        debug.Add("An unexpected token is here!");
                        _DebugList.Add(debug);
                        break;
                }
                t.SetSibling(p);
            }
            return t;
        }

        private SNLTreeNode fieldDecMore()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.END:
                    break;
                case SNLLexType.INTEGER:
                case SNLLexType.CHAR:
                case SNLLexType.ARRAY:
                    t = fieldDecList();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private void idList(SNLTreeNode t)
        {
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.ID)
            {
                t.AddName(_TokenList[_Pointer].GetSem());
                match(SNLLexType.ID);
            }
            idMore(t);
        }

        private void idMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.SEMI: break;
                case SNLLexType.COMMA:
                    match(SNLLexType.COMMA);
                    idList(t);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode varDec()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.PROCEDURE:
                case SNLLexType.BEGIN:
                    break;
                case SNLLexType.VAR:
                    t = varDeclaration();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode varDeclaration()
        {
            match(SNLLexType.VAR);
            SNLTreeNode t = varDecList();
            if (t == null)
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A var declaration is expected!");
                _DebugList.Add(debug);
            }
            return t;
        }

        private SNLTreeNode varDecList()
        {
            SNLTreeNode t = newDecNode();
            SNLTreeNode p = null;

            if (t != null)
            {
                typeName(t);
                varIdList(t);
                match(SNLLexType.SEMI);
                p = varDecMore();
                t.SetSibling(p);
            }
            return t;
        }

        private SNLTreeNode varDecMore()
        {
            SNLTreeNode t = null;

            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.PROCEDURE:
                case SNLLexType.BEGIN:
                    break;
                case SNLLexType.INTEGER:
                case SNLLexType.CHAR:
                case SNLLexType.ARRAY:
                case SNLLexType.RECORD:
                case SNLLexType.ID:
                    t = varDecList();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private void varIdList(SNLTreeNode t)
        {
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.ID)
            {
                t.AddName(_TokenList[_Pointer].GetSem());
                match(SNLLexType.ID);
            }
            else
            {
                ReadToken();
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A varid is expected here!");
                _DebugList.Add(debug);
            }
            varIdMore(t);
        }

        private void varIdMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.SEMI:
                    break;
                case SNLLexType.COMMA:
                    match(SNLLexType.COMMA);
                    varIdList(t);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode procDec()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.BEGIN: break;
                case SNLLexType.PROCEDURE:
                    t = procDeclaration();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode procDeclaration()
        {
            SNLTreeNode t = newProcNode();
            match(SNLLexType.PROCEDURE);
            if (t != null)
            {
                if (_TokenList[_Pointer].GetLexType() == SNLLexType.ID)
                {
                    t.AddName(_TokenList[_Pointer].GetSem());
                    match(SNLLexType.ID);
                }
                match(SNLLexType.LPAREN);
                paramList(t);
                match(SNLLexType.RPAREN);
                match(SNLLexType.SEMI);
                t.AddChild(procDecPart());
                t.AddChild(procBody());
                t.SetSibling(procDec());
            }
            return t;
        }

        private void paramList(SNLTreeNode t)
        {
            SNLTreeNode p = null;

            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.RPAREN: break;
                case SNLLexType.INTEGER:
                case SNLLexType.CHAR:
                case SNLLexType.ARRAY:
                case SNLLexType.RECORD:
                case SNLLexType.ID:
                case SNLLexType.VAR:
                    p = paramDecList();
                    t.AddChild(p);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode paramDecList()
        {
            SNLTreeNode t = param();
            SNLTreeNode p = paramMore();
            if (p != null)
            {
                t.SetSibling(p);
            }
            return t;
        }

        private SNLTreeNode paramMore()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.RPAREN:
                    break;
                case SNLLexType.SEMI:
                    match(SNLLexType.SEMI);
                    t = paramDecList();
                    if (t == null)
                    {
                        List<string> sdebug = new List<string>();
                        sdebug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                        sdebug.Add("NULL");
                        sdebug.Add("A param declaration is request!");
                        _DebugList.Add(sdebug);
                    }
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode param()
        {
            SNLTreeNode t = newDecNode();
            if (t != null)
            {
                switch (_TokenList[_Pointer].GetLexType())
                {
                    case SNLLexType.INTEGER:
                    case SNLLexType.CHAR:
                    case SNLLexType.ARRAY:
                    case SNLLexType.RECORD:
                    case SNLLexType.ID:
                        t.SetAttrProc(SNLProcParamtType.VALPARAMTYPE);
                        typeName(t);
                        formList(t);
                        break;
                    case SNLLexType.VAR:
                        match(SNLLexType.VAR);
                        t.SetAttrProc(SNLProcParamtType.VARPARAMTYPE);
                        typeName(t);
                        formList(t);
                        break;
                    default:
                        ReadToken();
                        List<string> debug = new List<string>();
                        debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                        debug.Add("NULL");
                        debug.Add("An unexpected token is here!");
                        _DebugList.Add(debug);
                        break;
                }
            }
            return t;
        }

        private void formList(SNLTreeNode t)
        {
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.ID)
            {
                t.AddName(_TokenList[_Pointer].GetSem());
                match(SNLLexType.ID);
            }
            fidMore(t);
        }

        private void fidMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.SEMI:
                case SNLLexType.RPAREN:
                    break;
                case SNLLexType.COMMA:
                    match(SNLLexType.COMMA);
                    formList(t);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode procDecPart()
        {
            SNLTreeNode t = declarePart();
            return t;
        }

        private SNLTreeNode procBody()
        {
            SNLTreeNode t = programBody();
            if (t == null)
            {
                List<string> debug = new List<string>();
                debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                debug.Add("NULL");
                debug.Add("A program body is requested!");
                _DebugList.Add(debug);
            }
            return t;
        }

        private SNLTreeNode programBody()
        {
            SNLTreeNode t = newStmlNode();
            match(SNLLexType.BEGIN);
            if (t != null)
            {
                t.AddChild(stmList());
            }
            match(SNLLexType.END);
            return t;
        }

        private SNLTreeNode stmList()
        {
            SNLTreeNode t = stm();
            SNLTreeNode p = stmMore();
            if (t != null)
                if (p != null)
                    t.SetSibling(p);
            return t;
        }

        private SNLTreeNode stmMore()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.ELSE:
                case SNLLexType.FI:
                case SNLLexType.END:
                case SNLLexType.ENDWH:
                    break;
                case SNLLexType.SEMI:
                    match(SNLLexType.SEMI);
                    t = stmList();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode stm()
        {

            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.IF:
                    t = conditionalStm();
                    break;
                case SNLLexType.WHILE:
                    t = loopStm();
                    break;
                case SNLLexType.READ:
                    t = inputStm();
                    break;
                case SNLLexType.WRITE:
                    t = outputStm();
                    break;
                case SNLLexType.RETURN:
                    t = returnStm();
                    break;
                case SNLLexType.ID:
                    TempName = _TokenList[_Pointer].GetSem();
                    match(SNLLexType.ID);
                    t = assCall();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode assCall()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.ASSIGN:
                case SNLLexType.LMIDPAREN:
                case SNLLexType.DOT:
                    t = assignmentRest();
                    break;
                case SNLLexType.LPAREN:
                    t = callStmRest();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode assignmentRest()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.AssignK);
            if (t != null)
            {
                SNLTreeNode child1 = newExpNode(SNLTreeNodeTypeExp.VariK);
                if (child1 != null)
                {
                    child1.AddName(TempName);
                    variMore(child1);
                    t.AddChild(child1);
                }
                match(SNLLexType.ASSIGN);
                t.AddChild(exp());
            }
            return t;
        }

        private SNLTreeNode conditionalStm()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.IfK);
            match(SNLLexType.IF);
            if (t != null)
            {
                t.AddChild(exp());
            }
            match(SNLLexType.THEN);
            if (t != null)
                t.AddChild(stmList());
            if (_TokenList[_Pointer].GetLexType() == SNLLexType.ELSE)
            {
                match(SNLLexType.ELSE);
                if (t != null)
                    t.AddChild(stmList());
            }
            match(SNLLexType.FI);
            return t;
        }

        private SNLTreeNode loopStm()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.WhileK);
            match(SNLLexType.WHILE);
            if (t != null)
            {
                t.AddChild(exp());
                match(SNLLexType.DO);
                t.AddChild(stmList());
                match(SNLLexType.ENDWH);
            }
            return t;
        }

        private SNLTreeNode inputStm()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.ReadK);
            match(SNLLexType.READ);
            match(SNLLexType.LPAREN);
            if ((t != null) && (_TokenList[_Pointer].GetLexType() == SNLLexType.ID))
            {
                t.AddName(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.ID);
            match(SNLLexType.RPAREN);
            return t;
        }

        private SNLTreeNode outputStm()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.WriteK);
            match(SNLLexType.WRITE);
            match(SNLLexType.LPAREN);
            if (t != null)
            {
                t.AddChild(exp());
            }
            match(SNLLexType.RPAREN);
            return t;
        }

        private SNLTreeNode returnStm()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.ReturnK);
            match(SNLLexType.RETURN);
            return t;
        }

        private SNLTreeNode callStmRest()
        {
            SNLTreeNode t = newStmtNode(SNLTreeNodeTypeStmt.CallK);
            match(SNLLexType.LPAREN);
            if (t != null)
            {
                SNLTreeNode child0 = newExpNode(SNLTreeNodeTypeExp.VariK);
                if (child0 != null)
                {
                    child0.AddName(TempName);
                    t.AddChild(child0);
                }
                t.AddChild(actParamList());
            }
            match(SNLLexType.RPAREN);
            return t;
        }

        private SNLTreeNode actParamList()
        {
            SNLTreeNode t = null;

            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.RPAREN: break;
                case SNLLexType.ID:
                case SNLLexType.INTC:
                    t = exp();
                    if (t != null)
                        t.SetSibling(actParamMore());
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode actParamMore()
        {
            SNLTreeNode t = null;
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.RPAREN: break;
                case SNLLexType.COMMA:
                    match(SNLLexType.COMMA);
                    t = actParamList();
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode exp()
        {
            SNLTreeNode t = simple_exp();
            if ((_TokenList[_Pointer].GetLexType() == SNLLexType.LT) || (_TokenList[_Pointer].GetLexType() == SNLLexType.EQ))
            {
                SNLTreeNode p = newExpNode(SNLTreeNodeTypeExp.OpK);
                if (p != null)
                {
                    p.AddChild(t);
                    p.SetAttrExp(_TokenList[_Pointer].GetLexType());
                    t = p;
                }
                match(_TokenList[_Pointer].GetLexType());
                if (t != null)
                    t.AddChild(simple_exp());
            }

            return t;
        }

        private SNLTreeNode simple_exp()

        {
            SNLTreeNode t = term();
            while ((_TokenList[_Pointer].GetLexType() == SNLLexType.PLUS) || (_TokenList[_Pointer].GetLexType() == SNLLexType.MINUS))
            {
                SNLTreeNode p = newExpNode(SNLTreeNodeTypeExp.OpK);
                if (p != null)
                {
                    p.AddChild(t);
                    p.SetAttrExp(_TokenList[_Pointer].GetLexType());
                    t = p;
                    match(_TokenList[_Pointer].GetLexType());
                    t.AddChild(term());
                }
            }
            /* 函数返回表达式类型语法树节点t */
            return t;
        }

        private SNLTreeNode term()
        {
            SNLTreeNode t = factor();
            while ((_TokenList[_Pointer].GetLexType() == SNLLexType.TIMES) || (_TokenList[_Pointer].GetLexType() == SNLLexType.OVER))
            {
                SNLTreeNode p = newExpNode(SNLTreeNodeTypeExp.OpK);
                if (p != null)
                {
                    p.AddChild(t);
                    p.SetAttrExp(_TokenList[_Pointer].GetLexType());
                    t = p;
                }
                match(_TokenList[_Pointer].GetLexType());
                p.AddChild(factor());
            }
            return t;
        }

        private SNLTreeNode factor()
        {
            SNLTreeNode t = null;

            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.INTC:
                    t = newExpNode(SNLTreeNodeTypeExp.ConstK);
                    if ((t != null) && (_TokenList[_Pointer].GetLexType() == SNLLexType.INTC))
                    {
                        t.SetAttrExp(int.Parse(_TokenList[_Pointer].GetSem()));
                    }
                    match(SNLLexType.INTC);
                    break;
                case SNLLexType.ID:
                    t = variable();
                    break;
                case SNLLexType.LPAREN:
                    match(SNLLexType.LPAREN);
                    t = exp();
                    match(SNLLexType.RPAREN);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
            return t;
        }

        private SNLTreeNode variable()
        {
            SNLTreeNode t = newExpNode(SNLTreeNodeTypeExp.VariK);

            if ((t != null) && (_TokenList[_Pointer].GetLexType() == SNLLexType.ID))
            {
                t.AddName(_TokenList[_Pointer].GetSem());
            }

            match(SNLLexType.ID);
            variMore(t);
            return t;
        }

        void variMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.ASSIGN:
                case SNLLexType.TIMES:
                case SNLLexType.EQ:
                case SNLLexType.LT:
                case SNLLexType.PLUS:
                case SNLLexType.MINUS:
                case SNLLexType.OVER:
                case SNLLexType.RPAREN:
                case SNLLexType.RMIDPAREN:
                case SNLLexType.SEMI:
                case SNLLexType.COMMA:
                case SNLLexType.THEN:
                case SNLLexType.ELSE:
                case SNLLexType.FI:
                case SNLLexType.DO:
                case SNLLexType.ENDWH:
                case SNLLexType.END:
                    break;
                case SNLLexType.LMIDPAREN:
                    match(SNLLexType.LMIDPAREN);
                    t.AddChild(exp());
                    t.SetAttrExp(SNLExpAttrVarKindType.ArrayMembV);
                    t.GetChild(0).SetAttrExp(SNLExpAttrVarKindType.IdV);
                    match(SNLLexType.RMIDPAREN);
                    break;
                case SNLLexType.DOT:
                    match(SNLLexType.DOT);
                    t.AddChild(fieldvar());
                    t.SetAttrExp(SNLExpAttrVarKindType.FieldMembV);
                    t.GetChild(0).SetAttrExp(SNLExpAttrVarKindType.IdV);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode fieldvar()
        {
            SNLTreeNode t = newExpNode(SNLTreeNodeTypeExp.VariK);

            if ((t != null) && (_TokenList[_Pointer].GetLexType() == SNLLexType.ID))
            {
                t.AddName(_TokenList[_Pointer].GetSem());
            }
            match(SNLLexType.ID);
            fieldvarMore(t);
            return t;
        }

        void fieldvarMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case SNLLexType.ASSIGN:
                case SNLLexType.TIMES:
                case SNLLexType.EQ:
                case SNLLexType.LT:
                case SNLLexType.PLUS:
                case SNLLexType.MINUS:
                case SNLLexType.OVER:
                case SNLLexType.RPAREN:
                case SNLLexType.SEMI:
                case SNLLexType.COMMA:
                case SNLLexType.THEN:
                case SNLLexType.ELSE:
                case SNLLexType.FI:
                case SNLLexType.DO:
                case SNLLexType.ENDWH:
                case SNLLexType.END:
                    break;
                case SNLLexType.LMIDPAREN:
                    match(SNLLexType.LMIDPAREN);
                    t.AddChild(exp());
                    t.GetChild(0).SetAttrExp(SNLExpAttrVarKindType.ArrayMembV);
                    match(SNLLexType.RMIDPAREN);
                    break;
                default:
                    ReadToken();
                    List<string> debug = new List<string>();
                    debug.Add(_TokenList[_Pointer].GetLineNo().ToString());
                    debug.Add("NULL");
                    debug.Add("An unexpected token is here!");
                    _DebugList.Add(debug);
                    break;
            }
        }

        private SNLTreeNode parse()
        {
            SNLTreeNode t = null;
            ReadToken();
            t = program();
            //            if (_TokenList[_Pointer].GetLexType() !=  SNLLexType.ENDFILE)
            //                _DebugList.Add("Code ends before file\n");
            return t;
        }
    }
}
