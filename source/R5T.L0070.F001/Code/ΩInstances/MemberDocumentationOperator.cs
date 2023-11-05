using System;


namespace R5T.L0070.F001
{
    public class MemberDocumentationOperator : IMemberDocumentationOperator
    {
        #region Infrastructure

        public static IMemberDocumentationOperator Instance { get; } = new MemberDocumentationOperator();


        private MemberDocumentationOperator()
        {
        }

        #endregion
    }
}
