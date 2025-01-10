using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WPFSurfacePlot3D;


namespace _3D_Chart_WPF_v1
{
    public partial class MainWindow : Window
    {
        public static DrawingVisual visual;
        DrawingContext dc;
        double width, height;

        XYMap my2DPlot;
        SurfacePlotModel my3DSurfacePlotModel;

        List<Function> Functions;
        ApplicationViewModel AppViewModel;

        public MainWindow()
        {
            InitializeComponent();

            AppViewModel = new ApplicationViewModel();
            DataContext = AppViewModel;

            // 3D
            my3DSurfacePlotModel = new SurfacePlotModel();
            g3D.DataContext = my3DSurfacePlotModel;

            // 2D
            visual = new DrawingVisual();
            width = g2D.Width;
            height = g2D.Height;
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var contour_num = int.Parse(tbCnum.Text);
            my2DPlot.SetNumberContours(contour_num);
            my2DPlot.Calculation();
            Drawing2D();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AppViewModel.SelectedFunction is null) return;
            
            Func<double, double, double> sampleFunction = AppViewModel.SelectedFunction.Func;
            double Xmin = AppViewModel.SelectedFunction.Xminimum;
            double Ymin = AppViewModel.SelectedFunction.Yminimum;
            double Xmax = AppViewModel.SelectedFunction.Xmaximum;
            double Ymax = AppViewModel.SelectedFunction.Ymaximum;

            // 3D plot
            my3DSurfacePlotModel.PlotFunction(sampleFunction, Xmin, Xmax, Ymin, Ymax);
            my3DSurfacePlotModel.Title = AppViewModel.SelectedFunction.Name;

            // 2D plot
            my2DPlot = new XYMap(width, height, 20, Xmin, Xmax, Ymin, Ymax, AppViewModel.SelectedFunction.Spacing2D);
            my2DPlot.SetFunc(sampleFunction);
            var contour_num = int.Parse(tbCnum.Text);
            my2DPlot.SetNumberContours(contour_num);
            my2DPlot.Calculation();
            Drawing2D();
        }
        private void Drawing2D()
        {
            g2D.RemoveVisual(visual);
            using (dc = visual.RenderOpen())
            {
                if (cbDrawFunc.IsChecked == true) my2DPlot.Draw2DPlot(dc);
                if (cbDrawContour.IsChecked == true) my2DPlot.DrawContour(dc);


                dc.Close();
                g2D.AddVisual(visual);
            }
        }
        private void cbDrawContour_Click(object sender, RoutedEventArgs e) => Drawing2D();
        private void cbDrawFunc_Click(object sender, RoutedEventArgs e) => Drawing2D();

    }
}
