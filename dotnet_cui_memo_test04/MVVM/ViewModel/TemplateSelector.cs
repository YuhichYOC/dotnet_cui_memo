using System.Windows;
using System.Windows.Controls;

namespace MVVM.ViewModel
{
    public class TemplateSelector : DataTemplateSelector
    {
        public DataTemplate? Default { get; set; }

        public DataTemplate? DisplayTemplate { get; set; }

        public DataTemplate? EDIDTemplate { get; set; }

        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            if (item is DisplayViewModel)
            {
                return DisplayTemplate;
            }
            if (item is EDIDViewModel)
            {
                return EDIDTemplate;
            }
            return Default;
        }
    }
}