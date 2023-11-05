using System;


namespace R5T.L0070.F001
{
    public class DocumentationElementOperator : IDocumentationElementOperator
    {
        #region Infrastructure

        public static IDocumentationElementOperator Instance { get; } = new DocumentationElementOperator();


        private DocumentationElementOperator()
        {
        }

        #endregion
    }
}
