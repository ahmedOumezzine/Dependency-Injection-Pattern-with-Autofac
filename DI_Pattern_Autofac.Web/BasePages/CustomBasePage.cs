using DI_Pattern_Autofac.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_Pattern_Autofac.Web.BasePages
{
    public class CustomBasePage : WebViewPage
    {
        public ITeamRepository teamRepo { get; set; }
        public IRepository repo { get; set; }

        public override void Execute() { }
    }
}