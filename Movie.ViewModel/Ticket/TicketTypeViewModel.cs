using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movie.ViewModel.Ticket
{
    public class TicketTypeViewModel
    {
        public long ID { get; set; } 
        public string TicketTypeName { get; set; }
        public int Sort { get; set; }
        public int Status { get; set; }
        public string CreateBy { get; set; }
        public string CreateIP { get; set; }
        public string CreateTime { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateIP { get; set; }
        public string UpdateTime { get; set; }

        /// <summary>
        /// 凭据类型状态
        /// </summary>
        /// <param name="val">凭据类型状态</param>
        /// <returns></returns>
        public string StatusStr
        {
            get
            {
                string result = "";
                switch (Status)
                {
                    case 0:
                        result = "启用";
                        break;
                    case 1:
                        result = "禁用";
                        break;
                }
                return result;
            }
        }
    }
}
