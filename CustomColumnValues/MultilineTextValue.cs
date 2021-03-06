﻿#if (PLATFORM_X64)
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

namespace Hansoft.ObjectWrapper.CustomColumnValues
{
    /// <summary>
    /// Encapsulates a tasks value for custom column of multiple line text type.
    /// </summary>
    public class MultilineTextValue : TextValue
    {
        internal MultilineTextValue(Task task, HPMProjectCustomColumnsColumn customColumn, string internalValue)
            : base(task, customColumn, internalValue)
        {
        }

        internal static MultilineTextValue FromEscapedString(Task task, HPMProjectCustomColumnsColumn customColumn, string endUserString)
        {
            string internalValue = endUserString.Replace("\\n", "\n").Replace("\\\\", "\\");
            return new MultilineTextValue(task, customColumn, internalValue);
        }
    }
}
