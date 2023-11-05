using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0062.T000;
using R5T.L0069.T000;
using R5T.T0132;
using R5T.T0172;

using R5T.L0070.T000;


namespace R5T.L0070.F001
{
    [FunctionalityMarker]
    public partial interface IDocumentationFileOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public T0212.F000.IDocumentationFileOperator _Base => T0212.F000.DocumentationFileOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public async Task Add_MemberDocumentationsByIdentityName(
            IDocumentationXmlFilePath documentationXmlFilePath,
            IDictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            IDictionary<IIdentityString, List<MemberDocumentation>> duplicates)
        {
            var documentationTarget = Instances.DocumentationTargetOperator.Get_DocumentationXmlFileTarget(documentationXmlFilePath);
            var documentationElement = await Instances.DocumentationElementOperator._Base.Get_DocumentationElement(documentationXmlFilePath);

            Instances.DocumentationElementOperator.Add_MemberDocumentationsByIdentityName(
                documentationElement,
                memberDocumentationsByIdentityName,
                documentationTarget,
                duplicates);
        }

        public async Task Add_MemberDocumentationsByIdentityName(
            IDocumentationXmlFilePath documentationXmlFilePath,
            IDictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            IDictionary<IIdentityString, IList<MemberDocumentation>> duplicates,
            Func<IList<MemberDocumentation>> duplicatesListConstructor)
        {
            var documentationTarget = Instances.DocumentationTargetOperator.Get_DocumentationXmlFileTarget(documentationXmlFilePath);
            var documentationElement = await Instances.DocumentationElementOperator._Base.Get_DocumentationElement(documentationXmlFilePath);

            Instances.DocumentationElementOperator.Add_MemberDocumentationsByIdentityName(
                documentationElement,
                memberDocumentationsByIdentityName,
                documentationTarget,
                duplicates,
                duplicatesListConstructor);
        }

        public async Task<Dictionary<IIdentityString, MemberDocumentation>> Get_MemberDocumentationsByIdentityName(
            IDocumentationTarget documentationTarget,
            IDocumentationXmlFilePath documentationXmlFilePath)
        {
            var documentationElement = await Instances.DocumentationElementOperator._Base.Get_DocumentationElement(documentationXmlFilePath);

            var output = Instances.DocumentationElementOperator.Get_MemberDocumentationsByIdentityString(
                documentationElement,
                documentationTarget);

            return output;
        }

        public async Task<(
            Dictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            Dictionary<IIdentityString, MemberDocumentation[]> duplicates
            )>
            Get_MemberDocumentationsByIdentityName(IEnumerable<IDocumentationXmlFilePath> documentationXmlFilePaths)
        {
            var memberDocumentationByIdentityName_Internal = new ConcurrentDictionary<IIdentityString, MemberDocumentation>();
            var duplicates_Internal = new ConcurrentDictionary<IIdentityString, List<MemberDocumentation>>();

            var addingMemberDocumentationsByIdentityName = documentationXmlFilePaths
                .Select(documentationXmlFilePath => this.Add_MemberDocumentationsByIdentityName(
                    documentationXmlFilePath,
                    memberDocumentationByIdentityName_Internal,
                    duplicates_Internal));

            await Task.WhenAll(addingMemberDocumentationsByIdentityName);

            var duplicates = duplicates_Internal.ToDictionary(
                x => x.Key,
                x => x.Value.ToArray());

            var memberDocumentationByIdentityName = memberDocumentationByIdentityName_Internal.ToDictionary();

            return (memberDocumentationByIdentityName, duplicates);
        }

        public Task<(
            Dictionary<IIdentityString, MemberDocumentation> memberDocumentationsByIdentityName,
            Dictionary<IIdentityString, MemberDocumentation[]> duplicates
            )>
            Get_MemberDocumentationsByIdentityName(params IDocumentationXmlFilePath[] documentationXmlFilePaths)
        {
            return this.Get_MemberDocumentationsByIdentityName(
                documentationXmlFilePaths.AsEnumerable());
        }
    }
}
