using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.DbMigration;
using Rafy.Domain;
using Rafy.Domain.ORM.DbMigration;

namespace CloudTraceability.Migrations
{
    public class MigrationsPlugin : DomainPlugin
    {
        public static string DbSettingName = "Migrations";

        public override void Initialize(IApp app)
        {
        }
    }
}
