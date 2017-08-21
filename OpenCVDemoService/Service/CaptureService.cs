using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace OpenCVDemoService.Service
{
    class CaptureService : Cocon90.Lib.Util.Server.BaseIntervalServer
    {
        public CaptureService() : base(5000)
        {

        }
        public override void DoSomeThing(DateTime? startTime, long count)
        {

            var cap = VideoCapture.FromCamera(CaptureDevice.Any);
            cap.Set(CaptureProperty.FrameWidth, 512);
            cap.Set(CaptureProperty.FrameHeight, 300);
            Mat mat = new Mat();
            //while ())
            {
                cap.Read(mat);
                File.WriteAllBytes(@"D:\code\cap\" + DateTime.Now.Ticks + ".png", mat.ToBytes());
                
            }
            cap.Release();
            cap.Dispose();
        }
    }
}
