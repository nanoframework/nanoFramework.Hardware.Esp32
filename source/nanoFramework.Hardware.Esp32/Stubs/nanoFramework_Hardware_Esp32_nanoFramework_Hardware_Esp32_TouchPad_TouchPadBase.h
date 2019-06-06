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
#ifndef _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_TOUCHPAD_TOUCHPADBASE_H_
#define _NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_TOUCHPAD_TOUCHPADBASE_H_

namespace nanoFramework
{
    namespace Hardware
    {
        namespace Esp32
        {
            namespace TouchPad
            {
                struct TouchPadBase
                {
                    // Helper Functions to access fields of managed object
                    static UNSUPPORTED_TYPE& Get__syncLock( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_UNSUPPORTED_TYPE( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_TouchPad_TouchPadBase::FIELD___syncLock ); }

                    static signed int& Get__pinNumber( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_INT32( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_TouchPad_TouchPadBase::FIELD___pinNumber ); }

                    static signed int& Get__touchPadIndex( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_INT32( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_TouchPad_TouchPadBase::FIELD___touchPadIndex ); }

                    static bool& Get__disposedValue( CLR_RT_HeapBlock* pMngObj )    { return Interop_Marshal_GetField_bool( pMngObj, Library_nanoFramework_Hardware_Esp32_nanoFramework_Hardware_Esp32_TouchPad_TouchPadBase::FIELD___disposedValue ); }

                    // Declaration of stubs. These functions are implemented by Interop code developers
                    static bool TouchPadInit( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                    static bool TouchPadSetFsmMode( CLR_RT_HeapBlock* pMngObj, signed int param0, HRESULT &hr );
                    static bool TouchPadSetVoltage( CLR_RT_HeapBlock* pMngObj, signed int param0, signed int param1, signed int param2, HRESULT &hr );
                    static bool TouchPadConfig( CLR_RT_HeapBlock* pMngObj, signed int param0, unsigned short param1, HRESULT &hr );
                    static bool TouchPadSetFilterPeriod( CLR_RT_HeapBlock* pMngObj, unsigned int param0, HRESULT &hr );
                    static unsigned short TouchPadRead( CLR_RT_HeapBlock* pMngObj, signed int param0, HRESULT &hr );
                    static unsigned short TouchPadReadFiltered( CLR_RT_HeapBlock* pMngObj, signed int param0, HRESULT &hr );
                    static bool TouchPadSetThresh( CLR_RT_HeapBlock* pMngObj, signed int param0, unsigned short param1, HRESULT &hr );
                    static void DisposeNative( CLR_RT_HeapBlock* pMngObj, HRESULT &hr );
                };
            }
        }
    }
}
#endif  //_NANOFRAMEWORK_HARDWARE_ESP32_NANOFRAMEWORK_HARDWARE_ESP32_TOUCHPAD_TOUCHPADBASE_H_
