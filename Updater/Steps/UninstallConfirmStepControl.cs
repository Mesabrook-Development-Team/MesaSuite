﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Updater.UpdateWorkflow;

namespace Updater.Steps
{
    public partial class UninstallConfirmStepControl : UserControl, IStepUserControl
    {
        public UninstallConfirmStepControl()
        {
            InitializeComponent();
        }

        public Step Step { get; set; }
    }
}
