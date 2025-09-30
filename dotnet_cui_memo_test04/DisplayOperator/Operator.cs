using System.Runtime.InteropServices;

[Flags]
public enum DisplayDeviceStateFlags : int
{
    None = 0,
    Active = 0x00000001,
    MultiDriver = 0x00000002,
    PrimaryDevice = 0x00000004,
    MirroringDriver = 0x00000008,
    VGACompatible = 0x00000010,
    Removable = 0x00000020,
    ModesPruned = 0x08000000,
    Remote = 0x04000000,
    Disconnect = 0x02000000
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
struct DISPLAY_DEVICE
{
    public int cb;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string DeviceName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string DeviceString;
    public DisplayDeviceStateFlags StateFlags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string DeviceID;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string DeviceKey;
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct DEVMODE
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string dmDeviceName;
    public ushort dmSpecVersion;
    public ushort dmDriverVersion;
    public ushort dmSize;
    public ushort dmDriverExtra;
    public uint dmFields;
    public int dmPositionX;
    public int dmPositionY;
    public uint dmDisplayOrientation;
    public uint dmDisplayFixedOutput;
    public short dmColor;
    public short dmDuplex;
    public short dmYResolution;
    public short dmTTOption;
    public short dmCollate;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string dmFormName;
    public ushort dmLogPixels;
    public uint dmBitsPerPel;
    public uint dmPelsWidth;
    public uint dmPelsHeight;
    public uint dmDisplayFlags;
    public uint dmDisplayFrequency;
    public uint dmICMMethod;
    public uint dmICMIntent;
    public uint dmMediaType;
    public uint dmDitherType;
    public uint dmReserved1;
    public uint dmReserved2;
    public uint dmPanningWidth;
    public uint dmPanningHeight;
}


namespace DisplayOperator
{
    public class Operator
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern bool EnumDisplayDevices(string? lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern bool EnumDisplaySettings(string lpszDeviceName, int iModelNum, ref DEVMODE lpDevMode);

        private readonly List<DISPLAY_DEVICE> f_devices;

        private readonly List<DISPLAY_DEVICE> f_displays;

        private readonly List<DEVMODE> f_modes;

        public Operator()
        {
            f_devices = [];
            f_displays = [];
            f_modes = [];
        }

        public void FetchDevices()
        {
            uint i = 0;
            while (QueryDevice(null, i))
            {
                ++i;
            }
            for (i = 0; i < f_devices.Count; ++i)
            {
                uint j = 0;
                while (QueryDevice(f_devices[(int)i].DeviceName, j))
                {
                    ++j;
                }
            }
        }

        public void FetchModes()
        {
            foreach (var d in f_devices)
            {
                QueryMode(d.DeviceName);
            }
            foreach (var d in f_displays)
            {
                QueryMode(d.DeviceName);
            }
        }

        public List<Tuple<string, string, string, string>> GetDeviceInfo() =>
            f_devices.Select(d => new Tuple<string, string, string, string>(
                $"Device Name: {d.DeviceName}",
                $"Device String: {d.DeviceString}",
                $"Device ID: {d.DeviceID}",
                $"State Flags: {d.StateFlags}"
            )).ToList();

        public List<Tuple<string, string, string, string>> GetDisplayInfo() =>
            f_displays.Select(d => new Tuple<string, string, string, string>(
                $"Display Name: {d.DeviceName}",
                $"Display String: {d.DeviceString}",
                $"Display ID: {d.DeviceID}",
                $"State Flags: {d.StateFlags}"
            )).ToList();

        private bool QueryDevice(string? name, uint i)
        {
            var d = new DISPLAY_DEVICE() { cb = Marshal.SizeOf(typeof(DISPLAY_DEVICE)) };
            if (EnumDisplayDevices(name, i, ref d, 0))
            {
                if (d.StateFlags.HasFlag(DisplayDeviceStateFlags.Active) && !d.StateFlags.HasFlag(DisplayDeviceStateFlags.MirroringDriver))
                {
                    if (name == null)
                    {
                        f_devices.Add(d);
                        return true;
                    }
                    f_displays.Add(d);
                    return true;
                }
            }
            return false;
        }

        private void QueryMode(string name)
        {
            var m = new DEVMODE() { dmSize = (ushort)Marshal.SizeOf(typeof(DEVMODE)) };
            if (EnumDisplaySettings(name, -1, ref m))
            {
                f_modes.Add(m);
            }
        }
    }
}