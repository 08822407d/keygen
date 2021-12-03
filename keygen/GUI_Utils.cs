using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


class GUI_Utils
{
    static public void controls_disable(Control container)
    {
        foreach (Control ctrl in container.Controls)
        {
            if (ctrl.GetType().Name == "TextBox" ||
                ctrl.GetType().Name == "Button")
                ctrl.Enabled = false;
        }
    }

    static public void controls_enable(Control container)
    {
        foreach (Control ctrl in container.Controls)
        {
            if (ctrl.GetType().Name == "TextBox" ||
                ctrl.GetType().Name == "Button")
                ctrl.Enabled = true;
        }
    }
}
