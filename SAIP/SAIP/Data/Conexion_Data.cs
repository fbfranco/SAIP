using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIP.Data
{
    public class Conexion_Data
    {
        #region SINGLETON
        private static Conexion_Data Instance;
        public static Conexion_Data GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Conexion_Data();
            }
            return Instance;
        }
        #endregion

        public static string Cn = @"Data Source=bismarck-pc\sqlexpress;Initial Catalog=jarvisbd;Integrated Security=True";
    }
}
