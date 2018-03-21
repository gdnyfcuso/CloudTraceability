using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CloudTraceability.MultiTenancy.DataInterception;
using Rafy;
using Rafy.ComponentModel;
using Rafy.DbMigration;
using Rafy.Domain;
using Rafy.Domain.ORM.DbMigration;

namespace CloudTraceability.MultiTenancy
{
    public class MultiTenancyPlugin : DomainPlugin
    {
        ///// <summary>
        ///// 数据库配置。
        ///// </summary>
        //public static string DbSettingName = "MultiTenancy";

        /// <summary>
        /// 多租户的配置。
        /// </summary>
        public static readonly MultiTenancyConfiguration Configuration = new MultiTenancyConfiguration();

        public override void Initialize(IApp app)
        {
            //拦截实体的插入和查询，自动处理多租户的属性。
            TenantDataInterceptor.Listen();
        }
    }
}
