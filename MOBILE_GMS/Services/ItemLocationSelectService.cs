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
    public class ItemLocationSelectService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();

        public ItemLocationSelectService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<ItemLocationSelectModel> ItemLocationSelectSearch(ItemLocationSelectModel model)
        {

            List<ItemLocationSelectModel> list = new List<ItemLocationSelectModel>();

            string SP_name = "SP_PDA_ItemLocationSelect"; //  procedure 명 
            string gubun = model.gubun;             //  Gunbun 명
            string[] param = new string[3];
            param[0] = "@item_cd:" + model.item_cd;
            param[1] = "@item_nm:" + model.item_nm;
            param[2] = "@lot_no:" + model.lot_no;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemLocationSelectModel cm = new ItemLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.item_pack_size = row["item_pack_size"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.location = row["location"].ToString();
                list.Add(cm);
            }
            return list;
        }

        public List<ItemLocationSelectModel> ItemLocationSelectBoxSearch(ItemLocationSelectModel model)
        {

            List<ItemLocationSelectModel> list = new List<ItemLocationSelectModel>();

            string SP_name = "SP_PDA_ItemLocationSelect"; //  procedure 명 
            string gubun = "Select_box";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemLocationSelectModel cm = new ItemLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.item_pack_size = row["item_pack_size"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.location = row["location"].ToString();
                list.Add(cm);
            }
            return list;
        }
         
        public List<ItemLocationSelectModel> ItemLocationSelectPackSearch(ItemLocationSelectModel model)
        {
            List<ItemLocationSelectModel> list = new List<ItemLocationSelectModel>();

            string SP_name = "SP_PDA_ItemLocationSelect"; //  procedure 명 
            string gubun = "Select_pack";             //  Gunbun 명
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ItemLocationSelectModel cm = new ItemLocationSelectModel();
                DataRow row = dt.Rows[i];
                cm.item_nm = row["item_nm"].ToString();
                cm.item_cd = row["item_cd"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.item_pack_size = row["item_pack_size"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.location = row["location"].ToString();
                list.Add(cm);
            }
            return list;
        }


        public List<ItemLocationSelectModel> ExamSelect(ItemLocationSelectModel model)
        {

            _logger.LogInformation(" [ logger ] :  ItemLocationSelectService > ExamSelect() Access : " + DateTime.Now);

            List<ItemLocationSelectModel> list = new List<ItemLocationSelectModel>();

            string SP_name = "SP_PDA_ItemLocationSelect";
            string gubun = "ExamSelect";
            string[] param = new string[0];

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ItemLocationSelectModel cm = new ItemLocationSelectModel();
                DataRow row = dt.Rows[i];

                cm.item_nm = row["item_nm"].ToString();
                cm.box_barcode_no = row["barcode_no"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.location = row["location"].ToString();

                list.Add(cm);
            }

            return list;
        }


        public List<ItemLocationSelectModel> ExamSearch(ItemLocationSelectModel model)
        {
            _logger.LogInformation(" [ logger ] :  ItemLocationSelectService > ExamSearch() Access : " + DateTime.Now);

            List<ItemLocationSelectModel> list = new List<ItemLocationSelectModel>();

            string SP_name = "SP_PDA_ItemLocationSelect";
            string gubun = "ExamSearch";
            string[] param = new string[1];
            param[0] = "@barcode_no:" + model.barcode;

            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                ItemLocationSelectModel cm = new ItemLocationSelectModel();
                DataRow row = dt.Rows[i];

                cm.item_nm = row["item_nm"].ToString();
                cm.box_barcode_no = row["barcode_no"].ToString();
                cm.lot_no = row["lot_no"].ToString();
                cm.stock_qty = row["stock_qty"].ToString();
                cm.location = row["location"].ToString();

                list.Add(cm);
            }

            return list;
        }
    }
}

