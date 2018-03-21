/*******************************************************
 * 
 * 作者：李行周
 * 创建日期：20180320
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.5.2
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 李行周 20180320 16:57 910428123 
 * 
*******************************************************/



using CloudTraceability.Core;
using DBI.SaaS.Setting;
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

namespace CloudTraceability.Migrations
{
    public static class DbAutoUpdater
    {
        /// <summary>
        /// 初始化数据方法
        /// </summary>
        public static void Update()
        {
            if (Convert.ToBoolean(GlobalConfig.Settings["CloudTraceability.AutoUpdateDb"]))
            {
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
