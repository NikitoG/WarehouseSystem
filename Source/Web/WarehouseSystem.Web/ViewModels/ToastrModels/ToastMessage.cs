namespace WarehouseSystem.Web.ViewModels.ToastrModels
{
    using System;

    [Serializable]
    public class ToastMessage
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public ToastType ToastType { get; set; }

        public bool IsSticky { get; set; }
    }
}