using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Ghanta.Views
{
    class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            this.Children.Add(new GhantaPage());
            this.Children.Add(new AboutPage());
        }
    }
}
