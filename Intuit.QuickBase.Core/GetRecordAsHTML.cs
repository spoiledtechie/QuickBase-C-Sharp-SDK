﻿/*
 * Copyright © 2013 Intuit Inc. All rights reserved.
 * All rights reserved. This program and the accompanying materials
 * are made available under the terms of the Eclipse Public License v1.0
 * which accompanies this distribution, and is available at
 * http://www.opensource.org/licenses/eclipse-1.0.php
 */
using System.Xml.XPath;
using Intuit.QuickBase.Core.Payload;
using Intuit.QuickBase.Core.Uri;

namespace Intuit.QuickBase.Core
{
    public class GetRecordAsHtml : IQObject
    {
        private const string QUICKBASE_ACTION = "API_GetRecordAsHTML";
        private Payload.Payload _getRecordAsHtmlPayload;
        private IQUri _uri;

        public GetRecordAsHtml(string ticket, string appToken, string accountDomain, string dbid, int rid, bool jht)
        {
            CommonConstruction(ticket, appToken, accountDomain, dbid, new GetRecordAsHtmlPayload(rid, jht));
        }

        public GetRecordAsHtml(string ticket, string appToken, string accountDomain, string dbid, int rid)
        {
            CommonConstruction(ticket, appToken, accountDomain, dbid, new GetRecordAsHtmlPayload(rid));
        }

        private void CommonConstruction(string ticket, string appToken, string accountDomain, string dbid, Payload.Payload payload)
        {
            _getRecordAsHtmlPayload = new ApplicationTicket(payload, ticket);
            _getRecordAsHtmlPayload = new ApplicationToken(_getRecordAsHtmlPayload, appToken);
            _getRecordAsHtmlPayload = new WrapPayload(_getRecordAsHtmlPayload);
            _uri = new QUriDbid(accountDomain, dbid);
        }

        public string XmlPayload
        {
            get
            {
                return _getRecordAsHtmlPayload.GetXmlPayload();
            }
        }

        public System.Uri Uri
        {
            get
            {
                return _uri.GetQUri();
            }
        }

        public string Action
        {
            get
            {
                return QUICKBASE_ACTION;
            }
        }

        public XPathDocument Post()
        {
            HttpPost httpXml = new HttpPostXml();
            httpXml.Post(this);
            return httpXml.Response;
        }
    }
}
