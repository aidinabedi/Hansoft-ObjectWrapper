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
    /// Represents an item that is created directly in a sprint, typically a task in the sprint.
    /// </summary>
    public class SprintBacklogItem : Task
    {
        internal static SprintBacklogItem GetSprintBacklogItem(HPMUniqueID uniqueID, HPMUniqueID uniqueTaskID)
        {
            return new SprintBacklogItem(uniqueID, uniqueTaskID);
        }

        private SprintBacklogItem(HPMUniqueID uniqueID, HPMUniqueID refTaskID)
            : base(uniqueID, refTaskID)
        {
        }

        /// <summary>
        /// The project view that this sprint backlog item belongs to.
        /// </summary>
        public override ProjectView ProjectView
        {
            get
            {
                return Project.Schedule;
            }
        }

        /// <summary>
        /// The assignment percentage of a particular user that is assigned to this sprint backlog item.
        /// </summary>
        /// <param name="user">The name of the user.</param>
        /// <returns>The assignment percentage.</returns>
        public int GetAssignmentPercentage(User user)
        {
            return TaskHelper.GetAssignmentPercentage(this, user);
        }

        /// <summary>
        /// True if this sprint backlog item is assigned, False otherwise.
        /// </summary>
        public bool IsAssigned
        {
            get
            {
                return TaskHelper.IsAssigned(this);
            }
        }

        /// <summary>
        /// The sprint priority for this sprint backlog item.
        /// </summary>
        public override HansoftEnumValue Priority
        {
            get
            {
                return new HansoftEnumValue(MainProjectID, EHPMProjectDefaultColumn.SprintPriority, Session.TaskGetSprintPriority(RefTaskID), (int)Session.TaskGetSprintPriority(RefTaskID));
            }
            set
            {
                if (Priority != value) Session.TaskSetSprintPriority(RefTaskID, (EHPMTaskAgilePriorityCategory)value.Value);
            }
        }
    }
}
