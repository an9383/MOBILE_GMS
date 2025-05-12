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
    public class ProductEtcOutService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public ProductEtcOutService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public ProductModel ProductEtcOutSearch(ProductModel model)
        {
            string SP_name = "SP_PDA_ProductEtcOut"; //  procedure 명 
            string gubun = "Select";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            ProductModel pm = new ProductModel();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0]; 
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.lot_no = row["lot_no"].ToString();
                pm.issue_status_nm = row["issue_status_nm"].ToString();
                pm.issue_status = row["issue_status"].ToString();
                pm.stock_qty = row["stock_qty"].ToString();
                pm.keeping_unit = row["keeping_unit"].ToString();
            }
             
            return pm;
        }

        public string SaveProductEtcOut(ProductModel model)
        {
            string SP_name = "SP_PDA_ProductEtcOut"; // procedure 명 
            string gubun = "Out"; // Gunbun 명
            string[] param = new string[6];
            param[0] = "@barcode_no:" + model.barcode;
            param[1] = "@out_type:" + model.out_type;
            param[2] = "@out_qty:" + model.out_qty;
            param[3] = "@out_date:" + model.out_date;
            param[4] = "@out_remark:" + model.in_remark;
            param[5] = "@insert_user_cd:" + model.user_cd;
            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
    }
}
