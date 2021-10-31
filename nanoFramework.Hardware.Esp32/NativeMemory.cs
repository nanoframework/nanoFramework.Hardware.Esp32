//
// Copyright (c) .NET Foundation and Contributors
// See LICENSE file in the project root for full license information.
//

using System;
using System.Runtime.CompilerServices;

namespace nanoFramework.Hardware.Esp32
{
    /// <summary>
    /// Class to access information on Native Memory.
    /// </summary>
    public class NativeMemory
    {
        /// <summary>
        /// Native memory type.
        /// </summary>
        public enum MemoryType 
        { 
            /// <summary>
            /// All memory ( Internal and SpiRam
            /// </summary>
            All, 
            /// <summary>
            /// Only Internal memory. Memory contained in ESP32. 
            /// </summary>
            Internal, 
            /// <summary>
            /// Memory in external SPI Ram.
            /// </summary>
            SpiRam 
        };

        /// <summary>
        /// Get information on native memory.
        /// </summary>
        public static void GetMemoryInfo(MemoryType memType, out UInt32 TotalSize, out UInt32 TotalFreeSize, out UInt32 LargestFreeBlock)
        {
            TotalSize = NativeGetMemoryTotalSize((int)memType);
            TotalFreeSize = NativeGetMemoryTotalFreeSize((int)memType);
            LargestFreeBlock = NativeGetMemoryLargestFreeBlock((int)memType);
        }

        #region Native Calls
        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static UInt32 NativeGetMemoryTotalSize(int memType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static UInt32 NativeGetMemoryTotalFreeSize(int memType);

        [MethodImpl(MethodImplOptions.InternalCall)]
        private extern static UInt32 NativeGetMemoryLargestFreeBlock(int memType);
        #endregion
    }
}
