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

namespace Hansoft.ObjectWrapper
{
    /// <summary>
    /// Represents a Product Backlog item that has been committed to the Schedue as a scheduled task.
    /// </summary>
    public class ProductBacklogItemInSchedule : ProductBacklogItem
    {
        internal static ProductBacklogItemInSchedule GetProductBacklogItemInSchedule(HPMUniqueID uniqueID, HPMUniqueID uniqueTaskID)
        {
            return new ProductBacklogItemInSchedule(uniqueID, uniqueTaskID);
        }

        private ProductBacklogItemInSchedule(HPMUniqueID uniqueID, HPMUniqueID uniqueTaskID)
            : base(uniqueID, uniqueTaskID)
        {
        }

        /// <summary>
        /// The Duration of the task.
        /// </summary>
        public int Duration
        {
            get
            {
                return Session.TaskGetDuration(UniqueTaskID);
            }
        }

    }
}
