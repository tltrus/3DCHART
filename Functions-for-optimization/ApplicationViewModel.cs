using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _3D_Chart_WPF_v1
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Function selectedFunction;

        public ObservableCollection<Function> Functions { get; set; }
        public Function SelectedFunction
        {
            get { return selectedFunction; }
            set
            {
                selectedFunction = value;
                OnPropertyChanged("SelectedFunction");
            }
        }

        public ApplicationViewModel()
        {
            Functions = new ObservableCollection<Function>
            {
                new Function {
                    Name="Himmelblau's function",
                    Formula="f(x,y) = (x^2 + y - 11)^2 + (x + y^2 - 7)^2",
                    Func=(x, y) => (x*x + y - 11)*(x*x + y - 11) + (x + y*y - 7)*(x + y*y - 7),
                    Description= "Global minimum is at \r[3.0, 2.0], [-2.805118, 3.131312], [-3.779310, -3.283186], [3.584428, -1.848126] \rwhere f(x, y) = 0",
                    Xminimum=-5,
                    Xmaximum=5,
                    Yminimum=-5,
                    Ymaximum=5,
                    Spacing2D=0.1
                },
                new Function {
                    Name="Sphere function",
                    Formula="f(x,y) = x^2 + y^2",
                    Func=(x, y) => x*x + y*y,
                    Description= "Global minimum is at [ 0, 0 ] where f(x, y) = 0",
                    Xminimum=-4,
                    Xmaximum=4,
                    Yminimum=-4,
                    Ymaximum=4,
                    Spacing2D=0.1
                },
                new Function {
                    Name="Michalewicz function", 
                    Formula="f(x,y) = -1*((sin(x)*(Math.Sin((1*x^2)/pi))^20+(sin(y)*(Math.Sin((2*y*y)/Math.PI))^20)))", 
                    Func=(x, y) => -1 * ((Math.Sin(x) * Math.Pow(Math.Sin((1 * x * x) / Math.PI), 20) + (Math.Sin(y) * Math.Pow(Math.Sin((2 * y * y) / Math.PI), 20)))),
                    Description= "Global minimum is at [ 2.20319, 1.57049 ] where f(x, y) = -1.8013 ",
                    Xminimum=-4,
                    Xmaximum=4,
                    Yminimum=-4,
                    Ymaximum=4,
                    Spacing2D=0.1
                },
                new Function {
                    Name="Rosenbrock's function", 
                    Formula="f(x,y) = 100*(y-x^2)^2 + (1-x)^2", 
                    Func=(x, y) => 100.0 * Math.Pow((y - x * x), 2) + Math.Pow(1 - x, 2),
                    Description= "Global minimum is at [ 1, 1 ] where f(x, y) = 0",
                    Xminimum=-3,
                    Xmaximum=3,
                    Yminimum=-3,
                    Ymaximum=3,
                    Spacing2D=0.1
                },
                new Function {
                    Name="Rastrigin function", 
                    Formula="f(x,y) = (x^2 - 10*cos(2*PI*x)) + (y^2 - 10*cos(2*PI*y)) + 20", 
                    Func=(x, y) => (x * x - 5 * Math.Cos(2 * Math.PI * x)) + (y * y - 5 * Math.Cos(2 * Math.PI * y)),
                    Description= "Global minimum is at [ 0, 0 ] where f(x, y) = 0",
                    Xminimum=-5,
                    Xmaximum=5,
                    Yminimum=-5,
                    Ymaximum=5,
                    Spacing2D=0.1
                },
                new Function {
                    Name="Schwefel's function", 
                    Formula="f(x,y) = (-x*sin(sqrt(abs(x)))) + (-y*sin(sqrt(abs(y))))", 
                    Func=(x, y) => (-x * Math.Sin(Math.Sqrt(Math.Abs(x)))) + (-y * Math.Sin(Math.Sqrt(Math.Abs(y)))),
                    Description= "Global minimum is at [ 420.9687, 420.9687 ] where f(x, y) = 0",
                    Xminimum=-500,
                    Xmaximum=500,
                    Yminimum=-500,
                    Ymaximum=500,
                    Spacing2D=12
                },
                 new Function {
                    Name="Ackley's function",
                    Formula="f(x,y) = -20*exp(-0.2*sqrt(0.5*(x^2 + y^2))) - exp(cos(2*pi*x) + cos(2*pi*y)) + 20 + e",
                    Func=(x, y) => -20.0 * Math.Exp(-0.2 * Math.Sqrt(0.5*(x*x + y*y))) - Math.Exp(Math.Cos(2*Math.PI*x) + Math.Cos(2*Math.PI*y)) + 20.0 + Math.E,
                    Description= "Global minimum is at [ 0, 0 ] where f(x, y) = 0",
                    Xminimum=-10,
                    Xmaximum=10,
                    Yminimum=-10,
                    Ymaximum=10,
                    Spacing2D=0.1
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
