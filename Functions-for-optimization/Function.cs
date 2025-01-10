using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3D_Chart_WPF_v1
{
    public class Function : INotifyPropertyChanged
    {
        private string name, formula, description;
        private Func<double, double, double> func;
        private double xminimum, yminimum, xmaximum, ymaximum, spacing2D;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Formula
        {
            get { return formula; }
            set
            {
                formula = value;
                OnPropertyChanged("Formula");
            }
        }

        public Func<double, double, double> Func
        {
            get { return func; }
            set
            {
                func = value;
                OnPropertyChanged("Func");
            }
        }

        public string Description
        {
            get { return "Formula:\r" + formula + "\r\r" + description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public double Xminimum
        {
            get { return xminimum; }
            set { xminimum = value; }
        }
        public double Xmaximum
        {
            get { return xmaximum; }
            set { xmaximum = value; }
        }
        public double Yminimum
        {
            get { return yminimum; }
            set { yminimum = value; }
        }
        public double Ymaximum
        {
            get { return ymaximum; }
            set { ymaximum = value; }
        }
        public double Spacing2D
        {
            get { return spacing2D; }
            set { spacing2D = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
