using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDCompiler.Language
{
    public enum SNLLexType { ENDFILE, ERROR, PROGRAM, PROCEDURE, TYPE, VAR, IF, THEN, ELSE, FI, WHILE, DO, ENDWH, BEGIN, END, READ, WRITE, ARRAY, OF, RECORD, RETURN, INTEGER, CHAR, ID, INTC, CHARC, ASSIGN, EQ, LT, PLUS, MINUS, TIMES, OVER, LPAREN, RPAREN, DOT, COLON, SEMI, COMMA, LMIDPAREN, RMIDPAREN, UNDERANGE, SINGLED };

    public enum SNLTreeNodeType { ProK, PheadK, TypeK, VarK, ProcDecK, StmLK, DecK, StmtK, ExpK };

    public enum SNLTreeNodeTypeDecK { ArrayK, CharK, IntegerK, RecordK, IdK, NULL};

    public enum SNLTreeNodeTypeStmtK { IfK, WhileK, AssignK, ReadK, WriteK, CallK, ReturnK, NULL};

    public enum SNLTreeNodeTypeExpK { OpK, ConstK, IdK, NULL };

    public enum SNLChildType { INTEGER, CHARC };

    public enum SNLParamtType { VALPARAMTYPE, VARPARAMTYPE }

    public enum SNLAttrOPType { LT, EQ, PLUS, MINUS, TIMES, OVER };

    public enum SNLAttrVarKindType { IdV, ArrayMembV, FieldMembV };

    public enum SNLAttrType { Void, Integer, Boolean };


}
