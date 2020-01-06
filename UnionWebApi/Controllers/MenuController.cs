using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnionWebApi.Model.Entities.Menu;
using UnionWebApi.Models;

namespace UnionWebApi.Controllers
{
    public class MenuController : ApiController
    {
        public List<MenuCategory> GetMenu(int pIglesiaId)
        {
            List<MenuCategory> menuCategory = new List<MenuCategory>();
            var s1 = new MenuCategory()
            {
                Id = 1,
                BackgroundImage = "",
                Badge = 1,
                Icon = "\ue90b",
                Name = "Inicio",
                MenuList = new List<MenuItem>()
                {
                   new MenuItem() {
                       Id=1,Name="Inicio",PageType="HomeIglesiaVM",BackgroundImage="",Icon="LogoWindows",IsNew=false,JustNotifyNavigateIntent=false,Modal=false
                   }
                }
            };
            var s2 = new MenuCategory()
            {
                Id = 2,
                BackgroundImage = "",
                Badge = 1,
                Icon = "\ue90b",
                Name = "Departamentos",
                MenuList = new List<MenuItem>()
            };
            using (DataTable dt = Funciones.ExecuteDataTable("PA_API_DEPARTAMENTOS_POR_IGLESIA",pIglesiaId))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    s2.MenuList.Add(new MenuItem()
                    {
                        Id = int.Parse(dr["D_ID"].ToString()),
                        Name = dr["DT_PK"].ToString(),
                        PageType = "DeptoNoticiaVM",
                        BackgroundImage = "",
                        Icon = "InsertFile",
                        IsNew = bool.Parse(dr["esNuevo"].ToString()),
                        JustNotifyNavigateIntent = false,
                        Modal = false
                    });
                }
            }
            var s3 = new MenuCategory()
            {
                Id = 3,
                BackgroundImage = "",
                Badge = 1,
                Icon = "\ue7fd",
                Name = "Dirigentes",
                MenuList = new List<MenuItem>()
                {
                   new MenuItem() {
                       Id=1,Name="Dirigentes",PageType="DirigentesIglesiaVM",BackgroundImage="",Icon="Group",IsNew=false,JustNotifyNavigateIntent=false,Modal=false
                   }
                }
            };
            var s4 = new MenuCategory()
            {
                Id = 4,
                BackgroundImage = "",
                Badge = 1,
                Icon = "\ue7fd",
                Name = "Transmisiones en Vivo",
                MenuList = new List<MenuItem>()
                {
                   new MenuItem() {
                       Id=1,Name="En Vivo",PageType="IglesiaTransmisionEnVivoActualVM",BackgroundImage="",Icon="LocalMovies",IsNew=false,JustNotifyNavigateIntent=false,Modal=false
                   },
                   new MenuItem() {
                       Id=2,Name="Anteriores",PageType="IglesiaTransmisionEnVivoAnterioresVM",BackgroundImage="",Icon="LocalMovies",IsNew=false,JustNotifyNavigateIntent=false,Modal=false
                   }
                }
            };
            var s5 = new MenuCategory()
            {
                Id = 5,
                BackgroundImage = "",
                Badge = 1,
                Icon = "\ue7fd",
                Name = "Notificaciones",
                MenuList = new List<MenuItem>()
                {
                   new MenuItem() {
                       Id=1,Name="Historial",PageType="IglesiaNotificacionesVM",BackgroundImage="",Icon="Notifications",IsNew=false,JustNotifyNavigateIntent=false,Modal=false
                   }
                }
            };
            menuCategory.Add(s1);
            menuCategory.Add(s2);
            menuCategory.Add(s3);
            menuCategory.Add(s4);
            menuCategory.Add(s5);
            return menuCategory;
        }
    }
}
