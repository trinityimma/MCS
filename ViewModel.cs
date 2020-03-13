using LiveCharts;
using MCSLib.Abstraction;
using MCSLib.PDFs;
using MCSLib.Simulation;
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
            SimResultList = new List<StatisticalResult>();
            RunMCSCommand = new Command(RumMCSAction, (x)=>true);
            ChartCommand = new Command(ViewPlotAction, (x) => SimResultList.Count > 0);
            _distributionInput = new DistributionInput();
            _simulator = new Simulator();
        }

        private void ViewPlotAction(object obj)
        {
            IsTableView = false;
            IsChartView = true;
            ColumnValues = new ChartValues<double>();
            LineValues = new ChartValues<double>();
            ExpectationValues = new ChartValues<double>();
            Labels = new string[SimResultList.Count];
            ExpectationLables = new string[SimResultList.Count];
            for (int i = 0; i < SimResultList.Count; i++)
            {
                if (SimResultList[i].RelativeFrequency >= 0)
                {
                    ColumnValues.Add(SimResultList[i].RelativeFrequency);
                    Labels[i] = Math.Round(_simulatedValues[i], 0).ToString();
                    LineValues.Add(SimResultList[i].RelativeFrequency);
                    ExpectationValues.Add(SimResultList[i].Expectation);
                    ExpectaValues.Add(SimResultList[i].RelativeFrequency);
                    ExpectationLables[i] = Math.Round(SimResultList[i].BinSize, 0).ToString();
                }
            }
            Formatter = value => value.ToString();
        }

        private void RumMCSAction(object obj)
        {
            IsTableView = true;
            IsChartView = false;
            if (Iteration > 0)
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
                _simulatedValues = _simulator.SimulationResult.SimulatedValues;
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
        private IList<StatisticalResult> simulationResults;

        public IList<StatisticalResult> SimResultList
        {
            get { return simulationResults; }
            set { simulationResults = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<ColumnItem> relativePlot;

        public ObservableCollection<ColumnItem> RelativePlot
        {
            get { return relativePlot; }
            set { relativePlot = value; RaisePropertyChanged(); }
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


        //LiveChart
        private SeriesCollection sc;

        public SeriesCollection SeriesCollection
        {
            get { return sc; }
            set { sc = value; RaisePropertyChanged(); }
        }

        private string[] lables;

        public string[] Labels
        {
            get { return lables; }
            set { lables = value; RaisePropertyChanged(); }
        }

        private string[] expectationLables;

        public string[] ExpectationLables
        {
            get { return expectationLables; }
            set { expectationLables = value; RaisePropertyChanged(); }
        }

        private Func<double, string> formater;

        public Func<double, string> Formatter
        {
            get { return formater; }
            set { formater = value; RaisePropertyChanged(); }
        }
        private ChartValues<double> lineValues;

        public ChartValues<double> LineValues
        {
            get { return lineValues; }
            set { lineValues = value; RaisePropertyChanged(); }
        }
        private ChartValues<double> columnvalues;

        public ChartValues<double> ColumnValues
        {
            get { return columnvalues; }
            set { columnvalues = value; RaisePropertyChanged(); }
        }

        private ChartValues<double> expectationvalues;

        public ChartValues<double> ExpectationValues
        {
            get { return expectationvalues; }
            set { expectationvalues = value; RaisePropertyChanged(); }
        }

        private ChartValues<double> expectavalues;

        public ChartValues<double> ExpectaValues
        {
            get { return expectavalues; }
            set { expectavalues = value; RaisePropertyChanged(); }
        }
    }

    public class ColumnItem
    {
        public double YValue { get; set; }
        public double XValue { get; set; }
    }
}
