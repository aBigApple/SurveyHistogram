using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    //==============================================================
    //  author：fengxiaojuan
    //  时间：2018/5/2 17:14:24
    //  文件名：PatternModel     
    //==============================================================
    public class PatternModel
    {
        public PatternModel()
        { }
        public PatternModel(string id, string name, string show)
        {
            Code = id;
            Name = name;
            Show = show;
        }
        //[DataMember]            //对方法2要设置成员属性
        public string Code
        {
            get;
            set;
        }
        //[DataMember]
        public string Name
        {
            get;
            set;
        }
        //[DataMember]
        public string Show
        {
            get;
            set;
        }
        
    }
}
