﻿using Mov.WpfMvvms;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Scheduler.ViewModels
{
    public class SchedulerViewModel : RegionViewModelBase
    {
        public SchedulerViewModel(IRegionManager regionManager, IDialogService dialogService) : base(regionManager, dialogService)
        {

        }
    }
}