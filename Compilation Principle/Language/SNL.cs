using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDCompiler.Language
{
    public enum SNLLexType { ENDFILE, ERROR, PROGRAM, PROCEDURE, TYPE, VAR, IF, THEN, ELSE, FI, WHILE, DO, ENDWH, BEGIN, END, READ, WRITE, ARRAY, OF, RECORD, RETURN, INTEGER, CHAR, ID, INTC, CHARC, ASSIGN, EQ, LT, PLUS, MINUS, TIMES, OVER, LPAREN, RPAREN, DOT, COLON, SEMI, COMMA, LMIDPAREN, RMIDPAREN, UNDERANGE, SINGLED };

    public enum SNLTreeNodeType { ProK, PheadK, TypeK, VarK, ProcDecK, StmLK, DecK, StmtK, ExpK };

    public enum SNLTreeNodeTypeDec { NULL, ArrayK, CharK, IntegerK, RecordK, IdK };

    public enum SNLTreeNodeTypeStmt { NULL, IfK, WhileK, AssignK, ReadK, WriteK, CallK, ReturnK };

    public enum SNLTreeNodeTypeExp { NULL, OpK, ConstK, IdK };

    public enum SNLAttrType { NULL, ArrayAttr, ProcAttr, ExpAttr };

    public enum SNLProcParamtType { VALPARAMTYPE, VARPARAMTYPE }

    public enum SNLExpAttrOPType { LT, EQ, PLUS, MINUS, TIMES, OVER };

    public enum SNLExpAttrVarKindType { IdV, ArrayMembV, FieldMembV };

    public enum SNLExpAttrType { Void, Integer, Boolean };


}
