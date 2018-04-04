using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UI.Model
{
    class MyCellStyleSelector : StyleSelector
    {
        public override System.Windows.Style SelectStyle(object item, System.Windows.DependencyObject container)
        {
            LiveModel liveModel = item as LiveModel;

            if (liveModel != null && liveModel.Value == "1")
            {
                return ActiveStyle;
            }

            return DefaultStyle;
        }

        public Style ActiveStyle { get; set; }

        public Style DefaultStyle { get; set; }
    }
}
