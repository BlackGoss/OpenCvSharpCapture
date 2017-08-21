using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenCVDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cap = VideoCapture.FromCamera(CaptureDevice.Any);
            cap.Set(CaptureProperty.FrameWidth, 1366);
            cap.Set(CaptureProperty.FrameHeight, 1366);
            Mat mat = new Mat();
            while (cap.Read(mat))
            {
                File.WriteAllBytes(@"D:\code\cap\" + DateTime.Now.Ticks + ".png", mat.ToBytes());
                Thread.Sleep(2000);
            }
            cap.Release();
            cap.Dispose();

        }
    }
}
