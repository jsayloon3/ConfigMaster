using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.Common.Enums
{
    public static class AuditTrail
    {
        public enum ActionType
        {
            [EnumMember(Value = "Login")]
            Login,
            [EnumMember(Value = "Lock")]
            Lock,
            [EnumMember(Value = "File Access")]
            FileAccess,
            [EnumMember(Value = "Create")]
            Create,
            [EnumMember(Value = "Update")]
            Update,
            [EnumMember(Value = "Delete")]
            Delete,
            [EnumMember(Value = "Comment")]
            Comment,
            [EnumMember(Value = "Uncomment")]
            Uncomment
        }
    }
}
