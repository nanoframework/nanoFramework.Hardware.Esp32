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
#ifndef _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_HIGHRESTIMER_H_
#define _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_HIGHRESTIMER_H_

namespace nanoFramework
{
    namespace Hardware
    {
        namespace Esp32
        {
            struct HighResTimer
            {
                // Helper Functions to access fields of managed object
                static signed int& Get__timerHandle( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_INT32( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::FIELD___timerHandle ); }

                static bool& Get__disposedValue( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_bool( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::FIELD___disposedValue ); }

                static UNSUPPORTED_TYPE& Get__syncLock( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::FIELD___syncLock ); }

                static UNSUPPORTED_TYPE& Get_OnHighResTimerExpired( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_HighResTimer::FIELD__OnHighResTimerExpired ); }

                // Declaration of stubs. These functions are implemented by Interop code developers
                static signed int NativeEspTimerCreate( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static void NativeEspTimerDispose( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static void NativeStop( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                static void NativeStartOneShot( CLR_RT_HeapBlock* pMngObj, unsigned __int64 param0, HRESULT &hr );
                static void NativeStartPeriodic( CLR_RT_HeapBlock* pMngObj, unsigned __int64 param0, HRESULT &hr );
                static unsigned __int64 NativeGetCurrent( HRESULT &hr );
            };
        }
    }
}
#endif  //_NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_HIGHRESTIMER_H_
