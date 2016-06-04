using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;

namespace TeamProject.Helpers
{
    public class SelectListViewItemWhenElementGotFocusBehaviorHelper : DependencyObject, IBehavior
    {
        private UIElement _element;

        public DependencyObject AssociatedObject { get; set; }

        #region ListView reference

        public ListView ListView
        {
            get { return (ListView)GetValue(ListViewProperty); }
            set { SetValue(ListViewProperty, value); }
        }

        public static readonly DependencyProperty ListViewProperty =
            DependencyProperty.Register("ListView", typeof(ListView), typeof(SelectListViewItemWhenElementGotFocusBehaviorHelper), new PropertyMetadata(null));

        #endregion

        public void Attach(DependencyObject associatedObject)
        {
            AssociatedObject = associatedObject;
            _element = this.AssociatedObject as UIElement;

            if (_element != null)
            {
                _element.GotFocus += OnElementGotFocus;
            }
        }

        private void OnElementGotFocus(object sender, RoutedEventArgs e)
        {
            var item = ((Button)sender).DataContext;
            var container = (ListViewItem)ListView.ContainerFromItem(item);

            container.IsSelected = true;
        }

        public void Detach()
        {
            if (_element != null)
            {
                _element.GotFocus += OnElementGotFocus;
            }
        }
    }
}
