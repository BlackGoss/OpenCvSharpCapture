using Cocon90.Lib.Util.Window.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenCVDemoService
{
    public class ServiceMaster
    {
        public static string ServiceDiscription = "No.";

        public static string ServiceName = Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().FullName);
        public static string ServiceExecutePath { get { return Assembly.GetExecutingAssembly().Location; } }
        static Service.CaptureService service = null;
        /// <summary>
        /// 启动服务时发生
        /// </summary>
        public static void RunService()
        {
            if (service == null) service = new Service.CaptureService();
            service.Start();
        }
        /// <summary>
        /// 停止服务时发生
        /// </summary>
        public static void StopService()
        {
            service.Stop();
        }
        /// <summary>
        /// 执行安装并启动服务
        /// </summary>
        /// <returns></returns>
        public static bool InstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Start();
        }
        /// <summary>
        /// 执行卸载服务
        /// </summary>
        /// <returns></returns>
        public static bool UninstallService()
        {
            ServiceControl sc = new ServiceControl(ServiceName, ServiceExecutePath, ServiceDiscription);
            return sc.Stop();
        }
    }
}
