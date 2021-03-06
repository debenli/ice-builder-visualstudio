// **********************************************************************
//
// Copyright (c) 2009-2016 ZeroC, Inc. All rights reserved.
//
// **********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceBuilder
{
    public interface VCUtil
    {
        bool SetupSliceFilter(EnvDTE.Project project);
        void AddGeneratedFiles(EnvDTE.Project dteProject, EnvDTE.Configuration config, String filterName, List<String> paths, bool generatedFilesPerConfiguration);
        String Evaluate(EnvDTE.Configuration config, String value);
    }
}
