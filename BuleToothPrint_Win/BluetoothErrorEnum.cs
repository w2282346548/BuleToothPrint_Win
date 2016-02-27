﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuleToothPrint_Win
{
    public enum BluetoothErrorEnum
    {
        /// <summary>
        /// 不支持蓝牙
        /// </summary>
        NotSupport = 1,
        /// <summary>
        /// 蓝牙没有开启
        /// </summary>
        NotOpen = 2,
        /// <summary>
        /// 蓝牙未连接
        /// </summary>
        NotConnected
    }
}
