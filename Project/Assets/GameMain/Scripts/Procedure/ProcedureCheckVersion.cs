using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using UnityGameFramework.Runtime;
using GameFramework.Event;
using UnityEngine;
using GameFramework;

namespace FYProject
{
    /// <summary>
    /// 版本检测流程
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        private bool m_ResourceInitComplete = false;

        public override bool UseNativeDialog
        {
            get
            {
                return true;
            }
        }

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            GameEntry.Event.Subscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Subscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
            GameEntry.Event.Subscribe(ResourceInitCompleteEventArgs.EventId, OnResourceInitComplete);

            RequestVersion();
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            GameEntry.Event.Unsubscribe(WebRequestSuccessEventArgs.EventId, OnWebRequestSuccess);
            GameEntry.Event.Unsubscribe(WebRequestFailureEventArgs.EventId, OnWebRequestFailure);
            GameEntry.Event.Unsubscribe(ResourceInitCompleteEventArgs.EventId, OnResourceInitComplete);

            base.OnLeave(procedureOwner, isShutdown);
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if (!m_ResourceInitComplete)
            {
                return;
            }

            ChangeState<ProcedurePreload>(procedureOwner);
        }


        void RequestVersion()
        {
            string deviceId = SystemInfo.deviceUniqueIdentifier;//设备的唯一标识id
            string deviceName = SystemInfo.deviceName;//设备名称
            string deviceModel = SystemInfo.deviceModel;//设备模式
            string processorType = SystemInfo.processorType;//处理器名称
            string processorCount = SystemInfo.processorCount.ToString();//当前处理器数量
            string memorySize = SystemInfo.systemMemorySize.ToString();//系统内存大小
            string operatingSystem = SystemInfo.operatingSystem;//操作系统类型
            string iOSGeneration = string.Empty;//
            string iOSSystemVersion = string.Empty;//ios系统版本
            string iOSVendorIdentifier = string.Empty;//ios供应商标识符
#if UNITY_IOS && UNITY_EDITOR
            iOSGeneration = UnityEngine.iOS.Device.generation.ToString();//
            iOSSystemVersion = UnityEngine.iOS.Device.systemVersion;//ios系统版本
            iOSVendorIdentifier = UnityEngine.iOS.Device.vendorIdentifier ?? string.Empty;//ios供应商标识符
#endif
            string gameVersion = GameEntry.Base.GameVersion;//游戏版本
            string platform = Application.platform.ToString();//游戏运行的平台
            string language = GameEntry.Localization.Language.ToString();//本地语言
            string unityVersion = Application.unityVersion;//Unity版本
            string installMode = Application.installMode.ToString();//返回应用程序安装模式
            string sandboxType = Application.sandboxType.ToString();//应用程序运行的沙盒名称
            string screenWidth = Screen.width.ToString();//屏幕宽度
            string screenHeight = Screen.height.ToString();//屏幕高度
            string screenDpi = Screen.dpi.ToString();//屏幕dpi
            string screenOrientation = Screen.orientation.ToString();//屏幕的逻辑方向
            string screenResolution = string.Format("{0} x {1} @ {2}Hz", Screen.currentResolution.width.ToString(), Screen.currentResolution.height.ToString(), Screen.currentResolution.refreshRate.ToString());//屏幕分辨率
            string useWifi = (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork).ToString();

            WWWForm wwwForm = new WWWForm();
            wwwForm.AddField("DeviceId", WebUtility.EscapeString(deviceId));
            wwwForm.AddField("DeviceName", WebUtility.EscapeString(deviceName));
            wwwForm.AddField("DeviceModel", WebUtility.EscapeString(deviceModel));
            wwwForm.AddField("ProcessorType", WebUtility.EscapeString(processorType));
            wwwForm.AddField("ProcessorCount", WebUtility.EscapeString(processorCount));
            wwwForm.AddField("MemorySize", WebUtility.EscapeString(memorySize));
            wwwForm.AddField("OperatingSystem", WebUtility.EscapeString(operatingSystem));
            wwwForm.AddField("IOSGeneration", WebUtility.EscapeString(iOSGeneration));
            wwwForm.AddField("IOSSystemVersion", WebUtility.EscapeString(iOSSystemVersion));
            wwwForm.AddField("IOSVendorIdentifier", WebUtility.EscapeString(iOSVendorIdentifier));
            wwwForm.AddField("GameVersion", WebUtility.EscapeString(gameVersion));
            wwwForm.AddField("Platform", WebUtility.EscapeString(platform));
            wwwForm.AddField("Language", WebUtility.EscapeString(language));
            wwwForm.AddField("UnityVersion", WebUtility.EscapeString(unityVersion));
            wwwForm.AddField("InstallMode", WebUtility.EscapeString(installMode));
            wwwForm.AddField("SandboxType", WebUtility.EscapeString(sandboxType));
            wwwForm.AddField("ScreenWidth", WebUtility.EscapeString(screenWidth));
            wwwForm.AddField("ScreenHeight", WebUtility.EscapeString(screenHeight));
            wwwForm.AddField("ScreenDPI", WebUtility.EscapeString(screenDpi));
            wwwForm.AddField("ScreenOrientation", WebUtility.EscapeString(screenOrientation));
            wwwForm.AddField("ScreenResolution", WebUtility.EscapeString(screenResolution));
            wwwForm.AddField("UseWifi", WebUtility.EscapeString(useWifi));

            GameEntry.WebRequest.AddWebRequest(GameEntry.BuiltinData.BuildInfo.CheckVersionUrl, wwwForm, this);
        }

        private void OnWebRequestSuccess(object sender, GameEventArgs e)
        {
            WebRequestSuccessEventArgs ne = (WebRequestSuccessEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            string responseJson = Utility.Converter.GetString(ne.GetWebResponseBytes());
            VersionInfo versionInfo = Utility.Json.ToObject<VersionInfo>(responseJson);
            if (versionInfo == null)
            {
                Log.Error("Parse VersionInfo failure.");
                return;
            }

            Log.Info("Latest game version is '{0}', local game version is '{1}'.", versionInfo.LatestGameVersion, GameEntry.Base.GameVersion);

            if (versionInfo.ForceGameUpdate)
            {
                var dialogParams = new DialogParams();
                dialogParams.Mode = 2;
                dialogParams.Title = GameEntry.Localization.GetString("ForceUpdate.Title");
                dialogParams.Message = GameEntry.Localization.GetString("ForceUpdate.Message");
                dialogParams.ConfirmText = GameEntry.Localization.GetString("ForceUpdate.UpdateButton");
                dialogParams.OnClickConfirm = (userData) => { Application.OpenURL(versionInfo.GameUpdateUrl); };
                dialogParams.ConfirmText = GameEntry.Localization.GetString("ForceUpdate.QuitButton");
                dialogParams.OnClickCancel = (userData) => { UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Quit); };

                GameEntry.UI.OpenDialog(dialogParams);

                return;
            }

            GameEntry.Resource.InitResources();
        }

        private void OnWebRequestFailure(object sender, GameEventArgs e)
        {
            WebRequestFailureEventArgs ne = (WebRequestFailureEventArgs)e;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Warning("Check version failure.");

            GameEntry.Resource.InitResources();
        }

        private void OnResourceInitComplete(object sender, GameEventArgs e)
        {
            m_ResourceInitComplete = true;

            Log.Info("Init resource complete.");
        }
    }

}