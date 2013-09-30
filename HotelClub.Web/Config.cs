using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HotelClub.Web
{
    public class Config
    {
        public static string ConnectionStringName
        {
            get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"] != null)
                {
                    return ConfigurationManager.AppSettings["ConnectionStringName"].ToString();
                }
                return "HotelClubDatabase";
            }
        }

        public static string UsersTableName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersTableName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersTableName"].ToString();
                }
                return "UserProfile";
            }
        }

        public static string UsersPrimaryKeyColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersPrimaryKeyColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersPrimaryKeyColumnName"].ToString();
                }
                return "UserId";
            }
        }

        public static string UsersUserNameColumnName
        {
            get
            {
                if (ConfigurationManager.AppSettings["UsersUserNameColumnName"] != null)
                {
                    return ConfigurationManager.AppSettings["UsersUserNameColumnName"].ToString();
                }
                return "UserName";
            }
        }

        public static string ImagesFolderPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["ImagesFolderPath"] != null)
                {
                    return ConfigurationManager.AppSettings["ImagesFolderPath"].ToString();
                }
                return "~/img/customers";
            }
        }

        public static string ImagesUrlPrefix
        {
            get
            {
                return Config.ImagesFolderPath.Replace("~", "");
            }
        }
    }
}