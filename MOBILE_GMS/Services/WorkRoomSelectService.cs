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
    public class WorkRoomSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public WorkRoomSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public WorkRoomSelectModel SelectZone(WorkRoomSelectModel workRoomSelectModel)
        {
            string SP_name = "SP_PDA_WorkroomSelect"; // procedure 명 
            string gubun = "Select"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@workroom_cd:" + workRoomSelectModel.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            WorkRoomSelectModel wm = new WorkRoomSelectModel();

            if (dt.Rows.Count > 0)
            {
                // 넘겨줄 데이터 세팅
                DataRow row = dt.Rows[0];
                wm.barcode = workRoomSelectModel.barcode;
                wm.workroom_cd = row["workroom_cd"].ToString();
                wm.workroom_nm = row["workroom_nm"].ToString();
                wm.cleanness_cd = row["cleanness_cd"].ToString();
                wm.workroom_type = row["workroom_type"].ToString();
                wm.workroom_type_nm = row["workroom_type_nm"].ToString();
                wm.warehouse_type = row["warehouse_type"].ToString();
                wm.warehouse_type_nm = row["warehouse_type_nm"].ToString();
                wm.workroom_status = row["workroom_status"].ToString();
                wm.workroom_status_nm = row["workroom_status_nm"].ToString();
                wm.display_seq = row["display_seq"].ToString();
                wm.permit_temp = row["permit_temp"].ToString();
                wm.permit_hum = row["permit_hum"].ToString();
                wm.zone_cnt = row["zone_cnt"].ToString();
                wm.cell_cnt = row["cell_cnt"].ToString();
                wm.use_cell = row["use_cell"].ToString();
            }

            return wm;
        }
    }
}
