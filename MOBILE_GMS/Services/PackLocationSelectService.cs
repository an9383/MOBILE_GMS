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
    public class PackLocationSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public PackLocationSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<PackLocationSelectModel> PackLocationSelectSearch(PackLocationSelectModel model)
        {

            List<PackLocationSelectModel> list = new List<PackLocationSelectModel>();

            string SP_name = "SP_PDA_PackLocationSelect"; //  procedure 명 
            string gubun = model.gubun;             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@item_cd:" + model.item_cd;
            param[1] = "@item_nm:" + model.item_nm;
            param[2] = "@test_no:" + model.test_no;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackLocationSelectModel cm = new PackLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.location = row["location"].ToString();
                cm.stock_qty = row["stock_qty"].ToString(); 
                list.Add(cm);
            }
            return list;
        }

        public List<PackLocationSelectModel> PackLocationSelectBoxSearch(PackLocationSelectModel model)
        {

            List<PackLocationSelectModel> list = new List<PackLocationSelectModel>();

            string SP_name = "SP_PDA_PackLocationSelect"; //  procedure 명 
            string gubun = "Select_box";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackLocationSelectModel cm = new PackLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.location = row["location"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                list.Add(cm);
            }
            return list;
        }
         
        public List<PackLocationSelectModel> PackLocationSelectPackSearch(PackLocationSelectModel model)
        {

            List<PackLocationSelectModel> list = new List<PackLocationSelectModel>();

            string SP_name = "SP_PDA_PackLocationSelect"; //  procedure 명 
            string gubun = "Select_pack";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackLocationSelectModel cm = new PackLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.location = row["location"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                list.Add(cm);
            }
            return list;
        }

        public List<PackLocationSelectModel> ExamSelect(PackLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  PackLocationSelectService > ExamSearch() Access : " + DateTime.Now);

            List<PackLocationSelectModel> list = new List<PackLocationSelectModel>();

            string SP_name = "SP_PDA_PackLocationSelect";
            string gubun = "Select_Exam";
            string[] param = new string[1];
            param[0] = "@test_no:" + model.test_no;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackLocationSelectModel cm = new PackLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.receipt_pack_barcode = row["barcode_no"].ToString();
                cm.location = row["location"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                list.Add(cm);
            }

            return list;
        }


        public List<PackLocationSelectModel> ExamSearch(PackLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  PackLocationSelectService > ExamSearch() Access : " + DateTime.Now);

            List<PackLocationSelectModel> list = new List<PackLocationSelectModel>();

            string SP_name = "SP_PDA_PackLocationSelect";
            string gubun = "Search_Exam";
            string[] param = new string[1];
            param[0] = "@test_no:" + model.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PackLocationSelectModel cm = new PackLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.test_no = row["test_no"].ToString();
                cm.receipt_pack_barcode = row["barcode_no"].ToString();
                cm.location = row["location"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                list.Add(cm);
            }

            return list;
        }

    }
}
