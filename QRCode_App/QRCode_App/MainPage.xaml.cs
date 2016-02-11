using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace QRCode_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaCapture _captureManager;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void InitializeCamera()
        {
            var videoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            var rearCamera = videoDevices.First(item => item.EnclosureLocation != null &&
                                                        item.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back);
            _captureManager = new MediaCapture();

            await _captureManager.InitializeAsync(new MediaCaptureInitializationSettings
            {
                VideoDeviceId = rearCamera.Id
            });

            capturePreview.Source = _captureManager;
            await _captureManager.StartPreviewAsync();
        }
    }
}
