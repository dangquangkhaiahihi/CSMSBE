using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMSBE.Core.Helper
{
    public class RoleHelper
    {
        public const string Admin = "ADMIN";
        public const string RegisterUser = "REGISTERUSER";
        public class Action
        {
            public const string FullPermission = "FULL_PERMISSION";
            public const string View = "VIEW";
            public const string Create = "CREATE";
            public const string Update = "UPDATE";
            public const string Delete = "DELETE";
            public const string Download = "DOWNLOAD";
        }
        public class Screen
        {
            public const string UserManagement = "USER_MANAGEMENT";
            public const string RoleManagement = "ROLE_MANAGEMENT";
            public const string EmailTemplate = "EMAIL_TEMPLATE";
            public const string ListUsers = "LIST_USERS";
            public const string SecurityMatrix = "SECURITY_MATRIX";
            public const string Records = "RECORDS";
            public const string Project = "PROJECT";
            public const string CreateProject = "CREATERECORDS";
            public const string Report = "REPORT";
            public const string MessageHasSend = "MESSAGEHASSEND";
            public const string MessageHasReceive = "MESSAGEHASRECEIVE";
            public const string SendMessage = "SENDMESSAGE";
            public const string District = "DISTRICT";
            public const string Province = "PROVINCE";
            public const string Commune = "COMMUNE";
            public const string RecordsStatus = "RECORDSSTATUS";
            public const string ProjectStatus = "PROJECTSTATUS";
            public const string ProjectGroup = "PROJECTGROUP";
            public const string PC07Local = "PC07LOCAL";
            public const string RecordsResultProcessing = "RECORDSRESULTPROCESSING";
            public const string Investor = "INVESTOR";
            public const string AttachFileType = "ATTACHFILETYPE";
            public const string ConstructionType = "CONSTRUCTIONTYPE";
            public const string ImportData = "IMPORTDATA";

        }
    }
}
