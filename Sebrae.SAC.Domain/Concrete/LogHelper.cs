﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sebrae.SAC.Domain.Concrete
{
    public class LogHelper
    {
        public static log4net.ILog Getlogger([CallerFilePath]string filename = "") {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
