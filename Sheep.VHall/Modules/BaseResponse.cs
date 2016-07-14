using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sheep.VHall.Modules
{
    public class BaseResponse
    {
        public Code code { get; set; }

        public string msg { get; set; }
    }

    public enum Code
    {
        成功 = 200,
        账号或密码为空 = 10000,
        账号或密码错误 = 10001,
        Vhall正在审核API接入权限接口暂不可用 = 10002,
        无此活动信息 = 10010,
        活动信息与用户信息不匹配 = 10011,
        必填字段缺失 = 10012,
        开始时间晚于结束时间 = 10013,
        主题为空或者超过50个字符 = 10014,
        公共密码格式错误6至20位英文字母数字或组合 = 10015,
        存在第三方K值验证但是接口地址auth_url为空 = 10016,
        没有活动ID = 10017,
        没有相关权限 = 10018,
        没有相关信息 = 10019,
        活动组织者不能以嘉宾身份进入 = 10020,
        邮箱格式不正确 = 10021,
        姓名超过30个字符 = 10022,
        没有录播ID = 10023,
        活动状态不是进行中 = 10024,
        结束失败稍候重试 = 10025,
        数据格式错误 = 10026,
        没有问卷ID = 10027,
        活动进行中不能获取 = 10028,
        内部错误稍候重试 = 10500
    }
}
