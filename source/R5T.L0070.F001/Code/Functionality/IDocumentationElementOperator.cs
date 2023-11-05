using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0053.Extensions;
using R5T.L0062.T000;
using R5T.L0069.T000;
using R5T.T0132;
using R5T.T0212;

using R5T.L0070.T000;


namespace R5T.L0070.F001
{
    [FunctionalityMarker]
    public partial interface IDocumentationElementOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public T0212.F000.IDocumentationElementOperator _Base => T0212.F000.DocumentationElementOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public void Add_MemberDocumentationsByIdentityName(IDocumentationElement documentationElement,
            IDictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            IDocumentationTarget documentationTarget,
            IDictionary<IIdentityString, IList<MemberDocumentation>> duplicates,
            Func<IList<MemberDocumentation>> listConstructor)
        {
            var additionalMemberDocumentationsByIdentityName = this.Get_MemberDocumentationsByIdentityString(
                documentationElement,
                documentationTarget);

            additionalMemberDocumentationsByIdentityName.ForEach(
                pair =>
                {
                    if (!memberDocumentationsByIdentityName.TryAdd(pair.Key, pair.Value))
                    {
                        var isFirstDuplicate = !duplicates.ContainsKey(pair.Key);
                        if(isFirstDuplicate)
                        {
                            // Add the current value.
                            var currentValue = memberDocumentationsByIdentityName[pair.Key];

                            duplicates.Add_Value(
                                listConstructor,
                                pair.Key,
                                currentValue);
                        }
                    }
                });
        }

        public void Add_MemberDocumentationsByIdentityName(
            IDocumentationElement documentationElement,
            IDictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            IDocumentationTarget documentationTarget,
            IDictionary<IIdentityString, List<MemberDocumentation>> duplicates)
        {
            var additionalMemberDocumentationsByIdentityName = this.Get_MemberDocumentationsByIdentityString(
                documentationElement,
                documentationTarget);

            additionalMemberDocumentationsByIdentityName.ForEach(
                pair =>
                {
                    if (!memberDocumentationsByIdentityName.TryAdd(pair.Key, pair.Value))
                    {
                        var isFirstDuplicate = !duplicates.ContainsKey(pair.Key);
                        if (isFirstDuplicate)
                        {
                            // Add the current value.
                            var currentValue = memberDocumentationsByIdentityName[pair.Key];

                            duplicates.Add_Value(
                                pair.Key,
                                currentValue);
                        }

                        // Now add the pair.
                        duplicates.Add_Value(
                            pair.Key,
                            pair.Value);
                    }
                });
        }

        public IEnumerable<MemberDocumentation> Get_MemberDocumentations(
            IDocumentationElement documentationElement,
            IDocumentationTarget documentationTarget)
        {
            var memberDocumentations = _Base.Enumerate_MemberElements_Raw(documentationElement)
                .Select(Instances.MemberElementOperations.Get_MemberDocumentation(documentationTarget))
                ;

            return memberDocumentations;
        }

        public Dictionary<IIdentityString, MemberDocumentation> Get_MemberDocumentationsByIdentityString(
            IDocumentationElement documentationElement,
            IDocumentationTarget documentationTarget)
        {
            var output = this.Get_MemberDocumentations(
                documentationElement,
                documentationTarget)
                .ToDictionary(
                    x => x.IdentityString);

            return output;
        }
    }
}
