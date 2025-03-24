using System;

namespace MikroTikMonitor.Models
{
    /// <summary>
    /// Represents a custom theme
    /// </summary>
    public class CustomTheme : ModelBase
    {
        private string _name;
        private string _primaryColor = "#1976D2";
        private string _secondaryColor = "#FF5722";
        private string _backgroundColor = "#FFFFFF";
        private string _surfaceColor = "#F5F5F5";
        private string _errorColor = "#B00020";
        private string _textPrimaryColor = "#212121";
        private string _textSecondaryColor = "#757575";
        private string _chartPrimaryColor = "#2196F3";
        private string _chartSecondaryColor = "#FFC107";
        private string _chartTertiaryColor = "#4CAF50";
        private string _chartQuaternaryColor = "#9C27B0";
        private string _chartQuinaryColor = "#F44336";
        private string _borderColor = "#E0E0E0";
        private string _shadowColor = "#000000";
        private double _shadowOpacity = 0.1;
        private bool _isDark;
        private bool _isSystem;
        private bool _useMaterialDesign = true;
        private int _cornerRadius = 4;
        private string _fontFamily = "Segoe UI";
        private int _fontSize = 14;
        private string _buttonPrimaryColor = "#1976D2";
        private string _buttonSecondaryColor = "#FF5722";
        private string _buttonTextColor = "#FFFFFF";
        private string _menuBackgroundColor = "#FFFFFF";
        private string _menuTextColor = "#212121";
        private string _tabBackgroundColor = "#FFFFFF";
        private string _tabTextColor = "#212121";
        private string _tabSelectedColor = "#1976D2";
        private string _tabSelectedTextColor = "#FFFFFF";
        private string _gridHeaderBackgroundColor = "#F5F5F5";
        private string _gridHeaderTextColor = "#212121";
        private string _gridBackgroundColor = "#FFFFFF";
        private string _gridTextColor = "#212121";
        private string _gridAlternateRowColor = "#F9F9F9";
        private string _gridBorderColor = "#E0E0E0";
        private string _tooltipBackgroundColor = "#212121";
        private string _tooltipTextColor = "#FFFFFF";
        private string _dialogBackgroundColor = "#FFFFFF";
        private string _dialogTextColor = "#212121";
        private string _inputBackgroundColor = "#FFFFFF";
        private string _inputTextColor = "#212121";
        private string _inputBorderColor = "#E0E0E0";
        private string _inputFocusColor = "#1976D2";
        
        /// <summary>
        /// Gets or sets the name of the theme
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Gets or sets the primary color
        /// </summary>
        public string PrimaryColor
        {
            get => _primaryColor;
            set => SetProperty(ref _primaryColor, value);
        }

        /// <summary>
        /// Gets or sets the secondary color
        /// </summary>
        public string SecondaryColor
        {
            get => _secondaryColor;
            set => SetProperty(ref _secondaryColor, value);
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
        /// Gets or sets the surface color
        /// </summary>
        public string SurfaceColor
        {
            get => _surfaceColor;
            set => SetProperty(ref _surfaceColor, value);
        }

        /// <summary>
        /// Gets or sets the error color
        /// </summary>
        public string ErrorColor
        {
            get => _errorColor;
            set => SetProperty(ref _errorColor, value);
        }

        /// <summary>
        /// Gets or sets the primary text color
        /// </summary>
        public string TextPrimaryColor
        {
            get => _textPrimaryColor;
            set => SetProperty(ref _textPrimaryColor, value);
        }

        /// <summary>
        /// Gets or sets the secondary text color
        /// </summary>
        public string TextSecondaryColor
        {
            get => _textSecondaryColor;
            set => SetProperty(ref _textSecondaryColor, value);
        }

        /// <summary>
        /// Gets or sets the primary chart color
        /// </summary>
        public string ChartPrimaryColor
        {
            get => _chartPrimaryColor;
            set => SetProperty(ref _chartPrimaryColor, value);
        }

        /// <summary>
        /// Gets or sets the secondary chart color
        /// </summary>
        public string ChartSecondaryColor
        {
            get => _chartSecondaryColor;
            set => SetProperty(ref _chartSecondaryColor, value);
        }

        /// <summary>
        /// Gets or sets the tertiary chart color
        /// </summary>
        public string ChartTertiaryColor
        {
            get => _chartTertiaryColor;
            set => SetProperty(ref _chartTertiaryColor, value);
        }

        /// <summary>
        /// Gets or sets the quaternary chart color
        /// </summary>
        public string ChartQuaternaryColor
        {
            get => _chartQuaternaryColor;
            set => SetProperty(ref _chartQuaternaryColor, value);
        }

        /// <summary>
        /// Gets or sets the quinary chart color
        /// </summary>
        public string ChartQuinaryColor
        {
            get => _chartQuinaryColor;
            set => SetProperty(ref _chartQuinaryColor, value);
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
        /// Gets or sets whether the theme is dark
        /// </summary>
        public bool IsDark
        {
            get => _isDark;
            set => SetProperty(ref _isDark, value);
        }

        /// <summary>
        /// Gets or sets whether the theme is a system theme
        /// </summary>
        public bool IsSystem
        {
            get => _isSystem;
            set => SetProperty(ref _isSystem, value);
        }

        /// <summary>
        /// Gets or sets whether to use Material Design
        /// </summary>
        public bool UseMaterialDesign
        {
            get => _useMaterialDesign;
            set => SetProperty(ref _useMaterialDesign, value);
        }

        /// <summary>
        /// Gets or sets the corner radius
        /// </summary>
        public int CornerRadius
        {
            get => _cornerRadius;
            set => SetProperty(ref _cornerRadius, value);
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
        /// Gets or sets the font size
        /// </summary>
        public int FontSize
        {
            get => _fontSize;
            set => SetProperty(ref _fontSize, value);
        }

        /// <summary>
        /// Gets or sets the primary button color
        /// </summary>
        public string ButtonPrimaryColor
        {
            get => _buttonPrimaryColor;
            set => SetProperty(ref _buttonPrimaryColor, value);
        }

        /// <summary>
        /// Gets or sets the secondary button color
        /// </summary>
        public string ButtonSecondaryColor
        {
            get => _buttonSecondaryColor;
            set => SetProperty(ref _buttonSecondaryColor, value);
        }

        /// <summary>
        /// Gets or sets the button text color
        /// </summary>
        public string ButtonTextColor
        {
            get => _buttonTextColor;
            set => SetProperty(ref _buttonTextColor, value);
        }

        /// <summary>
        /// Gets or sets the menu background color
        /// </summary>
        public string MenuBackgroundColor
        {
            get => _menuBackgroundColor;
            set => SetProperty(ref _menuBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the menu text color
        /// </summary>
        public string MenuTextColor
        {
            get => _menuTextColor;
            set => SetProperty(ref _menuTextColor, value);
        }

        /// <summary>
        /// Gets or sets the tab background color
        /// </summary>
        public string TabBackgroundColor
        {
            get => _tabBackgroundColor;
            set => SetProperty(ref _tabBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the tab text color
        /// </summary>
        public string TabTextColor
        {
            get => _tabTextColor;
            set => SetProperty(ref _tabTextColor, value);
        }

        /// <summary>
        /// Gets or sets the selected tab color
        /// </summary>
        public string TabSelectedColor
        {
            get => _tabSelectedColor;
            set => SetProperty(ref _tabSelectedColor, value);
        }

        /// <summary>
        /// Gets or sets the selected tab text color
        /// </summary>
        public string TabSelectedTextColor
        {
            get => _tabSelectedTextColor;
            set => SetProperty(ref _tabSelectedTextColor, value);
        }

        /// <summary>
        /// Gets or sets the grid header background color
        /// </summary>
        public string GridHeaderBackgroundColor
        {
            get => _gridHeaderBackgroundColor;
            set => SetProperty(ref _gridHeaderBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the grid header text color
        /// </summary>
        public string GridHeaderTextColor
        {
            get => _gridHeaderTextColor;
            set => SetProperty(ref _gridHeaderTextColor, value);
        }

        /// <summary>
        /// Gets or sets the grid background color
        /// </summary>
        public string GridBackgroundColor
        {
            get => _gridBackgroundColor;
            set => SetProperty(ref _gridBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the grid text color
        /// </summary>
        public string GridTextColor
        {
            get => _gridTextColor;
            set => SetProperty(ref _gridTextColor, value);
        }

        /// <summary>
        /// Gets or sets the grid alternate row color
        /// </summary>
        public string GridAlternateRowColor
        {
            get => _gridAlternateRowColor;
            set => SetProperty(ref _gridAlternateRowColor, value);
        }

        /// <summary>
        /// Gets or sets the grid border color
        /// </summary>
        public string GridBorderColor
        {
            get => _gridBorderColor;
            set => SetProperty(ref _gridBorderColor, value);
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
        /// Gets or sets the dialog background color
        /// </summary>
        public string DialogBackgroundColor
        {
            get => _dialogBackgroundColor;
            set => SetProperty(ref _dialogBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the dialog text color
        /// </summary>
        public string DialogTextColor
        {
            get => _dialogTextColor;
            set => SetProperty(ref _dialogTextColor, value);
        }

        /// <summary>
        /// Gets or sets the input background color
        /// </summary>
        public string InputBackgroundColor
        {
            get => _inputBackgroundColor;
            set => SetProperty(ref _inputBackgroundColor, value);
        }

        /// <summary>
        /// Gets or sets the input text color
        /// </summary>
        public string InputTextColor
        {
            get => _inputTextColor;
            set => SetProperty(ref _inputTextColor, value);
        }

        /// <summary>
        /// Gets or sets the input border color
        /// </summary>
        public string InputBorderColor
        {
            get => _inputBorderColor;
            set => SetProperty(ref _inputBorderColor, value);
        }

        /// <summary>
        /// Gets or sets the input focus color
        /// </summary>
        public string InputFocusColor
        {
            get => _inputFocusColor;
            set => SetProperty(ref _inputFocusColor, value);
        }
    }
}