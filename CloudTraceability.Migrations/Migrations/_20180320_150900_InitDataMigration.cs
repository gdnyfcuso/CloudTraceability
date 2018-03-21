using CloudTraceability.Core;
using Rafy.Accounts;
using Rafy.DbMigration;
using Rafy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTraceability.Migrations.Migrations
{
    public class _20180320_150900_InitDataMigration : ManualDbMigration
    {
        public override string DbSetting => MigrationsPlugin.DbSettingName;

        public override ManualMigrationType Type => ManualMigrationType.Data;

        public override string Description => this.GetType().FullName;

        protected override void Down()
        {
            
        }

        protected override void Up()
        {
            RF.Save(new Customer() { CustomerName = "李行周", CustomerCode = "LiXingZhou" });
            RF.Save(new User() { Email = "gdnyfcuso@163.com", IsDisabled = true, Password = "123456", PhoneNumber = "15110114229", RealName = "李行周" });
        }
    }
}
