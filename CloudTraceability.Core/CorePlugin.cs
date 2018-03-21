using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.DbMigration;
using Rafy.Domain;
using Rafy.Domain.ORM.DbMigration;

namespace CloudTraceability.Core
{
    public class CorePlugin : DomainPlugin
    {
        public static string DbSettingName = "Core";

        public override void Initialize(IApp app)
        {
        }
    }
}
