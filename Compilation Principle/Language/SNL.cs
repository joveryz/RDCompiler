using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDCompiler.Language
{
    public enum SNLLexType { NULL, ENDFILE, ERROR, PROGRAM, PROCEDURE, TYPE, VAR, IF, THEN, ELSE, FI, WHILE, DO, ENDWH, BEGIN, END, READ, WRITE, ARRAY, OF, RECORD, RETURN, INTEGER, CHAR, ID, INTC, CHARC, ASSIGN, EQ, LT, PLUS, MINUS, TIMES, OVER, LPAREN, RPAREN, DOT, COLON, SEMI, COMMA, LMIDPAREN, RMIDPAREN, UNDERANGE, SINGLED };

    public enum SNLTreeNodeType { ProK, PheadK, TypeK, VarK, ProcDecK, StmLK, DecK, StmtK, ExpK };

    public enum SNLTreeNodeTypeDec { NULL, ArrayK, CharK, IntegerK, RecordK, IdK };

    public enum SNLTreeNodeTypeStmt { NULL, IfK, WhileK, AssignK, ReadK, WriteK, CallK, ReturnK };

    public enum SNLTreeNodeTypeExp { NULL, OpK, ConstK, VariK };

    public enum SNLProcParamtType { NULL, VALPARAMTYPE, VARPARAMTYPE }

    public enum SNLExpAttrVarKindType { NULL, IdV, ArrayMembV, FieldMembV };

    public enum SNLExpAttrType { NULL, Void, Integer, Boolean };


}
