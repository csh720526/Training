using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Example04
{
    [Table("Member")]
    public class MemberEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// 用戶編號
        /// </summary>
        [Index(IsUnique = true)]
        public long UserNo { get; set; }

        [MaxLength(32)]
        [Index(IsUnique = true)]
        public string MemberKey { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 認證碼
        /// </summary>
        public string AuthCode { get; set; }

        public UserStatus Status { get; set; }

        //public string OpenID { get; set; }
        //public OpenIdType OpenIdType { get; set; }

        public SexType Sex { get; set; }

        /// <summary>
        /// 註冊日期
        /// </summary>
        public DateTime? RegisteTime { get; set; }

        /// <summary>
        /// 大頭照路徑
        /// </summary>
        public string MugshotUrl { get; set; }

        /// <summary>
        /// 前次使用搖搖優惠時間
        /// </summary>
        public DateTime? LastShake { get; set; }

        /// <summary>
        /// 前次登入時間
        /// </summary>
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// 剩餘街口幣
        /// </summary>
        public int JKOSCoin { get; set; }

        /// <summary>
        /// 剩餘活動型街口幣
        /// </summary>
        public int BenefitCoin { get; set; }

        /// <summary>
        /// [訂位] 到店次數
        /// </summary>
        public int BookingInplaceCount { get; set; }

        /// <summary>
        /// [訂位] 未到店次數
        /// </summary>
        public int BookingNoShowCount { get; set; }

        /// <summary>
        /// [候位] 到店次數
        /// </summary>
        public int WaitingInplaceCount { get; set; }

        /// <summary>
        /// [候位] 未到店次數
        /// </summary>
        public int WaitingNoShowCount { get; set; }

        /// <summary>
        /// 會員類型
        /// </summary>
        public MemberType MemberType { get; set; }

        public int? AreaID { get; set; }

        /// <summary>
        /// 發票地址 - 不包含縣市區域地址
        /// </summary>
        [MaxLength(100)]
        public string Address { get; set; }

        /// <summary>
        /// 會員生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 會員暱稱
        /// </summary>
        [MaxLength(100)]
        public string Nickname { get; set; }


    }

    /// <summary>
    /// 使用者狀態
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// 啟用
        /// </summary>
        [Description("啟用")]
        Enable = 1,

        /// <summary>
        /// 停用
        /// </summary>
        [Description("停用")]
        Disable = 2,

        /// <summary>
        /// 未開通
        /// </summary>
        [Description("未開通")]
        NoOpen = 3
    }

    public enum SexType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknow = 0,
        /// <summary>
        /// 男性
        /// </summary>
        [Description("男性")]
        Male = 1,
        /// <summary>
        /// 女性
        /// </summary>
        [Description("女性")]
        Female = 2,
        /// <summary>
        /// 全部(For 查詢)
        /// </summary>
        [Description("全部")]
        All = 4
    }

    /// <summary>
    /// 會員類型
    /// </summary>
    public enum MemberType
    {
        /// <summary>
        /// 正式會員
        /// </summary>
        Offical = 1,

        /// <summary>
        /// 匿名會員
        /// </summary>
        Guest = 2
    }
}
