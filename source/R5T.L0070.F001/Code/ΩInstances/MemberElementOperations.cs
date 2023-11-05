using System;


namespace R5T.L0070.F001
{
    public class MemberElementOperations : IMemberElementOperations
    {
        #region Infrastructure

        public static IMemberElementOperations Instance { get; } = new MemberElementOperations();


        private MemberElementOperations()
        {
        }

        #endregion
    }
}
