/*******************************************************
 * 
 * 作者：李行周
 * 创建日期：20180320
 * 说明：此文件只包含一个类，具体内容见类型注释。
 * 运行环境：.NET 4.5.2
 * 版本号：1.0.0
 * 
 * 历史记录：
 * 创建文件 李行周 20180320 16:05 910428123 
 * 
*******************************************************/

using CloudTraceability.Core;
using CloudTraceability.Migrations;
using CloudTraceability.MultiTenancy;
using Rafy;
using Rafy.Accounts;
using Rafy.Domain;
using Rafy.Domain.EntityPhantom;
using Rafy.Domain.Stamp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CloudTraceability.Web.App_Start
{
    /// <summary>
    /// Rafy环境初始化
    /// </summary>
    public class CloudTraceabilityEnvironmentConfig : DomainApp
    {
        protected override void InitEnvironment()
        {
            this.InitMultiTenancyType();
            RafyEnvironment.DomainPlugins.Add(new StampPlugin());
            RafyEnvironment.DomainPlugins.Add(new AccountsPlugin());
            RafyEnvironment.DomainPlugins.Add(new EntityPhantomPlugin());
            RafyEnvironment.DomainPlugins.Add(new MultiTenancyPlugin());
            RafyEnvironment.DomainPlugins.Add(new MigrationsPlugin());
            RafyEnvironment.DomainPlugins.Add(new CorePlugin());
            AccountsPlugin.DbSettingName = MigrationsPlugin.DbSettingName = AccountsPlugin.DbSettingName = CorePlugin.DbSettingName;
            base.InitEnvironment();
        }

        /// <summary>
        /// 设置哪些实体可以实现多租户记录
        /// </summary>
        private void InitMultiTenancyType()
        {
            MultiTenancyPlugin.Configuration.EnableMultiTenancy(
              typeof(User),
              typeof(Customer)
              );
        }

        protected override void OnStartupCompleted()
        {
            base.OnStartupCompleted();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected override void OnRuntimeStarting()
        {
            base.OnRuntimeStarting();

            DbAutoUpdater.Update();
        }
    }
}