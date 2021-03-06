// **********************************************************************
//
// Copyright (c) 2009-2016 ZeroC, Inc. All rights reserved.
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

namespace IceBuilder
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("1D9ECCF3-5D2F-4112-9B25-264596873DC9")]
    [Category("Projects and Solutions")]
    public class IceOptionsPage : DialogPage
    {
        IceHomeEditor Editor
        {
            get;
            set;
        }

        public IceOptionsPage()
        {
            Editor = new IceHomeEditor();
        }

        protected override IWin32Window Window
        {
            get
            {
                Editor.optionsPage = this;
                return Editor; 
            }
        }

        protected override void OnApply(DialogPage.PageApplyEventArgs e)
        {
            try
            {
                if(Editor.SetIceHome(Editor.IceHome))
                {
                    Package.Instance.SetIceHome(Editor.IceHome);
                }
                else
                {
                    e.ApplyBehavior = ApplyKind.CancelNoNavigate;
                }

                Package.Instance.SetAutoBuilding(Editor.AutoBuilding);
            }
            catch (Exception ex)
            {
                Package.UnexpectedExceptionWarning(ex);
                throw;
            }
        }

        protected override void OnActivate(CancelEventArgs e)
        {
            try
            {
                Editor.IceHome = Package.Instance.GetIceHome();
                Editor.AutoBuilding = Package.Instance.AutoBuilding;
            }
            catch (Exception ex)
            {
                Package.UnexpectedExceptionWarning(ex);
                throw;
            }
        }
    }
}
