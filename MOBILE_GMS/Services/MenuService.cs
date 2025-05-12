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
    public class MenuService
    {
        static public ILogger<Controller> _logger;
        public BllSpExecute _bllSpExecute = new BllSpExecute();  

        public MenuService(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        public List<MenuModel> ListMenu()
        {

            _logger.LogInformation(" [ logger ] :  MenuService > ListMenu() Access : " + DateTime.Now);

            List<MenuModel> menuList = new List<MenuModel>();

            string SP_name = "SP_PDA_Menu"; // procedure 명 
            string gubun = "Module"; // Gunbun 명
            string[] param = new string[0];
            //param[0] = "@module_cd:1"; 
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for(int i=0;i<dt.Rows.Count; i++)
            {
                MenuModel mm = new MenuModel();
                DataRow row = dt.Rows[i];
                mm.module_cd = row["module_cd"].ToString();
                mm.module_nm = row["module_nm"].ToString();

                menuList.Add(mm); 
            }

            return menuList;

        }


        public List<MenuModel> ListSubMenu(string module_cd)
        { 
            List<MenuModel> menuList = new List<MenuModel>();

            string SP_name = "SP_PDA_Menu"; // procedure 명 
            string gubun = "Menu"; // Gunbun 명
            string[] param = new string[2];
            param[0] = "@module_cd:" + module_cd;
            param[1] = "@user_cd:" + Public_Function.User_cd; 
            DataTable dt = _bllSpExecute.SpExecuteTable(SP_name, gubun, param);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MenuModel mm = new MenuModel();
                DataRow row = dt.Rows[i];
                mm.form_cd = row["form_cd"].ToString();
                mm.module_cd = row["module_cd"].ToString();
                mm.form_nm = row["form_nm"].ToString();
                mm.source_cd = row["source_cd"].ToString();
                mm.appIcon = row["appIcon"].ToString();
                
                menuList.Add(mm);
            }

            return menuList;

        }

    }
}
