#if (PLATFORM_X64)
extern alias HPMSdkx64;
using HPMSdkx64::HPMSdk;
#else
extern alias HPMSdkx86;
using HPMSdkx86::HPMSdk;
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hansoft.ObjectWrapper
{
    /// <summary>
    /// Represents a Group of Users in Hansoft.
    /// </summary>
    public class Group : Resource
    {
        internal static Group GetGroup(HPMUniqueID uniqueID)
        {
            return new Group(uniqueID);
        }

        private Group(HPMUniqueID uniqueID)
            : base(uniqueID)
        {
        }

        /// <summary>
        /// The name of the group.
        /// </summary>
        public override string Name
        {
            get
            {
                HPMResourceGroupProperties props = SessionManager.Session.ResourceGroupGetProperties(UniqueID);
                return props.m_Name;
            }
            set
            {
                if (Name != value)
                {
                    HPMResourceGroupProperties props = SessionManager.Session.ResourceGroupGetProperties(UniqueID);
                    props.m_Name = value;
                    SessionManager.Session.ResourceGroupSetProperties(UniqueID, props);
                }
            }
        }

        /// <summary>
        /// The Users that are members of this group.
        /// </summary>
        public List<User> Members
        {
            get
            {
                List<User> members = new List<User>();
                foreach (User u in HPMUtilities.GetUsers())
                    if (u.Groups.Contains(this))
                        members.Add(u);
                return members;
            }
        }
    }
}
