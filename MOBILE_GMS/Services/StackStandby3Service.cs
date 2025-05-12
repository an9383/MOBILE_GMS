using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class StackStandby3Service
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public StackStandby3Service(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<StackStandbyModel> StackStandby3Search(StackStandbyModel model)
        {
            _logger.LogInformation(" [ logger ] :  StackStandbyService > StackStandbySearch() Access : " + DateTime.Now);

            List<StackStandbyModel> list = new List<StackStandbyModel>();

            string SP_name = "SP_PDA_StackStandby"; //  procedure 명 
            string gubun = model.gubun;             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@standby_gubun:" + model.standby_gubun;
            param[1] = "@item_cd:" + model.item_cd;
            param[2] = "@item_nm:" + model.item_nm;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StackStandbyModel cm = new StackStandbyModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.receipt_pack_seq = row["receipt_pack_seq"].ToString();
                cm.receipt_status = row["receipt_status"].ToString();
                cm.receipt_pack_barcode = row["receipt_pack_barcode"].ToString();
                cm.workroom_nm = row["workroom_nm"].ToString();
                cm.zone_nm = row["zone_nm"].ToString();
                cm.cell_nm = row["cell_nm"].ToString();
                cm.remain_qty = row["remain_qty"].ToString();
                list.Add(cm);
            }
            return list;
        }
    }
}
