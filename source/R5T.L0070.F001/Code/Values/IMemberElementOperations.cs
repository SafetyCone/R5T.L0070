using System;

using R5T.L0069.T000;
using R5T.T0131;
using R5T.T0212;

using R5T.L0070.T000;


namespace R5T.L0070.F001
{
    [ValuesMarker]
    public partial interface IMemberElementOperations : IValuesMarker
    {
        public Func<IMemberElement, MemberDocumentation> Get_MemberDocumentation(
            IDocumentationTarget documentationTarget)
        {
            return memberElement =>
                Instances.MemberElementOperator.Get_MemberDocumentation(memberElement, documentationTarget);
        }
    }
}
