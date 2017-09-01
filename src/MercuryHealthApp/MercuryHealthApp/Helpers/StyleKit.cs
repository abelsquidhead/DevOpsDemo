using System;
using Xamarin.Forms;

namespace MercuryHealthApp.Helpers
{
    /// <summary>
    /// Class to represent the static styles that govern the application.  The styles defined here are based in the brand color, brand accent color
    /// and the light and dark brand colors.  The fonts and text sizes of the application will be governed by the fonts set in this class, there is a regular font, medium font, and light font for use.  
    /// The fonts are  platform dependent to provide device specific fonts for the application.  
    /// All text will be either black or white with the applied alpha for the brand color.
    /// </summary>
    public partial class StyleKit
    {
        #region Constants
        /// <summary>
        /// The Alpha transparency for primary text on a light background
        /// </summary>
        private static double PrimaryLightAlpha = .87;

        /// <summary>
        /// The Alpha transparency for secondary text on a light background
        /// </summary>
        private static double SecondaryLightAlpha = .54;

        /// <summary>
        /// The Alpha transparency for disabled text on a light background
        /// </summary>
        private static double DisabledLightAlpha = .38;

        /// <summary>
        /// The Alpha transparency for dividers on a light background
        /// </summary>
        private static double DividerLightAlpha = .12;

        /// <summary>
        /// The Alpha transparency for primary text on a dark background
        /// </summary>
        private static double PrimaryDarkAlpha = 0;

        /// <summary>
        /// The Alpha transparency for secondary text on a dark background
        /// </summary>
        private static double SecondaryDarkAlpha = .70;

        /// <summary>
        /// The Alpha transparency for disabled text on a dark background
        /// </summary>
        private static double DisabledDarkAlpha = .50;

        /// <summary>
        /// The Alpha transparency for dividers on a dark background
        /// </summary>
        private static double DividerDarkAlpha = .12;
        #endregion

        #region Colors
        #region Brand Colors
        /// <summary>
        /// Brand Color. Used by the navigation bar and buttons as well as Title text.
        /// </summary>
        public static Color BrandColor = Color.FromRgb(255, 80, 0);

        /// <summary>
        /// Light version of the Brand Color 
        /// </summary>
        public static Color BrandColorLight = Color.FromRgb(255, 120, 59);

        /// <summary>
        /// Dark version of the Brand Color 
        /// </summary>
        public static Color BrandColorDark = Color.FromRgb(218, 67, 0);

        /// <summary>
        /// Brand Accent color.  Used to highlight UI items
        /// </summary>
        public static Color BrandAccentColor = Color.FromRgb(64, 64, 64);

        /// <summary>
        /// Facebook Color
        /// </summary>
        public static Color FacebookBlue = Color.FromRgb(59, 89, 152);

        /// <summary>
        /// Google Color
        /// </summary>
        public static Color GoogleRed = Color.FromRgb(244, 67, 54);

        /// <summary>
        /// Twitter Color
        /// </summary>
        public static Color TwitterBlue = Color.FromRgb(85, 172, 238);

        #endregion

        public static Color PrimaryTextColorOnLight = Color.Black.MultiplyAlpha(PrimaryLightAlpha);

        public static Color SecondaryTextColorOnLight = Color.Black.MultiplyAlpha(SecondaryLightAlpha);

        public static Color DisabledTextColorOnLight = Color.Black.MultiplyAlpha(DisabledLightAlpha);

        public static Color DividerOnLight = Color.Black.MultiplyAlpha(DividerLightAlpha);

        public static Color PrimaryTextColorOnDark = Color.White.MultiplyAlpha(PrimaryDarkAlpha);

        public static Color SecondaryTextColorOnDark = Color.White.MultiplyAlpha(SecondaryDarkAlpha);

        public static Color DisabledTextColorOnDark = Color.White.MultiplyAlpha(DisabledDarkAlpha);

        public static Color DividerOnDark = Color.White.MultiplyAlpha(DividerDarkAlpha);
        #endregion

        #region Fonts/Typography

        #region Font Family
        public static string RegularFontFamily = Device.OnPlatform(iOS: "HelveticaNeue", Android: "sans-serif", WinPhone: "Segoe UI");
        public static string MediumFontFamily = Device.OnPlatform(iOS: "HelveticaNeue-Medium", Android: "sans-serif-medium", WinPhone: "Segoe UI");
        public static string LightFontFamily = Device.OnPlatform(iOS: "HelveticaNeue-Light", Android: "sans-serif-light", WinPhone: "Segoe UI Light");
        #endregion

        #region Fonts
        public static Font ButtonFont = Font.OfSize(MediumFontFamily, 14);

        public static Font CaptionFont
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 12);
            }
        }
        public static Font BodyFont
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 14);
            }
        }
        public static Font Body2Font
        {
            get
            {
                return Font.OfSize(MediumFontFamily, 14);
            }
        }
        public static Font SubheadFont
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 16);
            }
        }
        public static Font TitleFont
        {
            get
            {
                return Font.OfSize(MediumFontFamily, 20);
            }
        }
        public static Font HeadlineFont
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 24);
            }
        }
        public static Font Display1Font
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 34);
            }
        }
        public static Font Display2Font
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 45);
            }
        }
        public static Font Display3Font
        {
            get
            {
                return Font.OfSize(RegularFontFamily, 56);
            }
        }
        public static Font Display4Font
        {
            get
            {
                return Font.OfSize(LightFontFamily, 112);
            }
        }
        #endregion
        #endregion

        #region Styles
        #region Labels
        public static Style LabelStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property =Label.TextColorProperty, Value = PrimaryTextColorOnLight },
                        new Setter { Property =  Label.FontProperty, Value= BodyFont }
                    }
                };
            }
        }
        public static Style LabelTitleStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property =Label.TextColorProperty, Value = PrimaryTextColorOnLight },
                        new Setter { Property =  Label.FontProperty, Value= TitleFont }
                    }
                };
            }
        }
        public static Style LabelSubheadStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property =Label.TextColorProperty, Value = SecondaryTextColorOnLight },
                        new Setter { Property =  Label.FontProperty, Value= SubheadFont }
                    }
                };
            }
        }

        public static Style LabelNumberStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property=Label.BackgroundColorProperty, Value=BrandColor },
                        new Setter {Property =Label.TextColorProperty, Value = Color.White },
                        new Setter { Property =  Label.FontProperty, Value= Display2Font }
                    }
                };
            }
        }

        public static Style LabelBonusNumberStyle
        {
            get
            {
                return new Style(typeof(Label))
                {
                    Setters = {
                        new Setter {Property=Label.BackgroundColorProperty, Value=BrandAccentColor },
                        new Setter {Property =Label.TextColorProperty, Value = Color.White },
                        new Setter { Property =  Label.FontProperty, Value= Display2Font }
                    }
                };
            }
        }
        #endregion

        #region Buttons
        public static Style ButtonStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.TextColorProperty, Value = Color.White },
                        new Setter {Property = Button.FontProperty, Value= ButtonFont },
                        new Setter {Property = VisualElement.BackgroundColorProperty, Value = BrandColorLight }                        
                    }
                };
            }
        }
        public static Style ButtonGoogleStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.TextColorProperty, Value = Color.White },
                        new Setter {Property = Button.FontProperty, Value= ButtonFont },
                        new Setter {Property = VisualElement.BackgroundColorProperty, Value = GoogleRed }
                    }
                };
            }
        }
        public static Style ButtonFacebookStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.TextColorProperty, Value = Color.White },
                        new Setter {Property = Button.FontProperty, Value= ButtonFont },
                        new Setter {Property = VisualElement.BackgroundColorProperty, Value = FacebookBlue }
                    }
                };
            }
        }

        public static Style ButtonTwitterStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.TextColorProperty, Value = Color.White },
                        new Setter {Property = Button.FontProperty, Value= ButtonFont },
                        new Setter {Property = VisualElement.BackgroundColorProperty, Value = TwitterBlue }
                    }
                };
            }
        }

        public static Style ButtonDisabledStyle
        {
            get
            {
                return new Style(typeof(Button))
                {
                    Setters = {
                        new Setter {Property = Button.TextColorProperty, Value = DisabledTextColorOnLight },
                        new Setter {Property = Button.FontProperty, Value= ButtonFont },
                        new Setter {Property = VisualElement.BackgroundColorProperty, Value = BrandAccentColor  }
                    }
                };
            }
        }
        #endregion

        #region List/Cell Styles
        public static Style ListViewStyle
        {
            get
            {
                return new Style(typeof(ListView))
                {
                    Setters = {
                        new Setter {Property = ListView.SeparatorColorProperty, Value = DividerOnDark},
                        new Setter {Property = ListView.SeparatorVisibilityProperty, Value = true },
                    }
                    
                };
            }
        }

        public static Style TextCellStyle
        {
            get
            {
                return new Style(typeof(TextCell))
                {
                    Setters = {                        
                        new Setter {Property = TextCell.TextColorProperty, Value = PrimaryTextColorOnLight},
                        new Setter {Property = TextCell.DetailColorProperty, Value = SecondaryTextColorOnLight},
                    }
                };
            }
        }

        public static Style ImageCellStyle
        {
            get
            {
                return new Style(typeof(ImageCell))
                {
                    Setters = {
                        new Setter {Property = TextCell.TextColorProperty, Value = PrimaryTextColorOnLight},
                        new Setter {Property = TextCell.DetailColorProperty, Value = SecondaryTextColorOnLight},
                    }
                };
            }
        }
        #endregion

        #region Page Styles
        public static Style PageStyle
        {
            get
            {
                return new Style(typeof(Page))
                {
                    Setters = {
                        new Setter {Property = Page.PaddingProperty, Value = new Thickness(10, Device.OnPlatform(20, 0, 0),10,5)}
                        
                    }
                };
            }
        }

        public static Style NavigationPageStyle
        {
            get
            {
                return new Style(typeof(NavigationPage))
                {
                    Setters =
                    {
                        new Setter {Property = NavigationPage.BarBackgroundColorProperty, Value = BrandColor },
                        new Setter {Property = NavigationPage.BarTextColorProperty, Value = Color.White}, //TODO: figure out the colors....
                        new Setter {Property = Page.PaddingProperty, Value = new Thickness(10, Device.OnPlatform(20, 0, 0),10,5)}
                    }
                };
            }
        }

        //public static Style TabPageStyle
        //{
        //    get
        //    {
        //        return new Style(typeof(TabbedPage))
        //        {
        //            Setters =
        //            {
        //                new Setter {Property = TabbedPage., Value = BrandColor },
        //                new Setter {Property = NavigationPage.BarTextColorProperty, Value = PrimaryTextColorOnLight},
        //                new Setter {Property = Page.PaddingProperty, Value = new Thickness(10, Device.OnPlatform(20, 0, 0),10,5)}
        //            }
        //        };
        //    }
        //}

        #endregion

        public static void ApplyStyles(Application app)
        {
            app.Resources = new ResourceDictionary();
            app.Resources.Add(PageStyle);
            app.Resources.Add(NavigationPageStyle);

            app.Resources.Add(LabelStyle);
            app.Resources.Add("SubheadLabel", LabelSubheadStyle);
            app.Resources.Add("TitleLabel", LabelTitleStyle);
            app.Resources.Add("NumberLabel", LabelNumberStyle); //TODO: Remove in the Library
            app.Resources.Add("BonusNumberLabel", LabelBonusNumberStyle); //TODO: Remove in the Library

            app.Resources.Add(ButtonStyle);
            app.Resources.Add("DisabledButton", ButtonDisabledStyle);
            app.Resources.Add("FacebookButton", ButtonFacebookStyle);
            app.Resources.Add("GoogleButton", ButtonGoogleStyle);
            app.Resources.Add("TwitterButton", ButtonTwitterStyle);

            app.Resources.Add(ListViewStyle);
            app.Resources.Add(TextCellStyle);
            app.Resources.Add(ImageCellStyle);
           
            app.Resources.Add("BrandColor", BrandColor);
            app.Resources.Add("BrandColorLight", BrandColorLight);
            app.Resources.Add("BrandColorDark", BrandColorDark);
            app.Resources.Add("BrandAccentColor", BrandAccentColor);
            app.Resources.Add("FacebookBlue", FacebookBlue);
            app.Resources.Add("GoogleRed", GoogleRed);
            app.Resources.Add("TwitterBlue", TwitterBlue);

            app.Resources.Add("PrimaryTextColorOnLight", PrimaryTextColorOnLight);
            app.Resources.Add("SecondaryTextColorOnLight", SecondaryTextColorOnLight);
            app.Resources.Add("DisabledTextColorOnLight", DisabledTextColorOnLight);
            app.Resources.Add("DividerOnLight", DividerOnLight);
            app.Resources.Add("PrimaryTextColorOnDark", PrimaryTextColorOnDark);
            app.Resources.Add("SecondaryTextColorOnDark", SecondaryTextColorOnDark);
            app.Resources.Add("DisabledTextColorOnDark", DisabledTextColorOnDark);
            app.Resources.Add("DividerOnDark", DividerOnDark);

            app.Resources.Add("RegularFontFamily", RegularFontFamily);
            app.Resources.Add("MediumFontFamily", MediumFontFamily);
            app.Resources.Add("LightFontFamily", LightFontFamily);

            app.Resources.Add("ButtonFont", ButtonFont);
            app.Resources.Add("CaptionFont", CaptionFont);
            app.Resources.Add("BodyFont", BodyFont);
            app.Resources.Add("Body2Font", Body2Font);
            app.Resources.Add("TitleFont", TitleFont);
            app.Resources.Add("SubheadFont", SubheadFont);
            app.Resources.Add("HeadlineFont", HeadlineFont);
            app.Resources.Add("Display1Font", Display1Font);
            app.Resources.Add("Display2Font", Display2Font);
            app.Resources.Add("Display3Font", Display3Font);
            app.Resources.Add("Display4Font", Display4Font);
        }

        public static void ApplyStyles(Application app, Color brandColor, Color brandColorLight, Color brandColorDark, Color brandAccentColor, string regularFontName, string mediumFontName, string lightFontName)
        {
            throw new NotImplementedException();
        }

        public static void ApplyStyles(Application app, Color brandColor, Color brandColorLight, Color brandColorDark, Color brandAccentColor)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Themes
        //Dark theme

        //Light Theme
        #endregion
    }
}
