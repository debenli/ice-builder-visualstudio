﻿// **********************************************************************
//
// Copyright (c) 2003-2015 ZeroC, Inc. All rights reserved.
//
// **********************************************************************

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Windows.Forms;
using System.ComponentModel;

namespace ZeroC.IceVisualStudio
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("1D9ECCF3-5D2F-4112-9B25-264596873DC9")]
    public class IceOptionsPage : DialogPage
    {
        [Category("General")]
        [DisplayName("Ice Home")]
        [Description("Ice Home")]
        public String IceHome
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected override IWin32Window Window
        {
            get
            {
                IceHomeEditor page = new IceHomeEditor();
                page.optionsPage = this;
                page.Initialize();
                return page;
            }
        }

        public override void SaveSettingsToStorage()
        {
            IceVisualStudioPackage.setIceHome(_value);
        }

        public override void LoadSettingsFromStorage()
        {
            _value = IceVisualStudioPackage.getIceHome();
        }

        private String _value;
    }
}