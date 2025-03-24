using System;
using System.Collections.Generic;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents the dashboard layout
    /// </summary>
    public class DashboardLayout : ModelBase
    {
        private List<DashboardWidget> _widgets = new List<DashboardWidget>();
        private int _columns = 12;
        private int _rowHeight = 50;
        private bool _allowOverlap;
        private bool _compactType = true;
        private bool _autoSize = true;
        private bool _verticalCompact = true;
        private bool _preventCollision = true;
        private bool _isDraggable = true;
        private bool _isResizable = true;
        private bool _locked;
        private bool _showGrid = true;
        private string _backgroundColor = "#FFFFFF";
        private string _gridColor = "#EEEEEE";
        private int _gridThickness = 1;
        private int _margin = 10;
        private int _containerPadding = 10;
        private string _name = "Default";
        private bool _isDefault = true;
        private bool _isAutoSave = true;
        private int _cols = 12;
        private int _rows = 12;
        private double _scale = 1.0;
        private bool _snapToGrid = true;
        private bool _showWidgetBorders = true;
        private string _widgetBorderColor = "#E0E0E0";
        private int _widgetBorderThickness = 1;
        private int _widgetBorderRadius = 4;
        private string _widgetTitleBarColor = "#F5F5F5";
        private string _widgetTitleTextColor = "#212121";
        private string _widgetBackgroundColor = "#FFFFFF";
        private string _widgetShadowColor = "#000000";
        private double _widgetShadowOpacity = 0.1;
        private int _widgetShadowBlur = 10;
        private int _widgetShadowSpread = 0;
        private int _widgetShadowOffsetX = 0;
        private int _widgetShadowOffsetY = 2;
        private bool _showWidgetTitleBar = true;
        private bool _showWidgetCloseButton = true;
        private bool _showWidgetMaximizeButton = true;
        private bool _showWidgetSettingsButton = true;
        private bool _showWidgetRefreshButton = true;
        private int _widgetTitleBarHeight = 32;
        private int _widgetMinWidth = 2;
        private int _widgetMinHeight = 2;
        private int _widgetMaxWidth = 12;
        private int _widgetMaxHeight = 12;
        private string _widgetTextColor = "#212121";
        private string _widgetTitleFontFamily = "Segoe UI";
        private int _widgetTitleFontSize = 14;
        private string _widgetFontFamily = "Segoe UI";
        private int _widgetFontSize = 12;
        private bool _useCompactMode;
        private bool _useAnimations = true;
        private int _animationDuration = 200;
        private string _animationEasing = "ease";
        private string _widgetDefaultType = "Chart";
        private string _widgetDefaultDataSource = "Router";
        private int _widgetDefaultUpdateInterval = 5000;
        private bool _autoResize = true;
        private bool _responsiveLayout = true;
        private bool _preserveAspectRatio = true;

        /// <summary>
        /// Gets or sets the dashboard widgets
        /// </summary>
        public List<DashboardWidget> Widgets
        {
            get => _widgets;
            set => SetProperty(ref _widgets, value);
        }

        /// <summary>
        /// Gets or sets the number of columns
        /// </summary>
        public int Columns
        {
            get => _columns;
            set => SetProperty(ref _columns, value);
        }

        /// <summary>
        /// Gets or sets the row height
        /// </summary>
        public int RowHeight
        {
            get => _rowHeight;
            set => SetProperty(ref _rowHeight, value);
        }

        /// <summary>
        /// Gets or sets whether to allow overlap
        /// </summary>
        public bool AllowOverlap
        {
            get => _allowOverlap;
            set => SetProperty(ref _allowOverlap, value);
        }

        /// <summary>
        /// Gets or sets whether to use compact type
        /// </summary>
        public bool CompactType
        {
            get => _compactType;
            set => SetProperty(ref _compactType, value);
        }

        /// <summary>
        /// Gets or sets whether to auto size
        /// </summary>
        public bool AutoSize
        {
            get => _autoSize;
            set => SetProperty(ref _autoSize, value);
        }

        /// <summary>
        /// Gets or sets whether to use vertical compact
        /// </summary>
        public bool VerticalCompact
        {
            get => _verticalCompact;
            set => SetProperty(ref _verticalCompact, value);
        }

        /// <summary>
        /// Gets or sets whether to prevent collision
        /// </summary>
        public bool PreventCollision
        {
            get => _preventCollision;
            set => SetProperty(ref _preventCollision, value);
        }

        /// <summary>
        /// Gets or sets whether widgets are draggable
        /// </summary>
        public bool IsDraggable
        {
            get => _isDraggable;
            set => SetProperty(ref _isDraggable, value);
        }

        /// <summary>
        /// Gets or sets whether widgets are resizable
        /// </summary>
        public bool IsResizable
        {
            get => _isResizable;
            set => SetProperty(ref _isResizable, value);
        }

        /// <summary>
        /// Gets or sets whether the layout is locked
        /// </summary>
        public bool Locked
        {
            get => _locked;
            set => SetProperty(ref _locked, value);
        }

        /// <summary>
        /// Gets or sets whether to show the grid
        /// </summary>
        public bool ShowGrid
        {
            get => _showGrid;
            set => SetProperty(ref _showGrid, value);
        }

        /// <summary>
        /// Gets or sets the background color
        /// </summary>
        public string BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the grid color
        /// </summary>
        public string GridColor
        {
            get => _gridColor;
            set => SetProperty(ref _gridColor, value);
        }

        /// <summary>
        /// Gets or sets the grid thickness
        /// </summary>
        public int GridThickness
        {
            get => _gridThickness;
            set => SetProperty(ref _gridThickness, value);
        }

        /// <summary>
        /// Gets or sets the margin
        /// </summary>
        public int Margin
        {
            get => _margin;
            set => SetProperty(ref _margin, value);
        }

        /// <summary>
        /// Gets or sets the container padding
        /// </summary>
        public int ContainerPadding
        {
            get => _containerPadding;
            set => SetProperty(ref _containerPadding, value);
        }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets whether this is the default layout
        /// </summary>
        public bool IsDefault
        {
            get => _isDefault;
            set => SetProperty(ref _isDefault, value);
        }

        /// <summary>
        /// Gets or sets whether to auto save
        /// </summary>
        public bool IsAutoSave
        {
            get => _isAutoSave;
            set => SetProperty(ref _isAutoSave, value);
        }

        /// <summary>
        /// Gets or sets the number of columns
        /// </summary>
        public int Cols
        {
            get => _cols;
            set => SetProperty(ref _cols, value);
        }

        /// <summary>
        /// Gets or sets the number of rows
        /// </summary>
        public int Rows
        {
            get => _rows;
            set => SetProperty(ref _rows, value);
        }

        /// <summary>
        /// Gets or sets the scale
        /// </summary>
        public double Scale
        {
            get => _scale;
            set => SetProperty(ref _scale, value);
        }

        /// <summary>
        /// Gets or sets whether to snap to grid
        /// </summary>
        public bool SnapToGrid
        {
            get => _snapToGrid;
            set => SetProperty(ref _snapToGrid, value);
        }

        /// <summary>
        /// Gets or sets whether to show widget borders
        /// </summary>
        public bool ShowWidgetBorders
        {
            get => _showWidgetBorders;
            set => SetProperty(ref _showWidgetBorders, value);
        }

        /// <summary>
        /// Gets or sets the widget border color
        /// </summary>
        public string WidgetBorderColor
        {
            get => _widgetBorderColor;
            set => SetProperty(ref _widgetBorderColor, value);
        }

        /// <summary>
        /// Gets or sets the widget border thickness
        /// </summary>
        public int WidgetBorderThickness
        {
            get => _widgetBorderThickness;
            set => SetProperty(ref _widgetBorderThickness, value);
        }

        /// <summary>
        /// Gets or sets the widget border radius
        /// </summary>
        public int WidgetBorderRadius
        {
            get => _widgetBorderRadius;
            set => SetProperty(ref _widgetBorderRadius, value);
        }

        /// <summary>
        /// Gets or sets the widget title bar color
        /// </summary>
        public string WidgetTitleBarColor
        {
            get => _widgetTitleBarColor;
            set => SetProperty(ref _widgetTitleBarColor, value);
        }

        /// <summary>
        /// Gets or sets the widget title text color
        /// </summary>
        public string WidgetTitleTextColor
        {
            get => _widgetTitleTextColor;
            set => SetProperty(ref _widgetTitleTextColor, value);
        }

        /// <summary>
        /// Gets or sets the widget background color
        /// </summary>
        public string WidgetBackgroundColor
        {
            get => _widgetBackgroundColor;
            set => SetProperty(ref _widgetBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow color
        /// </summary>
        public string WidgetShadowColor
        {
            get => _widgetShadowColor;
            set => SetProperty(ref _widgetShadowColor, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow opacity
        /// </summary>
        public double WidgetShadowOpacity
        {
            get => _widgetShadowOpacity;
            set => SetProperty(ref _widgetShadowOpacity, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow blur
        /// </summary>
        public int WidgetShadowBlur
        {
            get => _widgetShadowBlur;
            set => SetProperty(ref _widgetShadowBlur, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow spread
        /// </summary>
        public int WidgetShadowSpread
        {
            get => _widgetShadowSpread;
            set => SetProperty(ref _widgetShadowSpread, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow X offset
        /// </summary>
        public int WidgetShadowOffsetX
        {
            get => _widgetShadowOffsetX;
            set => SetProperty(ref _widgetShadowOffsetX, value);
        }

        /// <summary>
        /// Gets or sets the widget shadow Y offset
        /// </summary>
        public int WidgetShadowOffsetY
        {
            get => _widgetShadowOffsetY;
            set => SetProperty(ref _widgetShadowOffsetY, value);
        }

        /// <summary>
        /// Gets or sets whether to show the widget title bar
        /// </summary>
        public bool ShowWidgetTitleBar
        {
            get => _showWidgetTitleBar;
            set => SetProperty(ref _showWidgetTitleBar, value);
        }

        /// <summary>
        /// Gets or sets whether to show the widget close button
        /// </summary>
        public bool ShowWidgetCloseButton
        {
            get => _showWidgetCloseButton;
            set => SetProperty(ref _showWidgetCloseButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the widget maximize button
        /// </summary>
        public bool ShowWidgetMaximizeButton
        {
            get => _showWidgetMaximizeButton;
            set => SetProperty(ref _showWidgetMaximizeButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the widget settings button
        /// </summary>
        public bool ShowWidgetSettingsButton
        {
            get => _showWidgetSettingsButton;
            set => SetProperty(ref _showWidgetSettingsButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the widget refresh button
        /// </summary>
        public bool ShowWidgetRefreshButton
        {
            get => _showWidgetRefreshButton;
            set => SetProperty(ref _showWidgetRefreshButton, value);
        }

        /// <summary>
        /// Gets or sets the widget title bar height
        /// </summary>
        public int WidgetTitleBarHeight
        {
            get => _widgetTitleBarHeight;
            set => SetProperty(ref _widgetTitleBarHeight, value);
        }

        /// <summary>
        /// Gets or sets the widget minimum width
        /// </summary>
        public int WidgetMinWidth
        {
            get => _widgetMinWidth;
            set => SetProperty(ref _widgetMinWidth, value);
        }

        /// <summary>
        /// Gets or sets the widget minimum height
        /// </summary>
        public int WidgetMinHeight
        {
            get => _widgetMinHeight;
            set => SetProperty(ref _widgetMinHeight, value);
        }

        /// <summary>
        /// Gets or sets the widget maximum width
        /// </summary>
        public int WidgetMaxWidth
        {
            get => _widgetMaxWidth;
            set => SetProperty(ref _widgetMaxWidth, value);
        }

        /// <summary>
        /// Gets or sets the widget maximum height
        /// </summary>
        public int WidgetMaxHeight
        {
            get => _widgetMaxHeight;
            set => SetProperty(ref _widgetMaxHeight, value);
        }

        /// <summary>
        /// Gets or sets the widget text color
        /// </summary>
        public string WidgetTextColor
        {
            get => _widgetTextColor;
            set => SetProperty(ref _widgetTextColor, value);
        }

        /// <summary>
        /// Gets or sets the widget title font family
        /// </summary>
        public string WidgetTitleFontFamily
        {
            get => _widgetTitleFontFamily;
            set => SetProperty(ref _widgetTitleFontFamily, value);
        }

        /// <summary>
        /// Gets or sets the widget title font size
        /// </summary>
        public int WidgetTitleFontSize
        {
            get => _widgetTitleFontSize;
            set => SetProperty(ref _widgetTitleFontSize, value);
        }

        /// <summary>
        /// Gets or sets the widget font family
        /// </summary>
        public string WidgetFontFamily
        {
            get => _widgetFontFamily;
            set => SetProperty(ref _widgetFontFamily, value);
        }

        /// <summary>
        /// Gets or sets the widget font size
        /// </summary>
        public int WidgetFontSize
        {
            get => _widgetFontSize;
            set => SetProperty(ref _widgetFontSize, value);
        }

        /// <summary>
        /// Gets or sets whether to use compact mode
        /// </summary>
        public bool UseCompactMode
        {
            get => _useCompactMode;
            set => SetProperty(ref _useCompactMode, value);
        }

        /// <summary>
        /// Gets or sets whether to use animations
        /// </summary>
        public bool UseAnimations
        {
            get => _useAnimations;
            set => SetProperty(ref _useAnimations, value);
        }

        /// <summary>
        /// Gets or sets the animation duration
        /// </summary>
        public int AnimationDuration
        {
            get => _animationDuration;
            set => SetProperty(ref _animationDuration, value);
        }

        /// <summary>
        /// Gets or sets the animation easing
        /// </summary>
        public string AnimationEasing
        {
            get => _animationEasing;
            set => SetProperty(ref _animationEasing, value);
        }

        /// <summary>
        /// Gets or sets the default widget type
        /// </summary>
        public string WidgetDefaultType
        {
            get => _widgetDefaultType;
            set => SetProperty(ref _widgetDefaultType, value);
        }

        /// <summary>
        /// Gets or sets the default widget data source
        /// </summary>
        public string WidgetDefaultDataSource
        {
            get => _widgetDefaultDataSource;
            set => SetProperty(ref _widgetDefaultDataSource, value);
        }

        /// <summary>
        /// Gets or sets the default widget update interval
        /// </summary>
        public int WidgetDefaultUpdateInterval
        {
            get => _widgetDefaultUpdateInterval;
            set => SetProperty(ref _widgetDefaultUpdateInterval, value);
        }

        /// <summary>
        /// Gets or sets whether to auto resize
        /// </summary>
        public bool AutoResize
        {
            get => _autoResize;
            set => SetProperty(ref _autoResize, value);
        }

        /// <summary>
        /// Gets or sets whether to use responsive layout
        /// </summary>
        public bool ResponsiveLayout
        {
            get => _responsiveLayout;
            set => SetProperty(ref _responsiveLayout, value);
        }

        /// <summary>
        /// Gets or sets whether to preserve aspect ratio
        /// </summary>
        public bool PreserveAspectRatio
        {
            get => _preserveAspectRatio;
            set => SetProperty(ref _preserveAspectRatio, value);
        }
    }

    /// <summary>
    /// Represents a dashboard widget
    /// </summary>
    public class DashboardWidget : ModelBase
    {
        private string _id;
        private string _type = "Chart";
        private string _title = "Widget";
        private string _dataSource = "Router";
        private string _dataSourceId;
        private int _x;
        private int _y;
        private int _width = 4;
        private int _height = 4;
        private bool _static;
        private bool _draggable = true;
        private bool _resizable = true;
        private bool _visible = true;
        private string _backgroundColor = "#FFFFFF";
        private string _borderColor = "#E0E0E0";
        private int _borderThickness = 1;
        private int _borderRadius = 4;
        private int _zIndex;
        private int _updateInterval = 5000;
        private bool _autoRefresh = true;
        private string _chartType = "Line";
        private bool _showLegend = true;
        private bool _showDataLabels;
        private bool _showAxisLabels = true;
        private bool _showTooltips = true;
        private bool _animate = true;
        private bool _useGradient;
        private string _textColor = "#212121";
        private int _fontSize = 12;
        private string _fontFamily = "Segoe UI";
        private string _dataSeries = "CpuUsage";
        private string _dataFilters = "";
        private string _chartOptions = "";
        private bool _isMaximized;
        private bool _showTitleBar = true;
        private string _titleBarColor = "#F5F5F5";
        private string _titleTextColor = "#212121";
        private bool _showCloseButton = true;
        private bool _showMaximizeButton = true;
        private bool _showSettingsButton = true;
        private bool _showRefreshButton = true;
        private bool _customColors;
        private List<string> _colorPalette = new List<string>();
        private string _template;
        private Dictionary<string, object> _configuration = new Dictionary<string, object>();
        private DateTime _lastUpdated;
        private bool _isLoading;
        private string _errorMessage;
        private bool _hasError;
        private string _timeRange = "Last 24 Hours";
        private string _aggregation = "Average";
        private string _unit = "Automatic";
        private bool _autoScale = true;
        private double _minValue;
        private double _maxValue;
        private string _displayMode = "Normal";
        private bool _showExportButton;
        private bool _showPrintButton;
        private bool _showDownloadButton;
        private bool _allowDrillDown;
        private string _drillDownId;
        private bool _groupData;
        private string _groupBy;
        private string _sortBy;
        private string _sortDirection = "Ascending";
        private bool _showContextMenu = true;
        private bool _enableZoom;
        private bool _enablePan;
        private bool _enableSelection;
        private bool _showGridLines = true;
        private string _gridLineColor = "#E0E0E0";
        private int _gridLineThickness = 1;
        private string _tooltipBackgroundColor = "#212121";
        private string _tooltipTextColor = "#FFFFFF";
        private string _tooltipBorderColor = "#000000";
        private int _tooltipBorderThickness = 0;
        private int _tooltipBorderRadius = 4;
        private string _axisLabelColor = "#666666";
        private string _axisTitleColor = "#333333";
        private bool _showAxisTitle = true;
        private string _xAxisTitle = "X Axis";
        private string _yAxisTitle = "Y Axis";
        private bool _showAxisLines = true;
        private string _axisLineColor = "#E0E0E0";
        private int _axisLineThickness = 1;
        private bool _showAxisTicks = true;
        private string _axisTickColor = "#E0E0E0";
        private int _axisTickThickness = 1;
        private int _axisFontSize = 12;
        private string _axisFontFamily = "Segoe UI";
        private string _legendPosition = "Bottom";
        private bool _legendHorizontal = true;
        private string _legendBackgroundColor = "#FFFFFF";
        private string _legendTextColor = "#212121";
        private string _legendBorderColor = "#E0E0E0";
        private int _legendBorderThickness = 1;
        private int _legendBorderRadius = 4;
        private int _legendFontSize = 12;
        private string _legendFontFamily = "Segoe UI";
        private string _legendTitle;
        private bool _showLegendTitle;
        private bool _useCustomXAxis;
        private bool _useCustomYAxis;
        private int _xAxisMin;
        private int _xAxisMax;
        private int _yAxisMin;
        private int _yAxisMax;
        private int _xAxisStep;
        private int _yAxisStep;
        private string _xAxisFormat;
        private string _yAxisFormat;
        private bool _useRealTimeData = true;
        private bool _useHistoricalData;
        private bool _useServerTime = true;
        private bool _useCustomTime;
        private DateTime _customStartTime;
        private DateTime _customEndTime;
        private string _customTimeRange;
        private bool _useDefaultTheme = true;
        private string _themeName;
        private bool _override;
        private bool _showBorder = true;
        private bool _showShadow = true;
        private string _shadowColor = "#000000";
        private double _shadowOpacity = 0.1;
        private int _shadowBlur = 10;
        private int _shadowSpread = 0;
        private int _shadowOffsetX = 0;
        private int _shadowOffsetY = 2;
        private string _icon;
        private string _iconColor = "#212121";
        private string _badge;
        private string _badgeColor = "#1976D2";

        /// <summary>
        /// Gets or sets the widget ID
        /// </summary>
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        /// <summary>
        /// Gets or sets the widget type
        /// </summary>
        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        /// <summary>
        /// Gets or sets the widget title
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        /// <summary>
        /// Gets or sets the data source
        /// </summary>
        public string DataSource
        {
            get => _dataSource;
            set => SetProperty(ref _dataSource, value);
        }

        /// <summary>
        /// Gets or sets the data source ID
        /// </summary>
        public string DataSourceId
        {
            get => _dataSourceId;
            set => SetProperty(ref _dataSourceId, value);
        }

        /// <summary>
        /// Gets or sets the X position
        /// </summary>
        public int X
        {
            get => _x;
            set => SetProperty(ref _x, value);
        }

        /// <summary>
        /// Gets or sets the Y position
        /// </summary>
        public int Y
        {
            get => _y;
            set => SetProperty(ref _y, value);
        }

        /// <summary>
        /// Gets or sets the width
        /// </summary>
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }

        /// <summary>
        /// Gets or sets the height
        /// </summary>
        public int Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is static
        /// </summary>
        public bool Static
        {
            get => _static;
            set => SetProperty(ref _static, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is draggable
        /// </summary>
        public bool Draggable
        {
            get => _draggable;
            set => SetProperty(ref _draggable, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is resizable
        /// </summary>
        public bool Resizable
        {
            get => _resizable;
            set => SetProperty(ref _resizable, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is visible
        /// </summary>
        public bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        /// <summary>
        /// Gets or sets the background color
        /// </summary>
        public string BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the border color
        /// </summary>
        public string BorderColor
        {
            get => _borderColor;
            set => SetProperty(ref _borderColor, value);
        }

        /// <summary>
        /// Gets or sets the border thickness
        /// </summary>
        public int BorderThickness
        {
            get => _borderThickness;
            set => SetProperty(ref _borderThickness, value);
        }

        /// <summary>
        /// Gets or sets the border radius
        /// </summary>
        public int BorderRadius
        {
            get => _borderRadius;
            set => SetProperty(ref _borderRadius, value);
        }

        /// <summary>
        /// Gets or sets the Z index
        /// </summary>
        public int ZIndex
        {
            get => _zIndex;
            set => SetProperty(ref _zIndex, value);
        }

        /// <summary>
        /// Gets or sets the update interval
        /// </summary>
        public int UpdateInterval
        {
            get => _updateInterval;
            set => SetProperty(ref _updateInterval, value);
        }

        /// <summary>
        /// Gets or sets whether to auto refresh
        /// </summary>
        public bool AutoRefresh
        {
            get => _autoRefresh;
            set => SetProperty(ref _autoRefresh, value);
        }

        /// <summary>
        /// Gets or sets the chart type
        /// </summary>
        public string ChartType
        {
            get => _chartType;
            set => SetProperty(ref _chartType, value);
        }

        /// <summary>
        /// Gets or sets whether to show the legend
        /// </summary>
        public bool ShowLegend
        {
            get => _showLegend;
            set => SetProperty(ref _showLegend, value);
        }

        /// <summary>
        /// Gets or sets whether to show data labels
        /// </summary>
        public bool ShowDataLabels
        {
            get => _showDataLabels;
            set => SetProperty(ref _showDataLabels, value);
        }

        /// <summary>
        /// Gets or sets whether to show axis labels
        /// </summary>
        public bool ShowAxisLabels
        {
            get => _showAxisLabels;
            set => SetProperty(ref _showAxisLabels, value);
        }

        /// <summary>
        /// Gets or sets whether to show tooltips
        /// </summary>
        public bool ShowTooltips
        {
            get => _showTooltips;
            set => SetProperty(ref _showTooltips, value);
        }

        /// <summary>
        /// Gets or sets whether to animate
        /// </summary>
        public bool Animate
        {
            get => _animate;
            set => SetProperty(ref _animate, value);
        }

        /// <summary>
        /// Gets or sets whether to use gradient
        /// </summary>
        public bool UseGradient
        {
            get => _useGradient;
            set => SetProperty(ref _useGradient, value);
        }

        /// <summary>
        /// Gets or sets the text color
        /// </summary>
        public string TextColor
        {
            get => _textColor;
            set => SetProperty(ref _textColor, value);
        }

        /// <summary>
        /// Gets or sets the font size
        /// </summary>
        public int FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }

        /// <summary>
        /// Gets or sets the font family
        /// </summary>
        public string FontFamily
        {
            get => _fontFamily;
            set => SetProperty(ref _fontFamily, value);
        }

        /// <summary>
        /// Gets or sets the data series
        /// </summary>
        public string DataSeries
        {
            get => _dataSeries;
            set => SetProperty(ref _dataSeries, value);
        }

        /// <summary>
        /// Gets or sets the data filters
        /// </summary>
        public string DataFilters
        {
            get => _dataFilters;
            set => SetProperty(ref _dataFilters, value);
        }

        /// <summary>
        /// Gets or sets the chart options
        /// </summary>
        public string ChartOptions
        {
            get => _chartOptions;
            set => SetProperty(ref _chartOptions, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is maximized
        /// </summary>
        public bool IsMaximized
        {
            get => _isMaximized;
            set => SetProperty(ref _isMaximized, value);
        }

        /// <summary>
        /// Gets or sets whether to show the title bar
        /// </summary>
        public bool ShowTitleBar
        {
            get => _showTitleBar;
            set => SetProperty(ref _showTitleBar, value);
        }

        /// <summary>
        /// Gets or sets the title bar color
        /// </summary>
        public string TitleBarColor
        {
            get => _titleBarColor;
            set => SetProperty(ref _titleBarColor, value);
        }

        /// <summary>
        /// Gets or sets the title text color
        /// </summary>
        public string TitleTextColor
        {
            get => _titleTextColor;
            set => SetProperty(ref _titleTextColor, value);
        }

        /// <summary>
        /// Gets or sets whether to show the close button
        /// </summary>
        public bool ShowCloseButton
        {
            get => _showCloseButton;
            set => SetProperty(ref _showCloseButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the maximize button
        /// </summary>
        public bool ShowMaximizeButton
        {
            get => _showMaximizeButton;
            set => SetProperty(ref _showMaximizeButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the settings button
        /// </summary>
        public bool ShowSettingsButton
        {
            get => _showSettingsButton;
            set => SetProperty(ref _showSettingsButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the refresh button
        /// </summary>
        public bool ShowRefreshButton
        {
            get => _showRefreshButton;
            set => SetProperty(ref _showRefreshButton, value);
        }

        /// <summary>
        /// Gets or sets whether to use custom colors
        /// </summary>
        public bool CustomColors
        {
            get => _customColors;
            set => SetProperty(ref _customColors, value);
        }

        /// <summary>
        /// Gets or sets the color palette
        /// </summary>
        public List<string> ColorPalette
        {
            get => _colorPalette;
            set => SetProperty(ref _colorPalette, value);
        }

        /// <summary>
        /// Gets or sets the template
        /// </summary>
        public string Template
        {
            get => _template;
            set => SetProperty(ref _template, value);
        }

        /// <summary>
        /// Gets or sets the configuration
        /// </summary>
        public Dictionary<string, object> Configuration
        {
            get => _configuration;
            set => SetProperty(ref _configuration, value);
        }

        /// <summary>
        /// Gets or sets the last updated time
        /// </summary>
        public DateTime LastUpdated
        {
            get => _lastUpdated;
            set => SetProperty(ref _lastUpdated, value);
        }

        /// <summary>
        /// Gets or sets whether the widget is loading
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// Gets or sets the error message
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        /// <summary>
        /// Gets or sets whether the widget has an error
        /// </summary>
        public bool HasError
        {
            get => _hasError;
            set => SetProperty(ref _hasError, value);
        }

        /// <summary>
        /// Gets or sets the time range
        /// </summary>
        public string TimeRange
        {
            get => _timeRange;
            set => SetProperty(ref _timeRange, value);
        }

        /// <summary>
        /// Gets or sets the aggregation
        /// </summary>
        public string Aggregation
        {
            get => _aggregation;
            set => SetProperty(ref _aggregation, value);
        }

        /// <summary>
        /// Gets or sets the unit
        /// </summary>
        public string Unit
        {
            get => _unit;
            set => SetProperty(ref _unit, value);
        }

        /// <summary>
        /// Gets or sets whether to auto scale
        /// </summary>
        public bool AutoScale
        {
            get => _autoScale;
            set => SetProperty(ref _autoScale, value);
        }

        /// <summary>
        /// Gets or sets the minimum value
        /// </summary>
        public double MinValue
        {
            get => _minValue;
            set => SetProperty(ref _minValue, value);
        }

        /// <summary>
        /// Gets or sets the maximum value
        /// </summary>
        public double MaxValue
        {
            get => _maxValue;
            set => SetProperty(ref _maxValue, value);
        }

        /// <summary>
        /// Gets or sets the display mode
        /// </summary>
        public string DisplayMode
        {
            get => _displayMode;
            set => SetProperty(ref _displayMode, value);
        }

        /// <summary>
        /// Gets or sets whether to show the export button
        /// </summary>
        public bool ShowExportButton
        {
            get => _showExportButton;
            set => SetProperty(ref _showExportButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the print button
        /// </summary>
        public bool ShowPrintButton
        {
            get => _showPrintButton;
            set => SetProperty(ref _showPrintButton, value);
        }

        /// <summary>
        /// Gets or sets whether to show the download button
        /// </summary>
        public bool ShowDownloadButton
        {
            get => _showDownloadButton;
            set => SetProperty(ref _showDownloadButton, value);
        }

        /// <summary>
        /// Gets or sets whether to allow drill down
        /// </summary>
        public bool AllowDrillDown
        {
            get => _allowDrillDown;
            set => SetProperty(ref _allowDrillDown, value);
        }

        /// <summary>
        /// Gets or sets the drill down ID
        /// </summary>
        public string DrillDownId
        {
            get => _drillDownId;
            set => SetProperty(ref _drillDownId, value);
        }

        /// <summary>
        /// Gets or sets whether to group data
        /// </summary>
        public bool GroupData
        {
            get => _groupData;
            set => SetProperty(ref _groupData, value);
        }

        /// <summary>
        /// Gets or sets the group by
        /// </summary>
        public string GroupBy
        {
            get => _groupBy;
            set => SetProperty(ref _groupBy, value);
        }

        /// <summary>
        /// Gets or sets the sort by
        /// </summary>
        public string SortBy
        {
            get => _sortBy;
            set => SetProperty(ref _sortBy, value);
        }

        /// <summary>
        /// Gets or sets the sort direction
        /// </summary>
        public string SortDirection
        {
            get => _sortDirection;
            set => SetProperty(ref _sortDirection, value);
        }

        /// <summary>
        /// Gets or sets whether to show the context menu
        /// </summary>
        public bool ShowContextMenu
        {
            get => _showContextMenu;
            set => SetProperty(ref _showContextMenu, value);
        }

        /// <summary>
        /// Gets or sets whether to enable zoom
        /// </summary>
        public bool EnableZoom
        {
            get => _enableZoom;
            set => SetProperty(ref _enableZoom, value);
        }

        /// <summary>
        /// Gets or sets whether to enable pan
        /// </summary>
        public bool EnablePan
        {
            get => _enablePan;
            set => SetProperty(ref _enablePan, value);
        }

        /// <summary>
        /// Gets or sets whether to enable selection
        /// </summary>
        public bool EnableSelection
        {
            get => _enableSelection;
            set => SetProperty(ref _enableSelection, value);
        }

        /// <summary>
        /// Gets or sets whether to show grid lines
        /// </summary>
        public bool ShowGridLines
        {
            get => _showGridLines;
            set => SetProperty(ref _showGridLines, value);
        }

        /// <summary>
        /// Gets or sets the grid line color
        /// </summary>
        public string GridLineColor
        {
            get => _gridLineColor;
            set => SetProperty(ref _gridLineColor, value);
        }

        /// <summary>
        /// Gets or sets the grid line thickness
        /// </summary>
        public int GridLineThickness
        {
            get => _gridLineThickness;
            set => SetProperty(ref _gridLineThickness, value);
        }

        /// <summary>
        /// Gets or sets the tooltip background color
        /// </summary>
        public string TooltipBackgroundColor
        {
            get => _tooltipBackgroundColor;
            set => SetProperty(ref _tooltipBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the tooltip text color
        /// </summary>
        public string TooltipTextColor
        {
            get => _tooltipTextColor;
            set => SetProperty(ref _tooltipTextColor, value);
        }

        /// <summary>
        /// Gets or sets the tooltip border color
        /// </summary>
        public string TooltipBorderColor
        {
            get => _tooltipBorderColor;
            set => SetProperty(ref _tooltipBorderColor, value);
        }

        /// <summary>
        /// Gets or sets the tooltip border thickness
        /// </summary>
        public int TooltipBorderThickness
        {
            get => _tooltipBorderThickness;
            set => SetProperty(ref _tooltipBorderThickness, value);
        }

        /// <summary>
        /// Gets or sets the tooltip border radius
        /// </summary>
        public int TooltipBorderRadius
        {
            get => _tooltipBorderRadius;
            set => SetProperty(ref _tooltipBorderRadius, value);
        }

        /// <summary>
        /// Gets or sets the axis label color
        /// </summary>
        public string AxisLabelColor
        {
            get => _axisLabelColor;
            set => SetProperty(ref _axisLabelColor, value);
        }

        /// <summary>
        /// Gets or sets the axis title color
        /// </summary>
        public string AxisTitleColor
        {
            get => _axisTitleColor;
            set => SetProperty(ref _axisTitleColor, value);
        }

        /// <summary>
        /// Gets or sets whether to show the axis title
        /// </summary>
        public bool ShowAxisTitle
        {
            get => _showAxisTitle;
            set => SetProperty(ref _showAxisTitle, value);
        }

        /// <summary>
        /// Gets or sets the X axis title
        /// </summary>
        public string XAxisTitle
        {
            get => _xAxisTitle;
            set => SetProperty(ref _xAxisTitle, value);
        }

        /// <summary>
        /// Gets or sets the Y axis title
        /// </summary>
        public string YAxisTitle
        {
            get => _yAxisTitle;
            set => SetProperty(ref _yAxisTitle, value);
        }

        /// <summary>
        /// Gets or sets whether to show axis lines
        /// </summary>
        public bool ShowAxisLines
        {
            get => _showAxisLines;
            set => SetProperty(ref _showAxisLines, value);
        }

        /// <summary>
        /// Gets or sets the axis line color
        /// </summary>
        public string AxisLineColor
        {
            get => _axisLineColor;
            set => SetProperty(ref _axisLineColor, value);
        }

        /// <summary>
        /// Gets or sets the axis line thickness
        /// </summary>
        public int AxisLineThickness
        {
            get => _axisLineThickness;
            set => SetProperty(ref _axisLineThickness, value);
        }

        /// <summary>
        /// Gets or sets whether to show axis ticks
        /// </summary>
        public bool ShowAxisTicks
        {
            get => _showAxisTicks;
            set => SetProperty(ref _showAxisTicks, value);
        }

        /// <summary>
        /// Gets or sets the axis tick color
        /// </summary>
        public string AxisTickColor
        {
            get => _axisTickColor;
            set => SetProperty(ref _axisTickColor, value);
        }

        /// <summary>
        /// Gets or sets the axis tick thickness
        /// </summary>
        public int AxisTickThickness
        {
            get => _axisTickThickness;
            set => SetProperty(ref _axisTickThickness, value);
        }

        /// <summary>
        /// Gets or sets the axis font size
        /// </summary>
        public int AxisFontSize
        {
            get => _axisFontSize;
            set => SetProperty(ref _axisFontSize, value);
        }

        /// <summary>
        /// Gets or sets the axis font family
        /// </summary>
        public string AxisFontFamily
        {
            get => _axisFontFamily;
            set => SetProperty(ref _axisFontFamily, value);
        }

        /// <summary>
        /// Gets or sets the legend position
        /// </summary>
        public string LegendPosition
        {
            get => _legendPosition;
            set => SetProperty(ref _legendPosition, value);
        }

        /// <summary>
        /// Gets or sets whether the legend is horizontal
        /// </summary>
        public bool LegendHorizontal
        {
            get => _legendHorizontal;
            set => SetProperty(ref _legendHorizontal, value);
        }

        /// <summary>
        /// Gets or sets the legend background color
        /// </summary>
        public string LegendBackgroundColor
        {
            get => _legendBackgroundColor;
            set => SetProperty(ref _legendBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the legend text color
        /// </summary>
        public string LegendTextColor
        {
            get => _legendTextColor;
            set => SetProperty(ref _legendTextColor, value);
        }

        /// <summary>
        /// Gets or sets the legend border color
        /// </summary>
        public string LegendBorderColor
        {
            get => _legendBorderColor;
            set => SetProperty(ref _legendBorderColor, value);
        }

        /// <summary>
        /// Gets or sets the legend border thickness
        /// </summary>
        public int LegendBorderThickness
        {
            get => _legendBorderThickness;
            set => SetProperty(ref _legendBorderThickness, value);
        }

        /// <summary>
        /// Gets or sets the legend border radius
        /// </summary>
        public int LegendBorderRadius
        {
            get => _legendBorderRadius;
            set => SetProperty(ref _legendBorderRadius, value);
        }

        /// <summary>
        /// Gets or sets the legend font size
        /// </summary>
        public int LegendFontSize
        {
            get => _legendFontSize;
            set => SetProperty(ref _legendFontSize, value);
        }

        /// <summary>
        /// Gets or sets the legend font family
        /// </summary>
        public string LegendFontFamily
        {
            get => _legendFontFamily;
            set => SetProperty(ref _legendFontFamily, value);
        }

        /// <summary>
        /// Gets or sets the legend title
        /// </summary>
        public string LegendTitle
        {
            get => _legendTitle;
            set => SetProperty(ref _legendTitle, value);
        }

        /// <summary>
        /// Gets or sets whether to show the legend title
        /// </summary>
        public bool ShowLegendTitle
        {
            get => _showLegendTitle;
            set => SetProperty(ref _showLegendTitle, value);
        }

        /// <summary>
        /// Gets or sets whether to use a custom X axis
        /// </summary>
        public bool UseCustomXAxis
        {
            get => _useCustomXAxis;
            set => SetProperty(ref _useCustomXAxis, value);
        }

        /// <summary>
        /// Gets or sets whether to use a custom Y axis
        /// </summary>
        public bool UseCustomYAxis
        {
            get => _useCustomYAxis;
            set => SetProperty(ref _useCustomYAxis, value);
        }

        /// <summary>
        /// Gets or sets the X axis minimum
        /// </summary>
        public int XAxisMin
        {
            get => _xAxisMin;
            set => SetProperty(ref _xAxisMin, value);
        }

        /// <summary>
        /// Gets or sets the X axis maximum
        /// </summary>
        public int XAxisMax
        {
            get => _xAxisMax;
            set => SetProperty(ref _xAxisMax, value);
        }

        /// <summary>
        /// Gets or sets the Y axis minimum
        /// </summary>
        public int YAxisMin
        {
            get => _yAxisMin;
            set => SetProperty(ref _yAxisMin, value);
        }

        /// <summary>
        /// Gets or sets the Y axis maximum
        /// </summary>
        public int YAxisMax
        {
            get => _yAxisMax;
            set => SetProperty(ref _yAxisMax, value);
        }

        /// <summary>
        /// Gets or sets the X axis step
        /// </summary>
        public int XAxisStep
        {
            get => _xAxisStep;
            set => SetProperty(ref _xAxisStep, value);
        }

        /// <summary>
        /// Gets or sets the Y axis step
        /// </summary>
        public int YAxisStep
        {
            get => _yAxisStep;
            set => SetProperty(ref _yAxisStep, value);
        }

        /// <summary>
        /// Gets or sets the X axis format
        /// </summary>
        public string XAxisFormat
        {
            get => _xAxisFormat;
            set => SetProperty(ref _xAxisFormat, value);
        }

        /// <summary>
        /// Gets or sets the Y axis format
        /// </summary>
        public string YAxisFormat
        {
            get => _yAxisFormat;
            set => SetProperty(ref _yAxisFormat, value);
        }

        /// <summary>
        /// Gets or sets whether to use real-time data
        /// </summary>
        public bool UseRealTimeData
        {
            get => _useRealTimeData;
            set => SetProperty(ref _useRealTimeData, value);
        }

        /// <summary>
        /// Gets or sets whether to use historical data
        /// </summary>
        public bool UseHistoricalData
        {
            get => _useHistoricalData;
            set => SetProperty(ref _useHistoricalData, value);
        }

        /// <summary>
        /// Gets or sets whether to use server time
        /// </summary>
        public bool UseServerTime
        {
            get => _useServerTime;
            set => SetProperty(ref _useServerTime, value);
        }

        /// <summary>
        /// Gets or sets whether to use custom time
        /// </summary>
        public bool UseCustomTime
        {
            get => _useCustomTime;
            set => SetProperty(ref _useCustomTime, value);
        }

        /// <summary>
        /// Gets or sets the custom start time
        /// </summary>
        public DateTime CustomStartTime
        {
            get => _customStartTime;
            set => SetProperty(ref _customStartTime, value);
        }

        /// <summary>
        /// Gets or sets the custom end time
        /// </summary>
        public DateTime CustomEndTime
        {
            get => _customEndTime;
            set => SetProperty(ref _customEndTime, value);
        }

        /// <summary>
        /// Gets or sets the custom time range
        /// </summary>
        public string CustomTimeRange
        {
            get => _customTimeRange;
            set => SetProperty(ref _customTimeRange, value);
        }

        /// <summary>
        /// Gets or sets whether to use the default theme
        /// </summary>
        public bool UseDefaultTheme
        {
            get => _useDefaultTheme;
            set => SetProperty(ref _useDefaultTheme, value);
        }

        /// <summary>
        /// Gets or sets the theme name
        /// </summary>
        public string ThemeName
        {
            get => _themeName;
            set => SetProperty(ref _themeName, value);
        }

        /// <summary>
        /// Gets or sets whether to override the theme
        /// </summary>
        public bool Override
        {
            get => _override;
            set => SetProperty(ref _override, value);
        }

        /// <summary>
        /// Gets or sets whether to show the border
        /// </summary>
        public bool ShowBorder
        {
            get => _showBorder;
            set => SetProperty(ref _showBorder, value);
        }

        /// <summary>
        /// Gets or sets whether to show the shadow
        /// </summary>
        public bool ShowShadow
        {
            get => _showShadow;
            set => SetProperty(ref _showShadow, value);
        }

        /// <summary>
        /// Gets or sets the shadow color
        /// </summary>
        public string ShadowColor
        {
            get => _shadowColor;
            set => SetProperty(ref _shadowColor, value);
        }

        /// <summary>
        /// Gets or sets the shadow opacity
        /// </summary>
        public double ShadowOpacity
        {
            get => _shadowOpacity;
            set => SetProperty(ref _shadowOpacity, value);
        }

        /// <summary>
        /// Gets or sets the shadow blur
        /// </summary>
        public int ShadowBlur
        {
            get => _shadowBlur;
            set => SetProperty(ref _shadowBlur, value);
        }

        /// <summary>
        /// Gets or sets the shadow spread
        /// </summary>
        public int ShadowSpread
        {
            get => _shadowSpread;
            set => SetProperty(ref _shadowSpread, value);
        }

        /// <summary>
        /// Gets or sets the shadow X offset
        /// </summary>
        public int ShadowOffsetX
        {
            get => _shadowOffsetX;
            set => SetProperty(ref _shadowOffsetX, value);
        }

        /// <summary>
        /// Gets or sets the shadow Y offset
        /// </summary>
        public int ShadowOffsetY
        {
            get => _shadowOffsetY;
            set => SetProperty(ref _shadowOffsetY, value);
        }

        /// <summary>
        /// Gets or sets the icon
        /// </summary>
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        /// <summary>
        /// Gets or sets the icon color
        /// </summary>
        public string IconColor
        {
            get => _iconColor;
            set => SetProperty(ref _iconColor, value);
        }

        /// <summary>
        /// Gets or sets the badge
        /// </summary>
        public string Badge
        {
            get => _badge;
            set => SetProperty(ref _badge, value);
        }

        /// <summary>
        /// Gets or sets the badge color
        /// </summary>
        public string BadgeColor
        {
            get => _badgeColor;
            set => SetProperty(ref _badgeColor, value);
        }

        /// <summary>
        /// Initializes a new instance of the DashboardWidget class
        /// </summary>
        public DashboardWidget()
        {
            Id = Guid.NewGuid().ToString();
            LastUpdated = DateTime.Now;
            CustomStartTime = DateTime.Now.AddDays(-1);
            CustomEndTime = DateTime.Now;
        }
    }
}