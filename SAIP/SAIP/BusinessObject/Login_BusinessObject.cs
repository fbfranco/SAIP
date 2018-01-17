﻿using SAIP.Data;
using System;
using System.Collections.Generic;

namespace SAIP.Model.BusinessObject
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

        #endregion

        #region Propiedades o Métodos de la Clase

        public List<Login_Model> GetUserLogin(string v1, string v2)
        {
            return Usuario = Login_Data.Login(v1, v2);
        }
        public void OnUserChanged()
        {
            UserChanged?.Invoke(this, null);
        }
        List<Login_Model> Usuario { get; set; }

        #endregion


    }
}
