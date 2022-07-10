using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestaurantsClientApp.Styles
{

    internal class StylesControls
    {
        public static Style buttonStyle;

        static StylesControls()
        {

            GetStyles();
        }
        static void GetStyles()
        {
            buttonStyle = new Style(typeof(ImageButton))
            {
                Setters =
                {

                    new Setter
                    {
                        Property = ImageButton.BackgroundColorProperty,
                        Value = Color.Transparent
                    },
                    new Setter
                    {
                        Property = ImageButton.AspectProperty,
                        Value = "AspectFit"
                    }
                    ,
                    new Setter
                    {
                        Property = ImageButton.HeightRequestProperty,
                        Value = 50
                    } ,
                    new Setter
                    {
                        Property = ImageButton.WidthRequestProperty,
                        Value = 50
                    }

                }
            };
        }
    }
}
