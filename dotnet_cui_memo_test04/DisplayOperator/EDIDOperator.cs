using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct LUID
{
    public uint LowPart;
    public int HighPart;
}

[Flags]
public enum QUERY_DISPLAY_CONFIG_FLAGS : uint
{
    QDC_ALL_PATHS = 0x00000001,
    QDC_ONLY_ACTIVE_PATHS = 0x00000002,
    QDC_DATABASE_CURRENT = 0x00000004,
    QDC_VIRTUAL_MODE_AWARE = 0x00000010,
    QDC_INCLUDE_HMD = 0x00000020
}

public enum DISPLAYCONFIG_TOPOLOGY_ID : uint
{
    DISPLAYCONFIG_TOPOLOGY_INTERNAL = 0x00000001,
    DISPLAYCONFIG_TOPOLOGY_CLONE = 0x00000002,
    DISPLAYCONFIG_TOPOLOGY_EXTEND = 0x00000004,
    DISPLAYCONFIG_TOPOLOGY_EXTERNAL = 0x00000008
}

public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY : uint
{
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = 0xFFFFFFFF,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO = 1,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO = 2,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO = 3,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI = 4,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI = 5,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS = 6,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN = 8,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI = 9,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL = 10,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED = 11,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL = 12,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED = 13,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE = 14,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST = 15,
    DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = 0x80000000
}

public enum DISPLAYCONFIG_SCANLINE_ORDERING : uint
{
    DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,
    DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,
    DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,
    DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = 3
}

public enum DISPLAYCONFIG_PIXELFORMAT : uint
{
    DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,
    DISPLAYCONFIG_PIXELFORMAT_16BPP = 2,
    DISPLAYCONFIG_PIXELFORMAT_24BPP = 3,
    DISPLAYCONFIG_PIXELFORMAT_32BPP = 4,
    DISPLAYCONFIG_PIXELFORMAT_NONGDI = 5
}

public enum DISPLAYCONFIG_MODE_INFO_TYPE : uint
{
    DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,
    DISPLAYCONFIG_MODE_INFO_TYPE_TARGET = 2
}

[StructLayout(LayoutKind.Sequential)]
public struct POINTL
{
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_SOURCE_MODE
{
    public uint width;
    public uint height;
    public DISPLAYCONFIG_PIXELFORMAT pixelFormat;
    public POINTL position;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_RATIONAL
{
    public uint Numerator;
    public uint Denominator;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_2DREGION
{
    public uint cx;
    public uint cy;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
{
    public ulong pixelRate;
    public DISPLAYCONFIG_RATIONAL hSyncFreq;
    public DISPLAYCONFIG_RATIONAL vSyncFreq;
    public DISPLAYCONFIG_2DREGION activeSize;
    public DISPLAYCONFIG_2DREGION totalSize;
    public ushort videoStandard;
    public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_TARGET_MODE
{
    public DISPLAYCONFIG_VIDEO_SIGNAL_INFO targetVideoSignalInfo;
}

[StructLayout(LayoutKind.Explicit)]
public struct DISPLAYCONFIG_MODE_INFO
{
    [FieldOffset(0)]
    public DISPLAYCONFIG_MODE_INFO_TYPE infoType;

    [FieldOffset(4)]
    public uint id;

    [FieldOffset(8)]
    public LUID adapterId;

    [FieldOffset(16)]
    public DISPLAYCONFIG_SOURCE_MODE sourceMode;

    [FieldOffset(16)]
    public DISPLAYCONFIG_TARGET_MODE targetMode;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_PATH_SOURCE_INFO
{
    public LUID adapterId;
    public uint id;
    public uint modeInfoIdx;
    public uint statusFlags;
}

public enum DISPLAYCONFIG_ROTATION : uint
{
    DISPLAYCONFIG_ROTATION_IDENTITY = 1,
    DISPLAYCONFIG_ROTATION_ROTATE90 = 2,
    DISPLAYCONFIG_ROTATION_ROTATE180 = 3,
    DISPLAYCONFIG_ROTATION_ROTATE270 = 4
}

public enum DISPLAYCONFIG_SCALING : uint
{
    DISPLAYCONFIG_SCALING_IDENTITY = 1,
    DISPLAYCONFIG_SCALING_CENTERED = 2,
    DISPLAYCONFIG_SCALING_STRETCHED = 3,
    DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX = 4,
    DISPLAYCONFIG_SCALING_CUSTOM = 5,
    DISPLAYCONFIG_SCALING_PREFERRED = 128
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_PATH_TARGET_INFO
{
    public LUID adapterId;
    public uint id;
    public uint modeInfoIdx;
    public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;
    public DISPLAYCONFIG_ROTATION rotation;
    public DISPLAYCONFIG_SCALING scaling;
    public DISPLAYCONFIG_RATIONAL refreshRate;
    public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
    public bool targetAvailable;
    public uint statusFlags;
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_PATH_INFO
{
    public DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo;
    public DISPLAYCONFIG_PATH_TARGET_INFO targetInfo;
    public uint flags;
}

public enum DISPLAYCONFIG_DEVICE_INFO_TYPE : uint
{
    DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1,
    DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME = 2,
    DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE = 3,
    DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME = 4,
    DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE = 5,
    DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE = 6,
    DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION = 7,
    DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION = 8,
    DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO = 9,
    DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_INFO = 10,
    DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL = 11,
    DISPLAYCONFIG_DEVICE_INFO_GET_MONITOR_SPECIALIZATION = 12,
    DISPLAYCONFIG_DEVICE_INFO_SET_MONITOR_SPECIALIZATION = 13
}

[StructLayout(LayoutKind.Sequential)]
public struct DISPLAYCONFIG_DEVICE_INFO_HEADER
{
    public DISPLAYCONFIG_DEVICE_INFO_TYPE type;
    public uint size;
    public LUID adapterId;
    public uint id;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DISPLAYCONFIG_TARGET_DEVICE_NAME
{
    public DISPLAYCONFIG_DEVICE_INFO_HEADER header;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string monitorFriendlyDeviceName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string monitorDevicePath;
}

namespace DisplayOperator
{
    public class EDIDOperator
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int GetDisplayConfigBufferSizes(QUERY_DISPLAY_CONFIG_FLAGS flags, out uint numPathArrayElements, out uint numModeInfoArrayElements);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int QueryDisplayConfig(QUERY_DISPLAY_CONFIG_FLAGS flags, ref uint numPathArrayElements, [In, Out] DISPLAYCONFIG_PATH_INFO[] pathInfoArray, ref uint numModeInfoArrayElements, [In, Out] DISPLAYCONFIG_MODE_INFO[] modeInfoArray, IntPtr currentTopologyId);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern int DisplayConfigGetDeviceInfo(ref DISPLAYCONFIG_TARGET_DEVICE_NAME requestPacket);

        private uint f_numPaths;

        private uint f_numModes;

        private List<DISPLAYCONFIG_PATH_INFO> f_paths;

        private List<DISPLAYCONFIG_MODE_INFO> f_modes;

        private List<DISPLAYCONFIG_TARGET_DEVICE_NAME> f_names;

        public EDIDOperator()
        {
            f_numPaths = 0;
            f_numModes = 0;
            f_paths = [];
            f_modes = [];
            f_names = [];
        }

        public void Fetch()
        {
            if (!FetchBufferSizes())
            {
                return;
            }
            int ret = FetchConfig();
            if (ret != 0)
            {
                Console.WriteLine($"Error fetching config: {ret}");
                return;
            }
            FetchNames();
        }

        public List<Tuple<string, string, string, string>> GetDeviceInfo()
        {
            List<Tuple<string, string, string, string>> result = [];
            foreach (var p in f_paths)
            {
                result.Add(new Tuple<string, string, string, string>(
                    $"Source ID: {p.sourceInfo.id}",
                    $"Target ID: {p.targetInfo.id}",
                    $"Output Technology: {p.targetInfo.outputTechnology}",
                    $"Refresh Rate: {p.targetInfo.refreshRate.Numerator}/{p.targetInfo.refreshRate.Denominator}"
                ));
            }
            return result;
        }

        private bool FetchBufferSizes()
        {
            return GetDisplayConfigBufferSizes(QUERY_DISPLAY_CONFIG_FLAGS.QDC_ALL_PATHS, out f_numPaths, out f_numModes) == 0;
        }

        private int FetchConfig()
        {
            DISPLAYCONFIG_PATH_INFO[] paths = new DISPLAYCONFIG_PATH_INFO[f_numPaths];
            DISPLAYCONFIG_MODE_INFO[] modes = new DISPLAYCONFIG_MODE_INFO[f_numModes];
            int ret = QueryDisplayConfig(QUERY_DISPLAY_CONFIG_FLAGS.QDC_ALL_PATHS, ref f_numPaths, paths, ref f_numModes, modes, IntPtr.Zero);
            if (ret == 0)
            {
                f_paths = paths
                    .Where(p => p.targetInfo.refreshRate.Numerator != 0)
                    .Where(p => p.targetInfo.outputTechnology != DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY.DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER && p.targetInfo.outputTechnology != DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY.DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL)
                    .GroupBy(p => new { p.targetInfo.adapterId.LowPart, p.targetInfo.adapterId.HighPart, p.targetInfo.id }).Select(g => g.First())
                    .ToList();
                f_modes = modes.ToList();
            }
            return ret;
        }

        private void FetchNames()
        {
            foreach (var p in f_paths)
            {
                DISPLAYCONFIG_TARGET_DEVICE_NAME name = new()
                {
                    header = new DISPLAYCONFIG_DEVICE_INFO_HEADER
                    {
                        type = DISPLAYCONFIG_DEVICE_INFO_TYPE.DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME,
                        size = (uint)Marshal.SizeOf<DISPLAYCONFIG_TARGET_DEVICE_NAME>(),
                        adapterId = p.targetInfo.adapterId,
                        id = p.targetInfo.id
                    }
                };
                int ret = DisplayConfigGetDeviceInfo(ref name);
                if (ret == 0)
                {
                    f_names.Add(name);
                }
            }
        }
    }
}