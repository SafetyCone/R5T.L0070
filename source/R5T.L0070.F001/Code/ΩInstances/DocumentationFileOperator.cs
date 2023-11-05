using System;


namespace R5T.L0070.F001
{
    public class DocumentationFileOperator : IDocumentationFileOperator
    {
        #region Infrastructure

        public static IDocumentationFileOperator Instance { get; } = new DocumentationFileOperator();


        private DocumentationFileOperator()
        {
        }

        #endregion
    }
}
