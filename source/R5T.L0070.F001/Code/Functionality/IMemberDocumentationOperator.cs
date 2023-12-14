using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0062.T000;
using R5T.T0132;

using R5T.L0070.T000;
using R5T.T0181;

namespace R5T.L0070.F001
{
    /// <summary>
    /// Operator for the member documentation type.
    /// </summary>
    /// <remarks>
    /// Prior work: R5T.T0212.F000.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IMemberDocumentationOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Chooses <see cref="Clone_WithClonedMemberElement(MemberDocumentation)"/> as the default.
        /// </summary>
        public MemberDocumentation Clone(MemberDocumentation memberDocumentation)
        {
            var output = this.Clone_WithClonedMemberElement(memberDocumentation);
            return output;
        }

        /// <summary>
        /// Creates a new <see cref="MemberDocumentation"/> instance with the same value instances, except for a cloned member element.
        /// </summary>
        public MemberDocumentation Clone_WithClonedMemberElement(MemberDocumentation memberDocumentation)
        {
            var output = new MemberDocumentation
            {
                // Use the same documentation target instance (documentation target has no properties, so they can be considered to be read only).
                DocumentationTarget = memberDocumentation.DocumentationTarget,
                // Use the same identity name instance (value is read-only, so no need to worry about joing modification of the instance).
                IdentityString = memberDocumentation.IdentityString,
                MemberElement = Instances.MemberElementOperator._Base.Clone(memberDocumentation.MemberElement)
            };

            return output;
        }

        public IDictionary<IIdentityString, MemberDocumentation> Get_MemberDocumentationsByIdentityName(
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            var output = memberDocumentations
                .ToDictionary(
                    x => x.IdentityString);

            return output;
        }

        public IDictionary<IIdentityString, MemberDocumentation> Get_MemberDocumentationsByIdentityName(
            params MemberDocumentation[] memberDocumentations)
        {
            return this.Get_MemberDocumentationsByIdentityName(
                memberDocumentations.AsEnumerable());
        }

        public IDictionary<IIdentityString, MemberDocumentation> Get_InitialMemberDocumentationsByIdentityName()
        {
            var output = new Dictionary<IIdentityString, MemberDocumentation>();
            return output;
        }

        public IEnumerable<string> Describe(IEnumerable<MemberDocumentation> memberDocumentation)
        {
            return memberDocumentation.Select(
                this.Describe);
        }

        public string Describe(MemberDocumentation memberDocumentation)
        {
            var memberElementText = Instances.XElementOperator.To_Text_AsIs(memberDocumentation.MemberElement.Value);

            var output = $"{memberDocumentation.IdentityString}:\n{memberDocumentation.DocumentationTarget}\n{memberElementText}\n";
            return output;
        }

        public void Describe_ToFile_Synchronous(
            string filePath,
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            Instances.FileOperator.Write_Lines_Synchronous(
                filePath,
                this.Describe(memberDocumentations));
        }

        public void Describe_ToFile_Synchronous(
            string filePath,
            params MemberDocumentation[] memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath,
                memberDocumentations.AsEnumerable());
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            IEnumerable<MemberDocumentation> memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath.Value,
                memberDocumentations);
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            params MemberDocumentation[] memberDocumentations)
        {
            this.Describe_ToFile_Synchronous(
                filePath.Value,
                memberDocumentations);
        }

        public void Describe_ToFile_Synchronous(
            ITextFilePath filePath,
            IDictionary<IIdentityString, MemberDocumentation> memberDocumentationsByMemberName)
        {
            this.Describe_ToFile_Synchronous(
                filePath,
                memberDocumentationsByMemberName.Values);
        }
    }
}
