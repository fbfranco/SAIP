using SAIP.Data;
using SAIP.Model;
using System;
using System.Collections.Generic;

namespace SAIP.BusinessObject
{
    public class Login_BusinessObject
    {
        #region Construtor
        public Login_BusinessObject()
        {
            Usuario = new List<Login_Model>();
        }
        #endregion
        
        #region Campos de la Clase
        public event EventHandler UserChanged;
        List<Login_Model> Usuario { get; set; }
        #endregion

        #region Propiedades o Métodos de la Clase
        /******Login******/
        public List<Login_Model> GetUserLogin(string v1, string v2)
        {
            return Usuario = Login_Data.Login(v1, v2);
        }

        /******Notificar cambios al Modelo******/
        public void OnUserChanged()
        {
            UserChanged?.Invoke(this, null);
        }
        #endregion


    }
}
