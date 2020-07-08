using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThirdPartyLibrary
{
    public interface IMatchable
    {
        int Id { get; set; }
        Color Color { get; set; }
        string Text { get; set; }
    }

}
