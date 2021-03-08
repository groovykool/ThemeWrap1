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
            Grid tempgrid = new Grid();
            Children = tempgrid.Children;
            tempgrid = null;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
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
