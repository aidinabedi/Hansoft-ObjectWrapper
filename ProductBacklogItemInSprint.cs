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

using Hansoft.ObjectWrapper.CustomColumnValues;

namespace Hansoft.ObjectWrapper
{
    /// <summary>
    /// Represents a product backlog item that has been commited into a Sprint in the Hansoft Schedule.
    /// </summary>
    public class ProductBacklogItemInSprint : ProductBacklogItem
    {
        internal static ProductBacklogItemInSprint GetProductBacklogItemInSprint(HPMUniqueID uniqueID, HPMUniqueID uniqueTaskID)
        {
            return new ProductBacklogItemInSprint(uniqueID, uniqueTaskID);
        }

        private ProductBacklogItemInSprint(HPMUniqueID uniqueID, HPMUniqueID uniqueTaskID)
            : base(uniqueID, uniqueTaskID)
        {
        }
    }
}
