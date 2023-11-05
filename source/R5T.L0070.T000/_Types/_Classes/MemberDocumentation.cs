using System;

using R5T.L0062.T000;
using R5T.L0069.T000;
using R5T.T0142;
using R5T.T0212;


namespace R5T.L0070.T000
{
    /// <summary>
    /// Represents a member element in a .NET XML documentation file.
    /// </summary>
    /// <remarks>
    /// Prior work: R5T.T0212.F000.
    /// </remarks>
    [DataTypeMarker]
    public class MemberDocumentation
    {
        public IIdentityString IdentityString { get; set; }
        public IMemberElement MemberElement { get; set; }
        public IDocumentationTarget DocumentationTarget { get; set; }


        public override string ToString()
        {
            var output = this.IdentityString.ToString();
            return output;
        }
    }
}
