using Antlr4.Runtime.Misc;
using PrismaDB.QueryAST;
using PrismaDB.QueryAST.DDL;
using PrismaDB.QueryParser.Postgres.AntlrGrammer;

namespace PrismaDB.QueryParser.Postgres
{
    public partial class PostgresVisitor : PostgresParserBaseVisitor<object>
    {
        public override object VisitUseStatement([NotNull] PostgresParser.UseStatementContext context)
        {
            return new UseStatement((DatabaseRef)Visit(context.databaseName()));
        }

        public override object VisitShowTablesStatement([NotNull] PostgresParser.ShowTablesStatementContext context)
        {
            return new ShowTablesQuery();
        }

        public override object VisitShowColumnsStatement([NotNull] PostgresParser.ShowColumnsStatementContext context)
        {
            return new ShowColumnsQuery((TableRef)Visit(context.tableName()));
        }
    }
}