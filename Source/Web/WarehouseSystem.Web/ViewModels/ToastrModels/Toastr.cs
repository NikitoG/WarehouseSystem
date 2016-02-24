﻿namespace WarehouseSystem.Web.ViewModels.ToastrModels
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Toastr
    {
        public Toastr()
        {
            this.ToastMessages = new List<ToastMessage>();
            this.ShowNewestOnTop = false;
            this.ShowCloseButton = false;
        }

        public bool ShowNewestOnTop { get; set; }

        public bool ShowCloseButton { get; set; }

        public List<ToastMessage> ToastMessages { get; set; }

        public ToastMessage AddToastMessage(string title, string message, ToastType toastType)
        {
            var toast = new ToastMessage()
            {
                Title = title,
                Message = message,
                ToastType = toastType
            };

            this.ToastMessages.Add(toast);
            return toast;
        }
    }
}
