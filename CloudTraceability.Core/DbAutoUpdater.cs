/*******************************************************
 * 
 * 作者：刘迁
 * 创建日期：20160411
 * 说明：初始化数据结构。
 * 运行环境：.NET 4.0
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 刘迁 20160411 15:13
 * 
*******************************************************/

using CloudTraceability.Core;
using Rafy;
using Rafy.Data;
using Rafy.DbMigration;
using Rafy.Domain;
using Rafy.Domain.ORM.DbMigration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudTraceability.Core
{
    public static class DbAutoUpdater
    {
        /// <summary>
        /// 初始化数据方法
        /// </summary>
        public static void Update()
        {
            if (Convert.ToBoolean(DBI.SaaS.Setting.GlobalConfig.Settings["CloudTraceability.AutoUpdateDb"]))
            {
                //var dbSettingName = SaaSPlugin.DbSettingName;
                //var dbSetting = DbSetting.FindOrCreate(dbSettingName);
                //if (dbSetting.ProviderName == DbConnectionSchema.Provider_MySql)
                //{
                //    DbMigrationSettings.StringColumnDbTypeLength = "200";
                //}

                var dbSettingName = CorePlugin.DbSettingName;

                #region 生成DBI.SaaS静态表及数据
                var svc = ServiceFactory.Create<MigrateService>();
                svc.Options = new MigratingOptions
                {
                    //ReserveHistory = true,//ReserveHistory 表示是否需要保存所有数据库升级的历史记录
                    RunDataLossOperation = DataLossOperation.None,//要支持数据库表、字段的删除操作，取消本行注释。
                    Databases = new string[] { dbSettingName }
                };
                svc.Invoke();
                #endregion
            }
        }
    }
}
