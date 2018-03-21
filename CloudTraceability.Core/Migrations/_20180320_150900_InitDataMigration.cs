/*******************************************************
 * 
 * 作者：李行周
 * 创建日期：20180320
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.5.2
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 李行周 20180320 18:29 910428123 
 * 
*******************************************************/

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
        public override string DbSetting => CorePlugin.DbSettingName;

        public override ManualMigrationType Type => ManualMigrationType.Data;

        public override string Description => this.GetType().FullName;

        protected override void Down()
        {
        }

        protected override void Up()
        {
            //RF.Save(new Customer() { CustomerName = "李行周", CustomerCode = "LiXingZhou" });
            //RF.Save(new User() { Email = "gdnyfcuso@163.com", IsDisabled = true, Password = "123456", PhoneNumber = "15110114229", RealName = "李行周" });
        }
    }
}
