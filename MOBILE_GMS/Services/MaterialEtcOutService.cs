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
    public class MaterialEtcOutService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public MaterialEtcOutService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public MaterialModel MaterialEtcOutSearch(MaterialModel model)
        {
            string SP_name = "SP_PDA_MaterialEtcOut"; //  procedure 명 
            string gubun = "Select";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_cd:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            MaterialModel pm = new MaterialModel();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; 
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.receipt_no = row["receipt_no"].ToString();
                pm.receipt_id = row["receipt_id"].ToString();
                pm.receipt_pack_seq = row["receipt_pack_seq"].ToString();
                pm.test_no = row["test_no"].ToString();
                pm.receipt_status_nm = row["receipt_status_nm"].ToString();
                pm.receipt_status = row["receipt_status"].ToString();
                pm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();
                pm.keeping_unit = row["keeping_unit"].ToString();
            }
             
            return pm;
        }

        public string SaveMaterialEtcOut(MaterialModel model)
        {
            string SP_name = "SP_PDA_MaterialEtcOut"; // procedure 명 
            string gubun = "Out"; // Gunbun 명
            string[] param = new string[7];
            param[0] = "@receipt_no:" + model.receipt_no;
            param[1] = "@receipt_id:" + model.receipt_id;
            param[2] = "@receipt_pack_seq:" + model.receipt_pack_seq;
            param[3] = "@out_type:" + model.out_type;
            param[4] = "@out_qty:" + model.out_qty;
            param[5] = "@out_date:" + model.out_date;
            param[6] = "@out_remark:" + model.in_remark;
            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
    }
}
