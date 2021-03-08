using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;



namespace ThemeWrap1
{
    //Wrapper Control to allow Changing RequestedTheme at the Grid level
    //RequestedTheme is only applied if the FrameworkElement has a Template.  So Wrap adds a Template to wrap
    //around grids or other panels.
    [ContentProperty(Name = "Children")]
    public sealed class Wrap : Control
    {
        public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register(
          nameof(Children),
          typeof(UIElementCollection),
          typeof(Wrap),
          new PropertyMetadata(null));

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        public Wrap()
        {
            this.DefaultStyleKey = typeof(Wrap);
            //instance Grid to get a UIElementCollection.  UIElementCollection has no exposed constructor.
            Grid tempgrid = new Grid();
            Children = tempgrid.Children;
            tempgrid = null;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //Get the Template Grid and Move the Children.
            if (GetTemplateChild("BaseG") is Grid gd)
            {             
                var clist = Children.ToList();
                Children.Clear();
                foreach (var item in clist)
                {
                    gd.Children.Add(item);
                }
                Children = gd.Children;
            }
        }
    }
}
