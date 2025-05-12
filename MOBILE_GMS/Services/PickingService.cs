using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using mobile_gms.Controllers;
using mobile_gms.DataContext;
using mobile_gms.Libs;
using mobile_gms.Libs.Database;
using mobile_gms.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobile_gms.Services
{
    public class PickingService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();  

        public PickingService(ILogger<Controller> logger)
        {
            _logger = logger;
        }
        
        public DataSet SelectWorkroom(AreaModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = "Select_workroom"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@workroom_cd:" + model.barcode;
            DataSet dt = _bllSpExecute.SpExecuteDataSet(SP_name, gubun, param); 
             
            return dt;
        }

        public DataSet SelectZone(AreaModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = "Select_zone"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@zone_cd:" + model.barcode;
            DataSet dt = _bllSpExecute.SpExecuteDataSet(SP_name, gubun, param);

            return dt;
        }

        public DataSet SelectCell(AreaModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = "Select_cell"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@cell_cd:" + model.barcode;
            DataSet dt = _bllSpExecute.SpExecuteDataSet(SP_name, gubun, param);

            return dt;
        }

        public PackModel SelectPickPackInfo(PackModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = "Pack"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@pack_barcode:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            PackModel pm = new PackModel();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                pm.pack_barcode = row["pack_barcode"].ToString();
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.test_no = row["test_no"].ToString();
                pm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();

            }
            return pm;
        }

        
        public PackModel SelectPickBoxInfo(PackModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = "box"; // Gunbun 명
            string[] param = new string[1];
            param[0] = "@pack_barcode:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            PackModel pm = new PackModel();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                pm.pack_barcode = row["pack_barcode"].ToString();
                pm.item_cd = row["item_cd"].ToString();
                pm.item_nm = row["item_nm"].ToString();
                pm.test_no = row["test_no"].ToString();
                pm.receipt_pack_remain_qty = row["receipt_pack_remain_qty"].ToString();

            }
            return pm;
        }
         
        public string PickPack(PackModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@pack_barcode:" + model.barcode;
            param[1] = "@user_cd:" + model.user_cd;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
        public string PickBox(PackModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@pack_barcode:" + model.barcode;
            param[1] = "@user_cd:" + model.user_cd;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
        
        public string PickPallet(PackModel model)
        {

            string SP_name = "SP_PDA_Picking"; // procedure 명 
            string gubun = model.gubun; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@pack_barcode:" + model.barcode;
            param[1] = "@user_cd:" + model.user_cd;

            string dt = _bllSpExecute.SpExecuteString(SP_name, gubun, param);

            return dt;
        }
    }
}
