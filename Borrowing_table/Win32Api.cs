using System;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Borrowing_table
{
    public class Win32Api
    {
        public const int INPUT_MOUSE = 0;
        public const int INPUT_KEYBOARD = 1;
        public const int INPUT_HARDWARE = 2;

        public const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const uint KEYEVENTF_KEYUP = 0x0002;
        public const uint KEYEVENTF_UNICODE = 0x0004;
        public const uint KEYEVENTF_SCANCODE = 0x0008;
        public const uint XBUTTON1 = 0x0001;
        public const uint XBUTTON2 = 0x0002;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const uint MOUSEEVENTF_XDOWN = 0x0080;
        public const uint MOUSEEVENTF_XUP = 0x0100;
        public const uint MOUSEEVENTF_WHEEL = 0x0800;
        public const uint MOUSEEVENTF_VIRTUALDESK = 0x4000;
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        public const int SM_CXSCREEN = 0;
        public const int SM_CYSCREEN = 1;


        [StructLayout(LayoutKind.Sequential)]
        public struct MouseInput
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KeyBoardInput
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HardwareInput
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct Input
        {
            [FieldOffset(0)] public int type;
            [FieldOffset(4)] public MouseInput mouseInput;
            [FieldOffset(4)] public KeyBoardInput keyboardInput;
            [FieldOffset(4)] public HardwareInput hardwardInput;
        }

        [DllImport("User32.dll")]
        public static extern uint SendInput(uint numberOfInputs,
            [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] Input[] input, int structSize);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMessageExtraInfo();

        [DllImport("kernel32.dll")]
        public static extern int GetTickCount();

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point pt);

        [DllImport("user32.dll")]
        public static extern int GetSystemMetrics(int nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool SwitchToThisWindow(IntPtr hWnd, bool fAltTab);


        /// <summary>
        /// 打印byte数组，调试用
        /// </summary>
        /// <param name="a"></param>
        private static void printBytes(byte[] a)
        {
            string s = string.Empty;
            foreach (byte b in a)
            {
                s += b.ToString();
                s += ",";
            }
            s = s.TrimEnd(',');
            Console.WriteLine(s);
        }

        /// <summary>
        /// 将utf-8字符转换为ansi字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string utf8_to_ansi(string str)
        {
            try
            {
                Encoding uft8 = Encoding.UTF8;
                Encoding ansi = Encoding.Default;

                byte[] byteTemp = uft8.GetBytes(str);
                List<byte> list = new List<byte>(byteTemp);
                list.Add(229);
                //printBytes(list.ToArray());
                string result = ansi.GetString(list.ToArray());

                return result;
            }
            catch (Exception ex) //(UnsupportedEncodingException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public static string GB2312ToUTF8(string str)
        {
            try
            {
                Encoding uft8 = Encoding.GetEncoding(65001);
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                byte[] byteTemp = gb2312.GetBytes(str);
                /*                MessageBox.Show("gb2312的编码的字节个数：" + temp.Length);*/
                //                 for (int i = 0; i < temp.Length; i++)
                //                 {
                //                     MessageBox.Show(Convert.ToUInt16(temp[i]).ToString());
                //                 }   
                byte[] resultByte = Encoding.Convert(gb2312, uft8, byteTemp);
                /*                MessageBox.Show("uft8的编码的字节个数：" + temp1.Length);*/
                //                 for (int i = 0; i < temp1.Length; i++)
                //                 {
                //                     MessageBox.Show(Convert.ToUInt16(temp1[i]).ToString());
                //                 }              
                string result = uft8.GetString(resultByte);
                return result;
            }
            catch (Exception ex) //(UnsupportedEncodingException ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }

        //发送unicode字符，可发送任意字符     
        public static void SendUnicode(string message)
        {
            Input[] inputs = new Input[2];
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].keyboardInput.wVk = 0;
            inputs[0].keyboardInput.dwFlags = (int) KEYEVENTF_UNICODE;

            inputs[1].type = INPUT_KEYBOARD;
            inputs[1].keyboardInput.wVk = 0;
            inputs[1].keyboardInput.dwFlags = (int) (KEYEVENTF_KEYUP | KEYEVENTF_UNICODE);

            for (int i = 0; i < message.Length; i++)
            {
                inputs[0].keyboardInput.wScan = (short) message[i];
                inputs[1].keyboardInput.wScan = (short) message[i];
                SendInput(2, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
            }
        }

        /*
        void SendUnicode(char key)
        {
            Input[] inputs = new Input[2];

            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].keyboardInput.wVk = 0;
            inputs[0].keyboardInput.wScan = (short)key;
            inputs[0].keyboardInput.dwFlags = (int)KEYEVENTF_UNICODE;//KEYEVENTF_UNICODE;

            inputs[1].type = INPUT_KEYBOARD;
            inputs[1].keyboardInput.wVk = 0;
            inputs[1].keyboardInput.wScan = (short)key;
            inputs[1].keyboardInput.dwFlags =(int)(KEYEVENTF_KEYUP | KEYEVENTF_UNICODE);//KEYEVENTF_UNICODE;

            SendInput(2, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        void SendKeys(string msg)
        {
            short vk;
            char[] data=msg.ToCharArray();
            for (int i=0;i<data.Length;i++)
            {
                if (data[i] >= 0 && data[i] < 256) //ascii字符
                {
                    vk = VkKeyScanW(data[i]);
                    if (vk == -1)
                    {
                        SendUnicode(data[i]);
                    }
                    else
                    {
                        if (vk < 0)
                        {
                            vk = ~vk + 0x1;
                        }

                        shift = vk >> 8 & 0x1;

                        if (GetKeyState(VK_CAPITAL) & 0x1)
                        {
                            if (data[i] >= 'a' && data[i] <= 'z' || data[i] >= 'A' && data[i] <= 'Z')
                            {
                                shift = !shift;
                            }
                        }
                        SendAscii(vk & 0xFF, shift);
                    }
            }else //unicode字符
                {
                    SendUnicode(data[i]);
                }
                
            }
        }

        void SendAscii(Keys key)
        {
            KeyDown(key);
            KeyUp(key);
        }
        */


        public static void KeyDown(Keys key)
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].keyboardInput.wVk = (short) key;
            inputs[0].keyboardInput.dwFlags = 0;
            inputs[0].keyboardInput.time = GetTickCount();
            inputs[0].keyboardInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void KeyUp(Keys key)
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_KEYBOARD;
            inputs[0].keyboardInput.wVk = (short) key;
            inputs[0].keyboardInput.dwFlags = (int) KEYEVENTF_KEYUP;
            inputs[0].keyboardInput.time = GetTickCount();
            inputs[0].keyboardInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseLeftKeyDown()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_LEFTDOWN;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseLeftKeyUp()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_LEFTUP;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseRightKeyDown()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_RIGHTDOWN;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseRightKeyUp()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_RIGHTUP;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseMiddleKeyDown()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (short) MOUSEEVENTF_MIDDLEDOWN;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseMiddleKeyUp()
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (short) MOUSEEVENTF_MIDDLEUP;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseMove(int cx, int cy)
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = cy;
            inputs[0].mouseInput.dy = cy;
            inputs[0].mouseInput.mouseData = 0;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_MOVE;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }

        public static void MouseMoveTo(int x, int y)
        {
            MouseMoveTo(x, y, 0, 0);
        }

        public static void MouseMoveTo(int x, int y, int maxMove, int interval)
        {
            Input[] inputs = new Input[1];
            Point p = new Point();
            int n;
            int perWidth = (0xFFFF/(GetSystemMetrics(SM_CXSCREEN) - 1));
            int perHeight = (0xFFFF/(GetSystemMetrics(SM_CYSCREEN) - 1));

            if (maxMove <= 0)
            {
                maxMove = 0x7FFFFFFF;
            }
            GetCursorPos(out p);

            while (p.X != x || p.Y != y)
            {
                n = x - p.X;
                if (Math.Abs(n) > maxMove)
                {
                    if (n > 0)
                    {
                        n = maxMove;
                    }
                    else
                    {
                        n = -maxMove;
                    }
                }
                p.X = p.X + n;

                n = y - p.Y;
                if (Math.Abs(n) > maxMove)
                {
                    if (n > 0)
                    {
                        n = maxMove;
                    }
                    else
                    {
                        n = -maxMove;
                    }
                }
                p.Y = p.Y + n;

                inputs[0].type = INPUT_MOUSE;
                inputs[0].mouseInput.dx = p.X*perWidth;
                inputs[0].mouseInput.dy = p.Y*perHeight;
                inputs[0].mouseInput.mouseData = 0;
                inputs[0].mouseInput.dwFlags = (int) (MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE);
                inputs[0].mouseInput.time = GetTickCount();
                inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
                SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
                if (interval != 0)
                {
                    System.Threading.Thread.Sleep(interval);
                }
            }
        }

        public static void MouseWheel(int cz)
        {
            Input[] inputs = new Input[1];
            inputs[0].type = INPUT_MOUSE;
            inputs[0].mouseInput.dx = 0;
            inputs[0].mouseInput.dy = 0;
            inputs[0].mouseInput.mouseData = cz;
            inputs[0].mouseInput.dwFlags = (int) MOUSEEVENTF_WHEEL;
            inputs[0].mouseInput.time = GetTickCount();
            inputs[0].mouseInput.dwExtraInfo = GetMessageExtraInfo();
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }
    }
}