using System;


namespace R5T.L0070.F001
{
    public class MemberElementOperator : IMemberElementOperator
    {
        #region Infrastructure

        public static IMemberElementOperator Instance { get; } = new MemberElementOperator();


        private MemberElementOperator()
        {
        }

        #endregion
    }
}
