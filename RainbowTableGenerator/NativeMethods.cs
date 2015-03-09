
namespace RainbowTableGenerator
{


    class NativeMethods
    {

        private const uint EM_SETCUEBANNER = 0x1501;


        [System.Runtime.InteropServices.DllImport("user32.dll",SetLastError=true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern System.IntPtr SendMessage(System.IntPtr hWnd, uint msg, System.IntPtr wParam,
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]string lParam);


        // http://www.fluxbytes.com/csharp/set-placeholder-text-for-textbox-cue-text/
        public static void SetPlaceHolderText(System.Windows.Forms.TextBox txt, string Text)
        {
            if(System.Environment.OSVersion.Platform != System.PlatformID.Unix)
                SendMessage(txt.Handle, EM_SETCUEBANNER, System.IntPtr.Zero, Text);
        } // End Sub SetPlaceHolderText 


    } // End Class NativeMethods


} // End Namespace RainbowTableGenerator
