using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace uretimPlanlamaProgrami
{
    public partial class CutsomAppoinmentForm : Telerik.WinControls.UI.Scheduler.Dialogs.EditAppointmentDialog
    {
        public CutsomAppoinmentForm()
        {
            InitializeComponent();
        }

        protected override void LoadSettingsFromEvent(Telerik.WinControls.UI.IEvent sourceEvent)
        {
            base.LoadSettingsFromEvent(sourceEvent);
        } 
    }
}
