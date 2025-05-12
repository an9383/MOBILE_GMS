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
    public class MaterialInOutSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public MaterialInOutSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public MaterialInOutSelectModel MaterialInfo(MaterialInOutSelectModel materialModel)
        {
            string SP_name = "SP_PDA_MaterialInOutSelect"; // procedure 명 
            string gubun = "Select"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + materialModel.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);
            
            MaterialInOutSelectModel mm = new MaterialInOutSelectModel();

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                mm.receipt_no = row["receipt_no"].ToString();
                mm.receipt_id = row["receipt_id"].ToString();
                mm.receipt_pack_seq = row["receipt_pack_seq"].ToString();
                mm.item_cd = row["item_cd"].ToString();
                mm.item_nm = row["item_nm"].ToString();
                mm.receipt_status = row["receipt_status"].ToString();
                mm.test_no = row["test_no"].ToString();
                mm.receipt_status_nm = row["receipt_status_nm"].ToString();
                mm.receipt_pack_qty = row["receipt_pack_qty"].ToString();
                mm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();
                mm.keeping_unit = row["keeping_unit"].ToString();
                mm.receipt_pack_barcode = row["receipt_pack_barcode"].ToString();
                mm.barcode = row["receipt_pack_barcode"].ToString();
            }            

            return mm;
        }

        public List<MaterialInOutSelectModel> GridSelect(MaterialInOutSelectModel materialModel)
        {
            _logger.LogInformation(" [ logger ] :  " +
                "MaterialInOutSelectService > GridSelect() Access : " + DateTime.Now);

            List<MaterialInOutSelectModel> MaterialList = new List<MaterialInOutSelectModel>();

            string SP_name = "SP_PDA_MaterialInOutSelect"; // procedure 명 
            string gubun = "GridSelect"; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@barcode_cd:" + materialModel.barcode;
            param[1] = "@page:" + materialModel.page;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                MaterialInOutSelectModel mm = new MaterialInOutSelectModel();

                mm.receipt_no = row["receipt_no"].ToString();
                mm.receipt_id = row["receipt_id"].ToString();
                mm.receipt_pack_seq = row["receipt_pack_seq"].ToString();
                mm.receipt_type_nm = row["receipt_type_nm"].ToString();
                mm.receipt_date = row["receipt_date"].ToString();
                mm.receipt_qty = row["receipt_qty"].ToString();
                mm.seq = row["seq"].ToString();
                //mm.COUNT = row["COUNT"].ToString();
                //mm.page = row["page"].ToString();
                //mm.tot_page = row["tot_page"].ToString();

                MaterialList.Add(mm);
            }

            return MaterialList;
        }
    }
}
