//-----------------------------------------------------------------------------
//
//                   ** WARNING! ** 
//    This file was generated automatically by a tool.
//    Re-running the tool will overwrite this file.
//    You should copy this file to a custom location
//    before adding any customization in the copy to
//    prevent loss of your changes when the tool is
//    re-run.
//
//-----------------------------------------------------------------------------
#ifndef _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_SLEEP_H_
#define _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_SLEEP_H_

namespace nanoFramework
{
    namespace Hardware
    {
        namespace Esp32
        {
            struct Sleep
            {
                // Helper Functions to access fields of managed object
                // Declaration of stubs. These functions are implemented by Interop code developers
                static signed int NativeEnableWakeupByTimer( unsigned __int64 param0, HRESULT &hr );
                static signed int NativeEnableWakeupByPin( unsigned __int64 param0, signed int param1, HRESULT &hr );
                static signed int NativeEnableWakeupByMultiPins( unsigned __int64 param0, signed int param1, HRESULT &hr );
                static signed int NativeEnableWakeupByTouchPad( HRESULT &hr );
                static signed int NativeStartLightSleep( HRESULT &hr );
                static signed int NativeStartDeepSleep( HRESULT &hr );
                static signed int NativeGetWakeupCause( HRESULT &hr );
                static unsigned __int64 NativeGetWakeupGpioPin( HRESULT &hr );
                static signed int NativeGetWakeupTouchpad( HRESULT &hr );
            };
        }
    }
}
#endif  //_NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_SLEEP_H_
