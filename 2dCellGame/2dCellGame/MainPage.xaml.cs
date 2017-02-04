using Windows.UI;
using System.Numerics;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Text;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas.Effects;
using System;
using System.Security;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.ViewManagement;

namespace _2dCellGame
{

    public sealed partial class MainPage : Page
    {

        Random rnd = new Random();

        public bool[] keys = new bool[] { false, false, false, false, false };
        public const int up = 0, down = 1, left = 2, right = 3, space = 4;
        public int xAxis = 240, yAxis = 240;

        public static ICollection<string> lines = new SortedSet<string>();
        public static ICollection<int> lines2 = new SortedSet<int>();
        public static ICollection<int> lines3 = new SortedSet<int>();

        static TimeSpan TargetElapsedTime = TimeSpan.FromSeconds(1.0 / 20.0);

        public MainPage()
        {
            this.InitializeComponent();
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp; 
        }

        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender,
            Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    keys[up] = true;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Down:
                    keys[up] = false;
                    keys[down] = true;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Left:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = true;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Right:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = true;
                    keys[space] = false;
                    break;
                case VirtualKey.Space:
                    keys[space] = true;
                    break;
            }
            args.Handled = true; 
        }

        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender,
            Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Down:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Left:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Right:
                    keys[up] = false;
                    keys[down] = false;
                    keys[left] = false;
                    keys[right] = false;
                    keys[space] = false;
                    break;
                case VirtualKey.Space:
                    keys[space] = false;
                    break;
            }
            args.Handled = true;
        }

        private void canvas_CreateResources(
            Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedControl sender,
            Microsoft.Graphics.Canvas.UI.CanvasCreateResourcesEventArgs args)
        {
            CanvasCommandList cl = new CanvasCommandList(sender);
            using (CanvasDrawingSession clds = cl.CreateDrawingSession())
            {
                canvas.Width = 600;
                canvas.Height = 600;
                canvas.TargetElapsedTime = TargetElapsedTime;
            }
        }

        private void canvas_AnimatedDraw(
            Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender,
            Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            drawPlayer(args);
        }

        private void canvas_AnimatedUpdate(
            Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender,
            Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedUpdateEventArgs args)
        {
            
            updatePlayer();
        }
        public void updatePlayer()
        {
            if (keys[up])
                yAxis = yAxis - 8;
            keys[up] = false;
            if (keys[down])
                yAxis = yAxis + 8;
            keys[down] = false;
            if (keys[left])
                xAxis = xAxis - 8;
            keys[left] = false;
            if (keys[right])
                xAxis = xAxis + 8;
            keys[right] = false;
        }
        public void drawPlayer(Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            args.DrawingSession.FillRectangle(xAxis, yAxis, 8, 8, Colors.Orange);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            this.canvas.RemoveFromVisualTree();
            this.canvas = null;
        }

    }
}