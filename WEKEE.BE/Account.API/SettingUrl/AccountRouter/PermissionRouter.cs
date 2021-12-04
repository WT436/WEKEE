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
        /// /Resource-Basic
        /// </summary>
        public static class ResourceBasic
        {
            private const string URL = "/resource-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Atomic-Basic
        /// </summary>
        public static class AtomicBasic
        {
            private const string URL = "/atomic-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Action-Basic
        /// </summary>
        public static class ActionBasic
        {
            private const string URL = "/action-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Action-Assignment-Basic
        /// </summary>
        public static class ActionAssignmentBasic
        {
            private const string URL = "/action-assignment-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Action-Basic
        /// </summary>
        public static class AlgorithmRoleBasic
        {
            private const string URL = "/algorithm-role-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Constraint-Assignment-Basic
        /// </summary>
        public static class ConstraintAssignmentBasic
        {
            private const string URL = "/constraint-assignment-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Permission-Assignment-Basic
        /// </summary>
        public static class PermissionAssignmentBasic
        {
            private const string URL = "/permission-assignment-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }        
        /// <summary>
        /// /Permission-Basic
        /// </summary>
        public static class PermissionBasic
        {
            private const string URL = "/permission-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Resource-Action-Basic
        /// </summary>
        public static class ResourceActionBasic
        {
            private const string URL = "/resource-action-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Role-Basic
        /// </summary>
        public static class RoleBasic
        {
            private const string URL = "/role-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Subject-Group-Basic
        /// </summary>
        public static class SubjectBasic
        {
            private const string URL = "/subject-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Subject-Assignment-Basic
        /// </summary>
        public static class SubjectAssignmentBasic
        {
            private const string URL = "/subject-assignment-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
        /// <summary>
        /// /Subject-Group-Basic
        /// </summary>
        public static class SubjectGroupBasic
        {
            private const string URL = "/subject-group-basic";
            public const string WATCH = RootUrl.ROOT + ActionRouter.WATCH + URL;
            public const string CREATE = RootUrl.ROOT + ActionRouter.CREATE + URL;
            public const string DELETE = RootUrl.ROOT + ActionRouter.DELETE + URL;
            public const string EDIT = RootUrl.ROOT + ActionRouter.EDIT + URL;
            public const string GET = RootUrl.ROOT + ActionRouter.GET + URL;
            public const string LIST = RootUrl.ROOT + ActionRouter.LIST + URL;
            public const string PATCH = RootUrl.ROOT + ActionRouter.PATCH + URL;
            public const string UPDATE = RootUrl.ROOT + ActionRouter.UPDATE + URL;
        }
    }
}
