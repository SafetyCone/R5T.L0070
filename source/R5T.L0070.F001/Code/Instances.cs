using System;


namespace R5T.L0070.F001
{
    public static class Instances
    {
        public static IDocumentationElementOperator DocumentationElementOperator => F001.DocumentationElementOperator.Instance;
        public static L0069.IDocumentationTargetOperator DocumentationTargetOperator => L0069.DocumentationTargetOperator.Instance;
        public static L0053.IFileOperator FileOperator => L0053.FileOperator.Instance;
        public static IMemberElementOperations MemberElementOperations => F001.MemberElementOperations.Instance;
        public static IMemberElementOperator MemberElementOperator => F001.MemberElementOperator.Instance;
        public static L0053.IXElementOperator XElementOperator => L0053.XElementOperator.Instance;
    }
}