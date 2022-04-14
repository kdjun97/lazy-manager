using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using lazy_manager.Enums;

namespace lazy_manager.Display
{
    /// <summary>
    /// 화면 해상도에 관한 클래스
    /// </summary>
    public class DisplayResolution
    {
        static Size displaySize;
        public Size GetDisplaySize() => displaySize;

        /// <summary>
        /// Device context를 구하기 위한 함수 (GetDeviceCaps)
        /// </summary>
        /// <param name="hDC"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        public static double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            //Create Graphics object from the current windows handle
            Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
            //Get Handle to the device context associated with this Graphics object
            IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
            //Call GetDeviceCaps with the Handle to retrieve the Screen Height
            int LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
            //Divide the Screen Heights to get the scaling factor and round it to two decimals
            double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / (double)LogicalScreenHeight, 2);
            //If requested as percentage - convert it
            if (percentage)
            {
                ScreenScalingFactor *= 100.0;
            }
            //Release the Handle and Dispose of the GraphicsObject object
            GraphicsObject.ReleaseHdc(DeviceContextHandle);
            GraphicsObject.Dispose();
            //Return the Scaling Factor
            return ScreenScalingFactor;
        }

        /// <summary>
        /// 배율이 정해진 디스플레이 해상도를 구하기 위한 함수
        /// 배율 계산값에 따라 정확한 해상도를 구할 수 있음
        /// </summary>
        /// <returns></returns>
        public static void SetDisplayResolution()
        {
            var scalingFactor = GetWindowsScreenScalingFactor(false);
            Debug.Print("해상도 배율 :" + scalingFactor.ToString());
            var screenWidth = Screen.PrimaryScreen.Bounds.Width * scalingFactor;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height * scalingFactor;
            displaySize =  new Size((int)screenWidth, (int)screenHeight);
        }
    }
}
