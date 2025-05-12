using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class Menu_user
    {
        //public string user_id { get; set; }
        //public string emp_cd { get; set; }
        public string user_cd { get; set; }

        /// <summary>
        /// View To Controll
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// View To Controll
        /// </summary>
        public string pass { get; set; }

        public string access_id { get; set; }

        /// <summary>
        /// User_id
        /// </summary>
        public string User_id { get; set; }

        /// <summary>
        /// ID Name
        /// </summary>
        public string User_id_nm { get; set; }

        /// <summary>
        /// emp_cd
        /// </summary>
        public string User_cd { get; set; }

        /// <summary>
        /// user_nm
        /// </summary>
        public string User_nm { get; set; }

        /// <summary>
        /// user_dept_cd
        /// </summary>
        public string Dept_cd { get; set; }

        /// <summary>
        /// user_dept_nm
        /// </summary>
        public string Dept_nm { get; set; }

        /// <summary>
        /// emp_charge
        /// </summary>
        public string emp_charge { get; set; }

        /// <summary>
        /// new_user
        /// </summary>
        public string NewUser { get; set; }

        /// <summary>
        /// 공통코드 sys_plant_cd = 'PC001'
        /// </summary>
        public string sys_plant_cd { get; set; }
        
    }
}
