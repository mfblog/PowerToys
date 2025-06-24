// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Win32.System.Com;

namespace Microsoft.CmdPal.Ext.Apps.Helpers;

internal enum APPDOCLISTTYPE
{
    ADLT_RECENT = 0,
    ADLT_FREQUENT = 1,
}

[ComImport]
[Guid("3C594F9F-9F30-47A1-979A-C9E83D3D0A06")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IApplicationDocumentLists
{
    void SetAppID([MarshalAs(UnmanagedType.LPWStr)] string pszAppID);

    void GetList(
        APPDOCLISTTYPE listtype,
        uint cItemsDesired,
        [MarshalAs(UnmanagedType.Interface)] out IUnknown ppList);
}

[ComImport]
[Guid("92CA9DCD-5622-4bba-A805-5E9F541BD8C9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IObjectArray
{
    void GetCount(out uint cObjects);

    void GetAt(uint iIndex, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppv);
}

[ComImport]
[Guid("2c1c7e2e-2d0e-4059-831e-1e6f82335c2e")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IEnumObjects
{
    [PreserveSig]
    int Next(
        uint celt,
        [MarshalAs(UnmanagedType.Interface)] out IUnknown rgelt,
        out uint pceltFetched);

    [PreserveSig]
    int Skip(uint celt);

    [PreserveSig]
    int Reset();

    [PreserveSig]
    int Clone(out IEnumObjects ppenum);
}

[ComImport]
[Guid("86BEC222-30F2-47E0-9F25-60D11CD75C28")]
internal class ApplicationDocumentLists
{
}
