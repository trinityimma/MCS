using MCSLib.Abstraction;
using MCSLib.PDFs;
using MCSLib.Simulation;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MCS
{
    internal class ViewModel: INotifyPropertyChanged
    {
        public ViewModel()
        {
            DistributionTypes = new List<DistributionType>() {
                DistributionType.Uniform,
                DistributionType.Triangular,
                DistributionType.Normal,
                DistributionType.Log_Normal
            };
            IsTableView = true;
            IsChartView = false;
            IsMinEnabled = true;
            IsMaxEnabled = true;
            IsModeEnabled = false;
            IsAvgEnabled = false;
            IsStDevEnabled = false;
            SimResultList = new List<SimulationResult>();
            RunMCSCommand = new Command(RumMCSAction, (x)=>true);
            ChartCommand = new Command(ViewPlotAction, (x) => SimResultList.Count > 0);
            _distributionInput = new DistributionInput();
            _simulator = new Simulator();
        }

        private void ViewPlotAction(object obj)
        {
            IsTableView = false;
            IsChartView = true;
            RelativePlot = new ObservableCollection<RelItem>();
            ExpectationPlot = new ObservableCollection<DataPoint>();
            RelativeLine = new ObservableCollection<DataPoint>();
            for (int i = 0; i < SimResultList.Count; i++)
            {
                RelativePlot.Add(new RelItem { RelValue=SimResultList[i].RelativeFrequency,Label= _simulatedValues[i] });
                ExpectationPlot.Add(new DataPoint(SimResultList[i].BinSize, SimResultList[i].Expectation));
                RelativeLine.Add(new DataPoint(SimResultList[i].BinSize, SimResultList[i].RelativeFrequency));
                AbsoluteMaximum = RelativePlot.Count;
            }
        }

        private void RumMCSAction(object obj)
        {
            IsTableView = true;
            IsChartView = false;
            if (Iteration> 0)
            {
                _distributionInput.Delegate = GetSimResult;
                _distributionInput.Iteration = Iteration;
                _distributionInput.Interval = Interval;
                switch (SelectedDistribution)
                {
                    case DistributionType.Uniform:
                        _distributionInput.UncertaintyArray = new[] { Min, Max };
                        _distributionInput.UncertaintyList = new List<double> { Min, Max };
                        break;
                    case DistributionType.Triangular:
                        _distributionInput.UncertaintyArray = new[] { Min, Max, Mode };
                        _distributionInput.UncertaintyList = new List<double> { Min, Max, Mode };
                        break;
                    case DistributionType.Normal:
                        break;
                    case DistributionType.Log_Normal:
                        break;
                }


                SimResultList = _simulator.Run(_distributionInput, SelectedDistribution);
                _simulatedValues = _simulator.SimulatedValues;
            }
        }

     

        private double GetSimResult(double safetyFactor)
        {
            return WSLoad * safetyFactor;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        private void ToggleDistribution(DistributionType distributionType)
        {
            switch (distributionType)
            {
                case DistributionType.Uniform:
                    IsMinEnabled = true;
                    IsMaxEnabled = true;
                    IsModeEnabled = false;
                    IsAvgEnabled = false;
                    IsStDevEnabled = false;

                    Mode = 0;
                    Average = 0;
                    StandardDeviation = 0;
                    break;
                case DistributionType.Triangular:
                    IsMinEnabled = true;
                    IsMaxEnabled = true;
                    IsModeEnabled = true;
                    IsAvgEnabled = false;
                    IsStDevEnabled = false;
                    
                    Average = 0;
                    StandardDeviation = 0;
                    break;
                case DistributionType.Normal:
                    IsMinEnabled = false;
                    IsMaxEnabled = false;
                    IsModeEnabled = false;
                    IsAvgEnabled = true;
                    IsStDevEnabled = true;

                    Min = 0;
                    Max = 0;
                    Mode = 0;
                    break;
                case DistributionType.Log_Normal:
                    IsMinEnabled = false;
                    IsMaxEnabled = false;
                    IsModeEnabled = false;
                    IsAvgEnabled = true;
                    IsStDevEnabled = true;

                    Min = 0;
                    Max = 0;
                    Mode = 0;
                    break;
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
       

        private DistributionType _distributionType;
        public DistributionType SelectedDistribution {
            get => _distributionType;
            set
            {
                _distributionType = value;
                RaisePropertyChanged();
                ToggleDistribution(_distributionType);
            }
        }
        public IEnumerable<DistributionType> DistributionTypes { get; set; }
        private bool isMinEnabled;
        public bool IsMinEnabled
        {
            get { return isMinEnabled; }
            set { isMinEnabled = value; RaisePropertyChanged(); }
        }

        private bool isMaxEnabled;
        public bool IsMaxEnabled
        {
            get { return isMaxEnabled; }
            set { isMaxEnabled = value; RaisePropertyChanged(); }
        }
        private bool isModeEnabled;
        public bool IsModeEnabled
        {
            get { return isModeEnabled; }
            set { isModeEnabled = value; RaisePropertyChanged(); }
        }
        private bool isAvgEnabled;
        public bool IsAvgEnabled
        {
            get { return isAvgEnabled; }
            set { isAvgEnabled = value; RaisePropertyChanged(); }
        }
        private bool isStDevEnabled;
        public bool IsStDevEnabled
        {
            get { return isStDevEnabled; }
            set { isStDevEnabled = value; RaisePropertyChanged(); }
        }

        private double min;

        public double Min
        {
            get { return min; }
            set { min = value; RaisePropertyChanged(); }
        }

        private double max;

        public double Max
        {
            get { return max; }
            set { max = value; RaisePropertyChanged(); }
        }

        private double mode;

        public double Mode
        {
            get { return mode; }
            set { mode = value; RaisePropertyChanged(); }
        }

        private double average;

        public double Average
        {
            get { return average; }
            set { average = value; RaisePropertyChanged(); }
        }

        private double standardDeviation;

        public double StandardDeviation
        {
            get { return standardDeviation; }
            set { standardDeviation = value; RaisePropertyChanged(); }
        }
        private IList<SimulationResult> simulationResults;

        public IList<SimulationResult> SimResultList
        {
            get { return simulationResults; }
            set { simulationResults = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<RelItem> relativePlot;

        public ObservableCollection<RelItem> RelativePlot
        {
            get { return relativePlot; }
            set { relativePlot = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DataPoint> expectationPlot;

        public ObservableCollection<DataPoint> ExpectationPlot
        {
            get { return expectationPlot; }
            set { expectationPlot = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<DataPoint> relLine;

        public ObservableCollection<DataPoint> RelativeLine
        {
            get { return relLine; }
            set { relLine = value; RaisePropertyChanged(); }
        }

        private bool isChartView;

        public bool IsChartView
        {
            get { return isChartView; }
            set { isChartView = value; RaisePropertyChanged(); }
        }

        private bool isTableView;

        public bool IsTableView
        {
            get { return isTableView; }
            set { isTableView = value; RaisePropertyChanged(); }
        }
        private int abMax;

        public int AbsoluteMaximum
        {
            get { return abMax; }
            set { abMax = value; RaisePropertyChanged(); }
        }

        public ICommand RunMCSCommand { get; set; }   
        public ICommand ChartCommand { get; set; }   
        
            
        public int Iteration { get; set; }
        public int Interval { get; set; }
        public double WSLoad { get; set; }
        private DistributionInput _distributionInput;
        private IList<double> _simulatedValues;
        private ISimulator _simulator;
    }

    public class RelItem
    {
        public double RelValue { get; set; }
        public double Label { get; set; }
    }
}
