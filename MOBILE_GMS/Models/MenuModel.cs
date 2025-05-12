using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Models
{
    public class MenuModel
    {
        /// <summary>
        /// 상위 메뉴 정보
        /// </summary>
        public string module_cd { get; set; }
        public string module_nm { get; set; }

        /// <summary>
        ///  하위 메뉴 정보
        /// </summary>
        public string form_cd { get; set; }
        public string form_nm { get; set; }
        public string source_cd { get; set; }
        public string barcode { get; set; }

        public string c_barcode { get; set; }

        /// <summary>
        /// 바코드(장소)
        /// </summary>
        public string area_barcode { get; set; }

        /// <summary>
        /// 앱 아이콘
        /// </summary>
        public string appIcon { get; set; }
        public string cell_cd { get; set; }

        public MenuModel()
        {
            area_barcode = "";
        }
    }
}
