﻿/*
 * Copyright © 2010 Intuit Inc. All rights reserved.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.opensource.org/licenses/eclipse-1.0.php
 */
namespace Intuit.QuickBase.Client
{
    public abstract class GrantedInfo
    {
        protected GrantedInfo(string name, string dbid)
        {
            Name = name;
            Dbid = dbid;
        }

        public string Name { get; private set; }
        public string Dbid { get; private set; }
    }
}
