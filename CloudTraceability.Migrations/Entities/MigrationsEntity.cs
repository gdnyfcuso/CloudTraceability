using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using Rafy;
using Rafy.ComponentModel;
using Rafy.Domain;
using Rafy.Domain.ORM;
using Rafy.Domain.Validation;
using Rafy.MetaModel;
using Rafy.MetaModel.Attributes;
using Rafy.MetaModel.View;
using Rafy.ManagedProperty;
using Rafy.Domain.Stamp;

namespace CloudTraceability.Migrations
{
    [Serializable]
    public abstract class MigrationsEntity : LongEntity
    {
        #region 构造函数

        protected MigrationsEntity() { }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        protected MigrationsEntity(SerializationInfo info, StreamingContext context) : base(info, context) { }

        #endregion

        #region 所有实体都统一拥有的属性：时间戳、作者、变更者等。

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime
        {
            get { return this.GetCreatedTime(); }
            set { this.SetCreatedTime(value); }
        }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime UpdatedTime
        {
            get { return this.GetUpdatedTime(); }
            set { this.SetUpdatedTime(value); }
        }

        /// <summary>
        /// 创建数据的用户
        /// </summary>
        public string CreatedUser
        {
            get { return this.GetCreatedUser(); }
            set { this.SetCreatedUser(value); }
        }

        /// <summary>
        /// 最后更新数据的用户。
        /// </summary>
        public string UpdatedUser
        {
            get { return this.GetUpdatedUser(); }
            set { this.SetUpdatedUser(value); }
        }

        #endregion

    }

    [Serializable]
    public abstract class MigrationsEntityList : EntityList { }

    public abstract class MigrationsEntityRepository : EntityRepository
    {
        protected MigrationsEntityRepository() { }
    }

    [DataProviderFor(typeof(MigrationsEntityRepository))]
    public class MigrationsEntityRepositoryDataProvider : RdbDataProvider
    {
        protected override string ConnectionStringSettingName
        {
            get { return MigrationsPlugin.DbSettingName; }
        }
    }

    public abstract class MigrationsEntityConfig<TEntity> : EntityConfig<TEntity> { }
}