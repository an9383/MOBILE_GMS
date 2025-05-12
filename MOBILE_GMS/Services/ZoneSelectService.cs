using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class ZoneSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public ZoneSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public ZoneSelectModel SelectZone(ZoneSelectModel zoneSelectModel)
        {
            string SP_name = "SP_PDA_ZoneSelect"; // procedure 명 
            string gubun = "Select"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@zone_cd:" + zoneSelectModel.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            ZoneSelectModel zm = new ZoneSelectModel();

            if (dt.Rows.Count > 0)
            {
                // 넘겨줄 데이터 세팅
                DataRow row = dt.Rows[0];
                zm.barcode = zoneSelectModel.barcode;
                zm.zone_cd = row["zone_cd"].ToString();
                zm.zone_nm = row["zone_nm"].ToString();
                zm.zone_type = row["zone_type"].ToString();
                zm.zone_type_nm = row["zone_type_nm"].ToString();
                zm.zone_priority = row["zone_priority"].ToString();
                zm.zone_status = row["zone_status"].ToString();
                zm.zone_status_nm = row["zone_status_nm"].ToString();
                zm.permit_temp = row["permit_temp"].ToString();
                zm.permit_hum = row["permit_hum"].ToString();
                zm.workroom_cd = row["workroom_cd"].ToString();
                zm.workroom_nm = row["workroom_nm"].ToString();
                zm.cell_cnt = row["cell_cnt"].ToString();
                zm.use_cell = row["use_cell"].ToString();
                zm.empty_cell = row["empty_cell"].ToString();
                zm.zone_remark = row["zone_remark"].ToString();
            }

            return zm;
        }
    }
}
