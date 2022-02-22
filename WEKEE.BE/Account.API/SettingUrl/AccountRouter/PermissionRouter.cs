using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.API.SettingUrl.Base;

namespace Account.API.SettingUrl.AccountRouter
{
    /// <summary>
    /// Quản lý router phân quyền
    /// </summary>
    public static class PermissionRouter
    {
        /// <summary>
        /// /account-resource
        /// </summary>
        public const string ResourceAccount = RootUrl.ROOT+ "/account-resource";
        /// <summary>
        /// /account-atomic
        /// </summary>
        public const string AtomicAccount = RootUrl.ROOT + "/account-atomic";
        /// <summary>
        /// /account-action
        /// </summary>
        public const string ActionAccount =RootUrl.ROOT+ "/account-action";
        /// <summary>
        /// /account-action-assignment
        /// </summary>
        public const string ActionAssignmentAccount =RootUrl.ROOT+ "/account-action-assignment";
        /// <summary>
        /// /account-algorithm-role
        /// </summary>
        public const string AlgorithmRoleAccount =RootUrl.ROOT+ "/account-algorithm-role";
        /// <summary>
        /// /account-constraint-assignment
        /// </summary>
        public const string ConstraintAssignmentAccount =RootUrl.ROOT+ "/account-constraint-assignment";
        /// <summary>
        /// /account-constraint-assignment
        /// </summary>
        public const string PermissionAssignmentAccount =RootUrl.ROOT+ "/account-permission-assignment";
        /// <summary>
        /// /account-permission
        /// </summary>
        public const string PermissionAccount =RootUrl.ROOT+ "/account-permission";
        /// <summary>
        /// /account-resource-action
        /// </summary>
        public const string ResourceActionAccount =RootUrl.ROOT+ "/account-resource-action";
        /// <summary>
        /// /account-resource-action
        /// </summary>
        public const string ActionResourceAccount = RootUrl.ROOT + "/account-action-resource";
        /// <summary>
        /// /account-role
        /// </summary>
        public const string RoleAccount =RootUrl.ROOT+ "/account-role";
        /// <summary>
        /// /subject
        /// </summary>
        public const string SubjectAccount = "/subject";
        /// <summary>
        /// /subject-assignment
        /// </summary>
        public const string SubjectAssignmentAccount =RootUrl.ROOT+ "/subject-assignment";
        /// <summary>
        /// /subject-group
        /// </summary>
        public const string SubjectGroupAccount =RootUrl.ROOT+ "/subject-group";
        /// <summary>
        /// Lấy thông tin action từ id atomic
        /// </summary>
        public const string GetActionByIdAtomicAccount = RootUrl.ROOT+ "/get-action-by-atomic";
    }
}
