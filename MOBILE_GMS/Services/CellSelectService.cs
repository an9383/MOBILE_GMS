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
    public class CellSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public CellSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public CellSelectModel SelectCell(CellSelectModel cellSelectModel)
        {
            string SP_name = "SP_PDA_CellSelect"; // procedure 명 
            string gubun = "Select"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@cell_cd:" + cellSelectModel.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);
                        
            CellSelectModel cm = new CellSelectModel();

            if (dt.Rows.Count > 0)
            {
                // 넘겨줄 데이터 세팅
                DataRow row = dt.Rows[0];
                cm.barcode = cellSelectModel.barcode;
                cm.cell_cd = row["cell_cd"].ToString();
                cm.cell_nm = row["cell_nm"].ToString();
                cm.cell_type_nm = row["cell_type_nm"].ToString();
                cm.cell_status = row["cell_status"].ToString();
                cm.location = row["location"].ToString();
                cm.cell_priority = row["cell_priority"].ToString();
                cm.cell_isle = row["cell_isle"].ToString();
                cm.cell_remark = row["cell_remark"].ToString();
            }
                     

            return cm;
        }

        public List<CellSelectModel> GridSelectCell(CellSelectModel cellSelectModel)
        {
            _logger.LogInformation(" [ logger ] :  CellSelectService > GridSelectCell() Access : " + DateTime.Now);

            List<CellSelectModel> cellList = new List<CellSelectModel>();

            string SP_name = "SP_PDA_CellSelect"; // procedure 명 
            string gubun = "SelectList"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@cell_cd:" + cellSelectModel.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CellSelectModel cm = new CellSelectModel();
                DataRow row = dt.Rows[i];
                cm.pack_barcode = row["pack_barcode"].ToString();
                cm.item_nm = row["item_nm"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();

                cellList.Add(cm);
            }

            return cellList;
        }
    }
}
