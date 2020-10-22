using Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Model {
    public interface IImageHierarchy : IName, IValue {
        string Avatar { get; set; }
        DateTime Date { get; set; }
        bool IsSelected { get; set; }
        bool IsExpanded { get; set; }
        List<IImageHierarchy> Children { get; set; }
        IImageHierarchy Parent { get; set; }
    }

    public interface IHierarchy : IName, IValue {
        bool IsSelected { get; set; }
        bool IsExpanded { get; set; }
        List<IHierarchy> Children { get; set; }
        IHierarchy Parent { get; set; }
    }
}
