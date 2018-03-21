using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.Data;
using Rafy.Domain;
using Rafy.Domain.ORM;
using Rafy.Domain.ORM.Query;
using Rafy.Domain.Validation;
using Rafy.ManagedProperty;
using Rafy.MetaModel;
using Rafy.MetaModel.Attributes;
using Rafy.MetaModel.View;

namespace CloudTraceability.Core
{
    /// <summary>
    /// 客户信息
    /// </summary>
    [RootEntity, Serializable]
    public partial class Customer : CoreEntity
    {
        #region 构造函数

        public Customer() { }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected Customer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion

        #region 引用属性

        #endregion

        #region 组合子属性

        #endregion

        #region 一般属性

        public static readonly Property<string> CustomerNameProperty = P<Customer>.Register(e => e.CustomerName);
        /// <summary>
        /// 客户名称    
        /// </summary>
        public string CustomerName
        {
            get { return this.GetProperty(CustomerNameProperty); }
            set { this.SetProperty(CustomerNameProperty, value); }
        }

        public static readonly Property<string> CustomerCodeProperty = P<Customer>.Register(e => e.CustomerCode);
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerCode
        {
            get { return this.GetProperty(CustomerCodeProperty); }
            set { this.SetProperty(CustomerCodeProperty, value); }
        }

        #endregion

        #region 只读属性

        #endregion
    }

    /// <summary>
    /// 客户信息 列表类。
    /// </summary>
    [Serializable]
    public partial class CustomerList : CoreEntityList { }

    /// <summary>
    /// 客户信息 仓库类。
    /// 负责 客户信息 类的查询、保存。
    /// </summary>
    public partial class CustomerRepository : CoreEntityRepository
    {
        /// <summary>
        /// 单例模式，外界不可以直接构造本对象。
        /// </summary>
        protected CustomerRepository() { }
    }

    /// <summary>
    /// 客户信息 配置类。
    /// 负责 客户信息 类的实体元数据的配置。
    /// </summary>
    internal class CustomerConfig : CoreEntityConfig<Customer>
    {
        /// <summary>
        /// 配置实体的元数据
        /// </summary>
        protected override void ConfigMeta()
        {
            //配置实体的所有属性都映射到数据表中。
            Meta.MapTable().MapAllProperties();
        }
    }
}