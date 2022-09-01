using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TF2HatCrafter
{
    public partial class Clicker : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int x, int y);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys ArrowKeys);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, int dwExtraInfo);

        //DO NOT EDIT THIS. IT'S 4 MATH...
        public static Point MyScreenSize = new Point(1920, 1080);
        public static Point MyFirstMetal = new Point(1040, 355);
        public static Point MySecondMetal = new Point(1200, 355);
        public static Point MyThirdMetal = new Point(1360, 355);
        public static Point MyRefinedMetal = new Point(630, 355);
        public static Point MyCraft = new Point(1180, 860);
        public static Point MyConfirm = new Point(960, 645);
        //You can edit from here
        public static Point YourScreenSize = new Point(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Height);

        public static Point CalculatedDifference = new Point(MyScreenSize.X / YourScreenSize.X, MyScreenSize.Y / YourScreenSize.Y);
        
        public static Point YourFirstMetal = new Point(MyFirstMetal.X * CalculatedDifference.X, MyFirstMetal.Y * CalculatedDifference.Y);
        public static Point YourSecondMetal = new Point(MySecondMetal.X * CalculatedDifference.X, MySecondMetal.Y * CalculatedDifference.Y);
        public static Point YourThirdMetal = new Point(MyThirdMetal.X * CalculatedDifference.X, MyThirdMetal.Y * CalculatedDifference.Y);
        public static Point YourRefinedMetal = new Point(MyRefinedMetal.X * CalculatedDifference.X, MyRefinedMetal.Y * CalculatedDifference.Y);
        public static Point YourCraft = new Point(MyCraft.X * CalculatedDifference.X, MyCraft.Y * CalculatedDifference.Y);
        public static Point YourConfirm = new Point(MyConfirm.X * CalculatedDifference.X, MyConfirm.Y * CalculatedDifference.Y);

        public Clicker()
        {
            this.Opacity = 0;

            Task AutoClicker = new Task(() => 
            { 
                while (true)
                {
                    if (GetAsyncKeyState(Keys.F1) < 0)
                    {
                        CraftHat();
                    }
                    if (GetAsyncKeyState(Keys.F9) < 0)
                    {
                        return;
                    }
                    System.Threading.Thread.Sleep(20);
                }
            });
            AutoClicker.Start();

            AutoClicker.Wait();
            this.Close();
        }

        public static void MoveMouse(int x, int y)
        {
            SetCursorPos(x, y);
            System.Threading.Thread.Sleep(50);
        }

        public static void CraftHat()
        {
            MoveMouse(YourFirstMetal.X, YourFirstMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);
            MoveMouse(YourRefinedMetal.X, YourRefinedMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);

            MoveMouse(YourSecondMetal.X, YourSecondMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);
            MoveMouse(YourRefinedMetal.X, YourRefinedMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);

            MoveMouse(YourThirdMetal.X, YourThirdMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);
            MoveMouse(YourRefinedMetal.X, YourRefinedMetal.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);


            MoveMouse(YourCraft.X, YourCraft.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(500);
            MoveMouse(YourConfirm.X, YourConfirm.Y);
            ClickMouse();
            System.Threading.Thread.Sleep(100);
        }

        public static void ClickMouse()
        {
            mouse_event(0x0002, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(5);
            mouse_event(0x0004, 0, 0, 0, 0);
            System.Threading.Thread.Sleep(5);
        }
    }
}
