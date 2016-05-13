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
        private int _Pointer = 0;

        public  void StartParser(List<SNLToken> TokenList)
        {
            _TokenList = TokenList;
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


        /********************************************************
         *********以下是创建语法树所用的各类节点的申请***********
         ********************************************************/

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


        private  void match(SNLLexType LexType)
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
            switch (_TokenList[_Pointer++].GetLexType())
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
                up= int.Parse(_TokenList[_Pointer].GetSem());
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



    }
}
