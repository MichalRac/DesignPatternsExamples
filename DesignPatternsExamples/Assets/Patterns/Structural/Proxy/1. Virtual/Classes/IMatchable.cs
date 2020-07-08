using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThirdPartyLibrary
{
    public interface IMatchable
    {
        int Id { get; set; }
        bool Compare(IMatchable other);
    }
}
