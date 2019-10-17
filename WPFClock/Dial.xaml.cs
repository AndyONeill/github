using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFClock
{
    /// <summary>
    /// Interaction logic for Dial.xaml
    /// </summary>
    public partial class Dial : UserControl
    {
        public Brush DialBrush
        {
            get { return (Brush)GetValue(DialBrushProperty); }
            set { SetValue(DialBrushProperty, value); }
        }
        public static readonly DependencyProperty DialBrushProperty =
            DependencyProperty.Register("DialBrush", typeof(Brush), typeof(Dial), new PropertyMetadata(Brushes.Blue));
        public double? Min
        {
            get { return (double?)GetValue(MinProperty); }
            set { SetValue(MinProperty, value); }
        }
        public static readonly DependencyProperty MinProperty =
            DependencyProperty.Register("Min", typeof(double?), typeof(Dial), new FrameworkPropertyMetadata(
                  0.0
                , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                , new PropertyChangedCallback(CallRecalculate)));
        public double? Max
        {
            get { return (double?)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }
        public static readonly DependencyProperty MaxProperty =
            DependencyProperty.Register("Max", typeof(double?), typeof(Dial), new FrameworkPropertyMetadata(
                  60.0
                , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                , new PropertyChangedCallback(CallRecalculate)));
        public double? Increment
        {
            get { return (double?)GetValue(IncrementProperty); }
            set { SetValue(IncrementProperty, value); }
        }
        public static readonly DependencyProperty IncrementProperty =
            DependencyProperty.Register("Increment", typeof(double?), typeof(Dial)
                , new FrameworkPropertyMetadata(
                  1.0
                , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                , new PropertyChangedCallback(CallRecalculate)));
        private static void Recalculate(Dial d)
        {
            if (d == null)
                return;
            if (d.Increment == null || d.Min == null || d.Max == null)
                return;
            d.degreesPerIncrement = (double)(360.0 / (d.Max - d.Min + 1.0));
            int newValue = (int)(d.Angle % d.degreesPerIncrement);
            d.SetCurrentValue(Dial.ValueProperty, newValue);
        }
        private static void CallRecalculate(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var _this = d as Dial;
            if (_this == null)
                return;
            if (e.NewValue == e.OldValue)
                return;
            Recalculate(_this);
        }
        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value"
                , typeof(int)
                , typeof(Dial)
                , new FrameworkPropertyMetadata(
                  0
                , FrameworkPropertyMetadataOptions.BindsTwoWayByDefault
                     , new PropertyChangedCallback(ValueChanged)
                ));
        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var _this = d as Dial;
            if (_this.Increment == null || _this.Min == null || _this.Max == null)
                return;
            _this.degreesPerIncrement = (double)(360.0 / (_this.Max - _this.Min + 1.0));
            double newValue = (int)(_this.degreesPerIncrement * (int)e.NewValue);
            _this.SetCurrentValue(Dial.AngleProperty, newValue);
        }
        public double? Angle
        {
            get { return (double?)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double?), typeof(Dial), new PropertyMetadata(0.0));
        private double degreesPerIncrement = 0.0;
        public Dial()
        {
            InitializeComponent();
            Loaded += Dial_Loaded;
        }
        private void Dial_Loaded(object sender, RoutedEventArgs e)
        {
            indicator.Points = new PointCollection { new Point(0, 0), new Point(0, this.ActualHeight / 7) };
        }
        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                UserControl ctrl = sender as UserControl;
                Point ptr = e.GetPosition(ctrl);
                Point center = new Point(ctrl.ActualWidth / 2, ctrl.ActualHeight / 2);
                Point toCentre = new Point(ptr.X - center.X, ptr.Y - center.Y);
                double degrees = (Math.Atan2(toCentre.Y, toCentre.X) * (180 / Math.PI)) + 90.0;
                // you get negative numbers for the top left quadrant = 9pm to 12pm
                if (degrees < 0)
                    degrees = 360.0 + degrees;
                Angle = degrees;
                if (degreesPerIncrement == 0.0)
                    Recalculate(this);
                Value = (int)(degrees / degreesPerIncrement);
            }
        }
    }
}
