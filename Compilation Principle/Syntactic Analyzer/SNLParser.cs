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
        private List<String> _DebugList = new List<string>();
        private SNLTreeNode _Root = new SNLTreeNode();
        private SNLTreeNode _CurrFaNode = new SNLTreeNode();
        private SNLTreeNode _CurrNode = new SNLTreeNode();
        private int _Pointer = -1;
        private string TempName;
        public void StartParser(List<SNLToken> TokenList)
        {
            _TokenList = TokenList;
            _Root = parse();
        }

        public int GetPointer()
        {
            MessageBox.Show("截止至Token" + _Pointer.ToString() + "之前没有错误", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return _Pointer;
        }

        public SNLTreeNode SNLTree()
        {
            return _Root;
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


        private void match(SNLLexType LexType)
        {
            if (_TokenList[_Pointer].GetLexType() == LexType)
            {
                _Pointer++;
            }
            else
            {
                _DebugList.Add("not match error " + LexType.ToString());
                _Pointer++;
            }

        }

        private SNLTreeNode program()
        {
            SNLTreeNode t = programHead();
            SNLTreeNode q = declarePart();
            SNLTreeNode s = programBody();

            SNLTreeNode root = newRootNode();

            if (t != null)
                root.AddChild(t);
            else
                _DebugList.Add("a program head is expected!");
            if (q != null)
                root.AddChild(q);
            if (s != null)
                root.AddChild(s);
            else
                _DebugList.Add("a program body is expected!");

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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                _DebugList.Add("a type declaration is expected!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                        _Pointer++;
                        _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                _DebugList.Add("a record body is requested!");
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
                        _Pointer++;
                        _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
                    break;
            }
            return t;
        }

        private SNLTreeNode varDeclaration()
        {
            match(SNLLexType.VAR);
            SNLTreeNode t = varDecList();
            if (t == null)
                _DebugList.Add("a var declaration is expected!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                _DebugList.Add("a varid is expected here!");
                _Pointer++;
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                        _DebugList.Add("a param declaration is request!");
                    break;
                default:
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                        _Pointer++;
                        _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                _DebugList.Add("a program body is requested!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
                    break;
            }
            return t;
        }

        private SNLTreeNode exp()
        {
            SNLTreeNode t = simple_exp();
            if ((_TokenList[_Pointer].GetLexType() ==  SNLLexType.LT) || (_TokenList[_Pointer].GetLexType() == SNLLexType.EQ))
            {
                SNLTreeNode p = newExpNode( SNLTreeNodeTypeExp.OpK);
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
            while ((_TokenList[_Pointer].GetLexType() ==  SNLLexType.PLUS) || (_TokenList[_Pointer].GetLexType() == SNLLexType.MINUS))
            {
                SNLTreeNode p = newExpNode( SNLTreeNodeTypeExp.OpK);
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
            while ((_TokenList[_Pointer].GetLexType() ==  SNLLexType.TIMES) || (_TokenList[_Pointer].GetLexType() == SNLLexType.OVER))
            {
                SNLTreeNode p = newExpNode( SNLTreeNodeTypeExp.OpK);
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
                case  SNLLexType.INTC:
                    t = newExpNode( SNLTreeNodeTypeExp.ConstK);
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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
                    break;
            }
            return t;
        }
        
        private SNLTreeNode variable()
        {
            SNLTreeNode t = newExpNode( SNLTreeNodeTypeExp.VariK);

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
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
                    break;
            }
        }
        
        private SNLTreeNode fieldvar()
        {
            SNLTreeNode t = newExpNode( SNLTreeNodeTypeExp.VariK);

            if ((t != null) && (_TokenList[_Pointer].GetLexType() ==  SNLLexType.ID))
            {
                t.AddName(_TokenList[_Pointer].GetSem());
            }
            match( SNLLexType.ID);
            fieldvarMore(t);
            return t;
        }
        
        void fieldvarMore(SNLTreeNode t)
        {
            switch (_TokenList[_Pointer].GetLexType())
            {
                case  SNLLexType.ASSIGN:
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
                    match( SNLLexType.RMIDPAREN);
                    break;
                default:
                    _Pointer++;
                    _DebugList.Add("unexpected token is here!");
                    break;
            }
        }
        
        private SNLTreeNode parse()
        {
            SNLTreeNode t = null;
            _Pointer++;
            t = program();
//            if (_TokenList[_Pointer].GetLexType() !=  SNLLexType.ENDFILE)
//                _DebugList.Add("Code ends before file\n");
            return t;
        }
    }
}
