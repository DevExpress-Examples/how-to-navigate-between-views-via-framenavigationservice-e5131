using DevExpress.Xpf.WindowsUI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FrameNavigationServiceSL {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }
    }
    public static class FrameNavigationServiceConnector {
        public static readonly DependencyProperty FrameNavigationServiceProperty =
    DependencyProperty.RegisterAttached("FrameNavigationService", typeof(FrameNavigationService), typeof(FrameNavigationServiceConnector), new PropertyMetadata(OnFrameNavigationServiceChanged));
        public static FrameNavigationService GetFrameNavigationService(DependencyObject obj) {
            return (FrameNavigationService)obj.GetValue(FrameNavigationServiceProperty);
        }
        public static void SetFrameNavigationService(DependencyObject obj, FrameNavigationService value) {
            obj.SetValue(FrameNavigationServiceProperty, value);
        }
        private static void OnFrameNavigationServiceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            FrameNavigationService oldValue = e.OldValue as FrameNavigationService;
            FrameNavigationService newValue = e.NewValue as FrameNavigationService;
            if(oldValue != null) oldValue.Frame = null;
            if(newValue != null) newValue.Frame = d as DevExpress.Xpf.WindowsUI.NavigationFrame;
        }
    }
}
