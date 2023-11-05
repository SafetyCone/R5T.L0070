using System;

using R5T.L0062.T000;
using R5T.L0062.T000.Extensions;
using R5T.L0069.T000;
using R5T.T0132;
using R5T.T0212;

using R5T.L0070.T000;


namespace R5T.L0070.F001
{
    [FunctionalityMarker]
    public partial interface IMemberElementOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public T0212.F000.IMemberElementOperator _Base => T0212.F000.MemberElementOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IIdentityString Get_IdentityString(IMemberElement memberElement)
        {
            var output = _Base._Platform.Get_IdentityString(memberElement)
                .ToIdentityString();

            return output;
        }

        public MemberDocumentation Get_MemberDocumentation(
            IMemberElement memberElement,
            IDocumentationTarget documentationTarget)
        {
            var identityString = this.Get_IdentityString(memberElement);

            _Base.RemoveExtraTextLineEndings(memberElement);

            var output = new MemberDocumentation
            {
                IdentityString = identityString,
                MemberElement = memberElement,
                DocumentationTarget = documentationTarget,
            };

            return output;
        }
    }
}
